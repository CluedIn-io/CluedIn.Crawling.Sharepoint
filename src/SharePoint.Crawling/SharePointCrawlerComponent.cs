using CluedIn.Core;
using CluedIn.Crawling.SharePoint.Core;

using ComponentHost;

namespace CluedIn.Crawling.SharePoint
{
    [Component(SharePointConstants.CrawlerComponentName, "Crawlers", ComponentType.Service, Components.Server, Components.ContentExtractors, Isolation = ComponentIsolation.NotIsolated)]
    public class SharePointCrawlerComponent : CrawlerComponentBase
    {
        public SharePointCrawlerComponent([NotNull] ComponentInfo componentInfo)
            : base(componentInfo)
        {
        }
    }
}

