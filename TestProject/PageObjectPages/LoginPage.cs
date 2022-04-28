using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Selenium.Base;
using Automation.Core.Selenium.ExtensionMethods;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace IntegrationAutomation.CurrentRelease.Tests.PageObjectPages
{
    public class LoginPage :BasePage
    {
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement Username;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement Password;

        [FindsBy(How = How.Id, Using = "Login")]
        private IWebElement Loginbtn;

        public LoginPage Login()
        {
            Username.WaitUntilElementVisible();
            Username.SendKeys("kenny.banjo@ncinopsomaster1.com");
            Password.WaitUntilElementVisible();
            Password.SendKeys("Bolajimi1time.");
            Loginbtn.Click();
            return new LoginPage();
        }
    }
}
