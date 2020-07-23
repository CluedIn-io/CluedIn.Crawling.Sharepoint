using CluedIn.Crawling.SharePoint.Core;

namespace CluedIn.Crawling.SharePoint
{
    public class SharePointCrawlerJobProcessor : GenericCrawlerTemplateJobProcessor<SharePointCrawlJobData>
    {
        public SharePointCrawlerJobProcessor(SharePointCrawlerComponent component) : base(component)
        {
        }
    }
}
