using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CluedIn.Core.Logging;
using CluedIn.Core.Providers;
using CluedIn.Crawling.SharePoint.Core;
using CluedIn.Crawling.SharePoint.Core.Models;
using Newtonsoft.Json;
using RestSharp;

namespace CluedIn.Crawling.SharePoint.Infrastructure
{
    // TODO - This class should act as a client to retrieve the data to be crawled.
    // It should provide the appropriate methods to get the data
    // according to the type of data source (e.g. for AD, GetUsers, GetRoles, etc.)
    // It can receive a IRestClient as a dependency to talk to a RestAPI endpoint.
    // This class should not contain crawling logic (i.e. in which order things are retrieved)
    public class SharePointClient
    {
        private const string BaseUri = "http://sample.com";

        private readonly ILogger log;

        private readonly IRestClient client;

        private readonly SharePointCrawlJobData _sharePointCrawlJobData;

        public SharePointClient(ILogger log, SharePointCrawlJobData sharepointCrawlJobData, IRestClient client) // TODO: pass on any extra dependencies
        {
            if (sharepointCrawlJobData == null)
            {
                throw new ArgumentNullException(nameof(sharepointCrawlJobData));
            }

            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            this.log = log ?? throw new ArgumentNullException(nameof(log));
            this.client = client ?? throw new ArgumentNullException(nameof(client));
            _sharePointCrawlJobData = sharepointCrawlJobData ?? throw new ArgumentNullException(nameof(sharepointCrawlJobData));

            // TODO use info from sharepointCrawlJobData to instantiate the connection
            client.BaseUrl = new Uri(BaseUri);
            client.AddDefaultParameter("api_key", sharepointCrawlJobData.Url, ParameterType.QueryString);
        }

        private async Task<T> GetAsync<T>(string url)
        {
            var request = new RestRequest(url, Method.GET);

            var response = await client.ExecuteTaskAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                var diagnosticMessage = $"Request to {client.BaseUrl}{url} failed, response {response.ErrorMessage} ({response.StatusCode})";
                log.Error(() => diagnosticMessage);
                throw new InvalidOperationException($"Communication to jsonplaceholder unavailable. {diagnosticMessage}");
            }

            var data = JsonConvert.DeserializeObject<T>(response.Content);

            return data;
        }

        public AccountInformation GetAccountInformation()
        {
            //TODO - return some unique information about the remote data source
            // that uniquely identifies the account
            return new AccountInformation("", ""); 
        }

        public IEnumerable<T> Get<T>(string value)
        {
            DateTimeOffset lastCrawlFinishTime;
            if (_sharePointCrawlJobData.LastCrawlFinishTime == DateTimeOffset.Parse("1/1/0001 12:00:00 AM +00:00"))
            {
                lastCrawlFinishTime = DateTimeOffset.Parse("01/01/1753 00:00:00");
            }
            else
            {
                lastCrawlFinishTime = _sharePointCrawlJobData.LastCrawlFinishTime;
            }

            var filter = $"(createdon ge {lastCrawlFinishTime:yyyy-MM-ddThh:mm:ssZ} or modifiedon ge {lastCrawlFinishTime:yyyy-MM-ddThh:mm:ssZ})";

            var url = _sharePointCrawlJobData.Url;
            //TODO replace with values from config
            var token = "";

            if (_sharePointCrawlJobData.DeltaCrawlEnabled)
            {
                url = _sharePointCrawlJobData.Url + string.Format("/api/data/v9.1/{0}?$filter={1}", value, filter);
            }

            ResultList<T> resultList = null;

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.Timeout = new TimeSpan(0, 2, 0);
                httpClient.DefaultRequestHeaders.Add("Prefer", "odata.maxpagesize=100");
                httpClient.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
                httpClient.DefaultRequestHeaders.Add("OData-Version", "4.0");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = httpClient.GetAsync(url).Result;
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //TODO: add try token refresh
                }
                else if (responseMessage.StatusCode != HttpStatusCode.OK)
                {
                    //TODO log error
                }


                resultList = JsonConvert.DeserializeObject<ResultList<T>>(content, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                if (resultList?.Value != null)
                {
                    foreach (var item in resultList.Value)
                        yield return item;
                }
            }
        }
    }
}
