using System.Collections.Generic;
using CluedIn.Crawling.SharePoint.Core;

namespace CluedIn.Crawling.SharePoint.Integration.Test
{
  public static class SharePointConfiguration
  {
    public static Dictionary<string, object> Create()
    {
      return new Dictionary<string, object>
            {
                { SharePointConstants.KeyName.Url, "demo" }
            };
    }
  }
}
