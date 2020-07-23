using Castle.Windsor;
using CluedIn.Core;
using CluedIn.Core.Providers;
using CluedIn.Crawling.SharePoint.Infrastructure.Factories;
using Moq;

namespace CluedIn.Provider.SharePoint.Unit.Test.SharePointProvider
{
    public abstract class SharePointProviderTest
    {
        protected readonly ProviderBase Sut;

        protected Mock<ISharePointClientFactory> NameClientFactory;
        protected Mock<IWindsorContainer> Container;

        protected SharePointProviderTest()
        {
            Container = new Mock<IWindsorContainer>();
            NameClientFactory = new Mock<ISharePointClientFactory>();
            var applicationContext = new ApplicationContext(Container.Object);
            Sut = new SharePoint.SharePointProvider(applicationContext, NameClientFactory.Object);
        }
    }
}
