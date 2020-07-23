using CluedIn.Core.Crawling;

namespace CluedIn.Crawling.SharePoint.Core
{
    public class SharePointCrawlJobData : CrawlJobData
    {
        public string Url { get; set; }
        public bool DeltaCrawlEnabled { get; set; }
    }
}
