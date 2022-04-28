using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Automation.Core.Selenium.Config
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            IConfigurationRoot configurationRoot = builder.Build();

            Settings.Url = configurationRoot.GetSection("testSettings").Get<TestSettings>().Url;
            Settings.QaFallUrl = configurationRoot.GetSection("testSettings").Get<TestSettings>().QaFallUrl;
            Settings.LoanUrl = configurationRoot.GetSection("testSettings").Get<TestSettings>().LoanUrl;
            Settings.QaFallLoanUrl = configurationRoot.GetSection("testSettings").Get<TestSettings>().QaFallLoanUrl;
            Settings.LinkLoanUrl = configurationRoot.GetSection("testSettings").Get<TestSettings>().LinkLoanUrl;
            Settings.QaFallLinkLoanUrl = configurationRoot.GetSection("testSettings").Get<TestSettings>().QaFallLinkLoanUrl;
            Settings.PreviousReleaseUsername = configurationRoot.GetSection("testSettings").Get<TestSettings>().PreviousReleaseUsername;
            Settings.PreviousReleasePassword = configurationRoot.GetSection("testSettings").Get<TestSettings>().PreviousReleasePassword;
            Settings.Username = configurationRoot.GetSection("testSettings").Get<TestSettings>().Username;
            Settings.ApiPassword = configurationRoot.GetSection("testSettings").Get<TestSettings>().ApiPassword;
            Settings.Password = configurationRoot.GetSection("testSettings").Get<TestSettings>().Password;
            Settings.QaFallUsername = configurationRoot.GetSection("testSettings").Get<TestSettings>().QaFallUsername;
            Settings.QaFallPassword = configurationRoot.GetSection("testSettings").Get<TestSettings>().QaFallPassword;
            Settings.QaFallApiPassword = configurationRoot.GetSection("testSettings").Get<TestSettings>().QaFallApiPassword;
            Settings.ApiUrl = configurationRoot.GetSection("testSettings").Get<TestSettings>().ApiUrl;
            Settings.QaFallApiUrl = configurationRoot.GetSection("testSettings").Get<TestSettings>().QaFallApiUrl;
            Settings.MiddlewareConfig =
                configurationRoot.GetSection("testSettings").Get<TestSettings>().MiddlewareConfig;
            Settings.QaFallMiddlewareConfig =
                configurationRoot.GetSection("testSettings").Get<TestSettings>().QaFallMiddlewareConfig;
            Settings.FileUpload = configurationRoot.GetSection("testSettings").Get<TestSettings>().FileUpload;
            Settings.Twenty7TecUrl = configurationRoot.GetSection("testSettings").Get<TestSettings>().Twenty7TecUrl;
            Settings.Twenty7TecUsername =
                configurationRoot.GetSection("testSettings").Get<TestSettings>().Twenty7TecUsername;
            Settings.Twenty7TecPassword =
                configurationRoot.GetSection("testSettings").Get<TestSettings>().Twenty7TecPassword;
            Settings.CompositesObjectUrl = configurationRoot.GetSection("testSettings").Get<TestSettings>()
                .CompositesObjectUrl;
            Settings.QaFallCompositesObjectUrl = configurationRoot.GetSection("testSettings").Get<TestSettings>()
                .QaFallCompositesObjectUrl;
            Settings.ClientId = configurationRoot.GetSection("testSettings").Get<TestSettings>().ClientId;
            Settings.ClientSecret = configurationRoot.GetSection("testSettings").Get<TestSettings>().ClientSecret;
            Settings.QaFallClientId = configurationRoot.GetSection("testSettings").Get<TestSettings>().QaFallClientId;
            Settings.QaFallClientSecret = configurationRoot.GetSection("testSettings").Get<TestSettings>().QaFallClientSecret;
        }
    }
}
