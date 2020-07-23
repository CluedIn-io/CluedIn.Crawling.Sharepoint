using System.Collections.Generic;

using CluedIn.Core.Crawling;
using CluedIn.Crawling.SharePoint.Core;
using CluedIn.Crawling.SharePoint.Infrastructure.Factories;

namespace CluedIn.Crawling.SharePoint
{
    public class SharePointCrawler : ICrawlerDataGenerator
    {
        private readonly ISharePointClientFactory clientFactory;
        public SharePointCrawler(ISharePointClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public IEnumerable<object> GetData(CrawlJobData jobData)
        {
            if (!(jobData is SharePointCrawlJobData sharepointcrawlJobData))
            {
                yield break;
            }

            var client = clientFactory.CreateNew(sharepointcrawlJobData);

            //retrieve data from provider and yield objects
            
        }       
    }
}
