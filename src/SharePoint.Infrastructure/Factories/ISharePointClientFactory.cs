using CluedIn.Crawling.SharePoint.Core;

namespace CluedIn.Crawling.SharePoint.Infrastructure.Factories
{
    public interface ISharePointClientFactory
    {
        SharePointClient CreateNew(SharePointCrawlJobData sharepointCrawlJobData);
    }
}
