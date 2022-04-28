using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Selenium.Base;
using Automation.Core.Selenium.ExtensionMethods;
using IntegrationAutomation.CurrentRelease.Tests.PageObjectPages.GenericObjects;

using OpenQA.Selenium;
using Selenium.Essentials;
using SeleniumExtras.PageObjects;
using Should;

namespace IntegrationAutomation.CurrentRelease.Tests.PageObjectPages.GenericObjects
{
    public class CommonActions:BasePage
    {
        private static GenericPage GenericPage => new GenericPage();
        
        
        [FindsBy(How = How.XPath, Using = "//input[@name='j_id0:configuration:j_id8:j_id14']")]
        private IWebElement EndPointUrl;

        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement saveButton;

        [FindsBy(How = How.XPath, Using = "//input[@value='Go Back']")]
        private IWebElement backButton;

        [FindsBy(How = How.CssSelector, Using = "[value='< Back To Relationship']")]
        private IWebElement BackToRelationshipBtn;

        public static IWebElement ButtonToClick(string buttonName)
        {
            return GenericPage.GetButtonByText(buttonName).GetElement();
        }
        
        public static void ClickButton(string buttonName)
        {
            ButtonToClick(buttonName).WaitUntilElementClickable();
            ButtonToClick(buttonName).Click();
        }


        public void ClickSalesForceTab(string elementName)
        {
            GenericPage.GetTabByXPath(elementName).WaitUntilElementIsDisplayed();
            GenericPage.GetTabByXPath(elementName).IsDisplayed().ShouldBeTrue($"{elementName} is not displayed");
            GenericPage.GetTabByXPath(elementName).ClickByJsExecutor();
        }

        public void EnterConfigurationName(string configName)
        {
            EndPointUrl.WaitUntilElementCssDisplayed(DriverContext.WebDriver);
            EndPointUrl.IsDisplayed().ShouldBeTrue("Configuration field is not displayed");
            EndPointUrl.EnterText(configName);
        }

        public void ClickSaveButton()
        {
            saveButton.IsDisplayed().ShouldBeTrue("save button is not displayed");
            saveButton.Click();
        }

        public void ClickBackToRelationship()
        {
            BackToRelationshipBtn.WaitUntilElementClickable();
            BackToRelationshipBtn.Click();
        }
        public void ClickBackButton()
        {
            backButton.IsDisplayed().ShouldBeTrue("Back button is not displayed");
            backButton.ClickByJsExecutor();
        }
        public void ClickConfigurationBackButton()
        {
            backButton.IsDisplayed().ShouldBeTrue("save button is not displayed");
            backButton.Click();
            GenericPage.GetFrameByXPath("accessibility title").WaitUntilElementIsDisplayed();
            GenericPage.GetFrameByXPath("accessibility title").IsDisplayed().ShouldBeTrue();
            GenericPage.GetFrameByXPath("accessibility title").SwitchToFrame();
        }


    }
}
