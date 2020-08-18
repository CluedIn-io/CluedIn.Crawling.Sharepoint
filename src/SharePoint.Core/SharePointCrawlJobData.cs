using CluedIn.Core.Crawling;

namespace CluedIn.Crawling.SharePoint.Core
{
    public class SharePointCrawlJobData : CrawlJobData
    {
        public string ApiKey { get; set; }
        public string Url { get; set; }
        public bool DeltaCrawlEnabled { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
