using Automation.Core.Selenium.Config;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Automation.Core.Selenium.Base
{
    public class TestInitialiseHook:Steps
    {
        public void InitialiseSettings()
        {
            ConfigReader.SetFrameworkSettings();
        }
    }
}
