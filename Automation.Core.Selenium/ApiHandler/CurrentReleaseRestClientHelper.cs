using Automation.Core.Selenium.Config;
using RestSharp;

namespace Automation.Core.Selenium.APIHandler
{
    public sealed class CurrentReleaseRestClientHelper : ARestClient
    {
        public CurrentReleaseRestClientHelper()
        {
            GetToken(Settings.Username,Settings.ApiPassword,Settings.ClientId,Settings.ClientSecret);
        }
    }
}