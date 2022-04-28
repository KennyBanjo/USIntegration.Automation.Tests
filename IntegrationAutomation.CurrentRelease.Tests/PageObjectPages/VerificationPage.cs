using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Automation.Core.Selenium.Base;
using Automation.Core.Selenium.ExtensionMethods;
using IntegrationAutomation.CurrentRelease.Tests.PageObjectPages.GenericObjects;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Should;

namespace IntegrationAutomation.CurrentRelease.Tests.PageObjectPages
{
    public class VerificationPage:BasePage
    {
        private GenericPage GenericPage => new GenericPage();

        [FindsBy(How = How.XPath,
            Using =
                "//div[@class='iframe-parent slds-template_iframe slds-card']//iframe[@title='accessibility title']")]
        private IWebElement VerificationIframe;

        [FindsBy(How = How.XPath, Using = "//table[@class='lds-table']//tbody//tr//td[1]")]
        private IWebElement Checkbox;

        [FindsBy(How = How.XPath, Using = "//table[@class='lds-table']//tbody//tr//td[3]")]
        private IWebElement ReportType;

        [FindsBy(How = How.XPath, Using = "//table[@class='lds-table']//tbody//tr//td[4]")]
        private IWebElement Relationship;

        public void VerifyReportType(string reportType)
        {
            Thread.Sleep(10000);
            //DriverContext.WebDriver.SwitchTo().Frame(DriverContext.WebDriver.FindElement(By.XPath("//div[@class='iframe-parent slds-template_iframe slds-card']//iframe[@title='accessibility title']")));
            GenericPage.GetFrameByXPath("accessibility title").WaitUntilElementIsDisplayed();
            GenericPage.GetFrameByXPath("accessibility title").SwitchToFrame();
            //ReportType.WaitUntilElementClickable();
            //ReportType.Displayed.ShouldBeTrue("report type is not displayed");
            DriverContext.WebDriver.FindElement(By.XPath("//table[@class='lds-table']//tbody//tr//td[3]")).Displayed.ShouldBeTrue("Report not displayed");
            if (reportType == "Business EQUUK Credit")
            {
                DriverContext.WebDriver.FindElement(By.XPath("//table[@class='lds-table']//tbody//tr//td[3]")).Text.ShouldEqual(reportType);
            }
            else if (reportType == "Soft Credit Check")
            {
                DriverContext.WebDriver.FindElement(By.XPath("//table[@class='lds-table']//tbody//tr//td[3]")).Text.ShouldEqual(reportType);
            }
            else if (reportType == "Hard credit Check")
            {
                DriverContext.WebDriver.FindElement(By.XPath("//table[@class='lds-table']//tbody//tr//td[3]")).Text.ShouldEqual(reportType);
            }
        }

        public void ClickCheckBox()
        {
            Checkbox.WaitUntilElementVisible();
            Checkbox.IsDisplayed();
            Checkbox.Click();
        }
    }
}
