using System;
using System.Collections.Generic;
using CluedIn.Core.Net.Mail;
using CluedIn.Core.Providers;

namespace CluedIn.Crawling.SharePoint.Core
{
    public class SharePointConstants
    {
        public struct KeyName
        {
            public const string Url = nameof(Url);
            public const string DeltaCrawlEnabled = nameof(DeltaCrawlEnabled);
        }

        // TODO Complete the following section
        // Please see https://cluedin-io.github.io/CluedIn.Documentation/docs/1-Integration/build-integration.html
        public const string CrawlerDescription = "SharePoint is a ... to be completed ...";
        public const string Instructions = "Provide authentication instructions here, if applicable";
        public const IntegrationType Type = IntegrationType.Cloud;
        public const string Uri = "http://www.sampleurl.com"; //Uri of remote tool if applicable

        // To change the icon see embedded resource
        // src\SharePoint.Provider\Resources\cluedin.png
        public const string IconResourceName = "Resources.cluedin.png";

        public static IList<string> ServiceType = new List<string> { "" };
        public static IList<string> Aliases = new List<string> { "" };
        public const string Category = "";
        public const string Details = "";
        public static AuthMethods AuthMethods = new AuthMethods()
        {
            token = new Control[]
            {
        // You can define controls to show in the GUI in order to authenticate with this integration
        //        new Control()
        //        {
        //            displayName = "API key",
        //            isRequired = false,
        //            name = "api",
        //            type = "text"
        //        }
            }
        };


        public const bool SupportsConfiguration = true;
        public const bool SupportsWebHooks = false;
        public const bool SupportsAutomaticWebhookCreation = true;

        public const bool RequiresAppInstall = false;
        public const string AppInstallUrl = null;
        public const string ReAuthEndpoint = null;

        #region Autogenerated constants
        public const string CodeOrigin = "SharePoint";
        public const string ProviderRootCodeValue = "SharePoint";
        public const string CrawlerName = "SharePointCrawler";
        public const string CrawlerComponentName = "SharePointCrawler";
        public static readonly Guid ProviderId = Guid.Parse("4dadd365-8628-4498-a845-34e2b85a59a2");
        public const string ProviderName = "SharePoint";

        


        public static readonly ComponentEmailDetails ComponentEmailDetails = new ComponentEmailDetails
        {
            Features = new Dictionary<string, string>
            {
                                       { "Tracking",        "Expenses and Invoices against customers" },
                                       { "Intelligence",    "Aggregate types of invoices and expenses against customers and companies." }
                                   },
            Icon = ProviderIconFactory.CreateUri(ProviderId),
            ProviderName = ProviderName,
            ProviderId = ProviderId,
            Webhooks = SupportsWebHooks
        };

        public static IProviderMetadata CreateProviderMetadata()
        {
            return new ProviderMetadata
            {
                Id = ProviderId,
                ComponentName = CrawlerName,
                Name = ProviderName,
                Type = Type.ToString(),
                SupportsConfiguration = SupportsConfiguration,
                SupportsWebHooks = SupportsWebHooks,
                SupportsAutomaticWebhookCreation = SupportsAutomaticWebhookCreation,
                RequiresAppInstall = RequiresAppInstall,
                AppInstallUrl = AppInstallUrl,
                ReAuthEndpoint = ReAuthEndpoint,
                ComponentEmailDetails = ComponentEmailDetails
            };
        }
        #endregion
    }
}
