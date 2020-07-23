using CluedIn.Core.Crawling;
using CluedIn.Crawling;
using CluedIn.Crawling.SharePoint;
using CluedIn.Crawling.SharePoint.Infrastructure.Factories;
using Moq;
using Should;
using Xunit;

namespace Crawling.SharePoint.Unit.Test
{
    public class SharePointCrawlerBehaviour
    {
        private readonly ICrawlerDataGenerator _sut;

        public SharePointCrawlerBehaviour()
        {
            var nameClientFactory = new Mock<ISharePointClientFactory>();

            _sut = new SharePointCrawler(nameClientFactory.Object);
        }

        [Fact]
        public void GetDataReturnsData()
        {
            var jobData = new CrawlJobData();

            _sut.GetData(jobData)
                .ShouldNotBeNull();
        }
    }
}
