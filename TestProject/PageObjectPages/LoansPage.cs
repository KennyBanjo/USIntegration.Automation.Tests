using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core.Selenium.APIHandler;
using Automation.Core.Selenium.Base;
using Automation.Core.Selenium.ExtensionMethods;
using IntegrationAutomation.CurrentRelease.Tests.PageObjectPages.GenericObjects;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using RestSharp;
using Selenium.Essentials;
using SeleniumExtras.PageObjects;
using Should;

namespace IntegrationAutomation.CurrentRelease.Tests.PageObjectPages
{
    public class LoansPage:BasePage
    {
        private GenericPage GenericPage => new GenericPage();
        private  List<string> _loanId;

        [FindsBy(How = How.XPath, Using = "//*[contains(@role, 'tabpanel')]//iframe")]
        private readonly IWebElement LoanIframe;

        [FindsBy(How = How.XPath, Using = "(//span[contains(text(),'Verifications Checklist')])[2]")]
        private readonly IWebElement VerificationChecklist;

        [FindsBy(How = How.XPath, Using = "//button[@name='Delete']")]
        private readonly IWebElement DeleteButton;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Delete')]")]
        private readonly IWebElement ModalDeleteButton;
        
        public void SwitchToLoanIFrame()
        {
            LoanIframe.WaitUntilElementCssDisplayed(DriverContext.WebDriver);
            DriverContext.WebDriver.SwitchTo().Frame(LoanIframe);
        }

        public void ClickVerification()
        {
            VerificationChecklist.WaitUntilElementCssDisplayed(DriverContext.WebDriver);
            VerificationChecklist.IsDisplayed().ShouldBeTrue("verification checklist is not displayed");
            VerificationChecklist.ClickByJsExecutor();
        }

        public void DeleteLoan()
        {
            //Click loan tab
            DriverContext.WebDriver.Navigate().Refresh();
            GenericPage.GetTabByXPath("Loans").WaitUntilElementIsDisplayed();
            GenericPage.GetTabByXPath("Loans").IsDisplayed().ShouldBeTrue($"{"Loans"} is not displayed");
            GenericPage.GetTabByXPath("Loans").ClickByJsExecutor();
            
            //Search for loan
            GenericPage.GetTextFieldByxPath("LLC_BI__Loan__c-search-input").WaitUntilElementIsDisplayed();
            GenericPage.GetTextFieldByxPath("LLC_BI__Loan__c-search-input").IsDisplayed().ShouldBeTrue($" Loan search-input is not displayed");
            GenericPage.GetTextFieldByxPath("LLC_BI__Loan__c-search-input").JsEnterText("BusinessLoan_TestLoan");
            GenericPage.GetTextFieldByxPath("LLC_BI__Loan__c-search-input").Enter();

            //Click on loan
            GenericPage.GetLabelByXPath("BusinessLoan_TestLoan").IsDisplayed().ShouldBeTrue($"BusinessLoan_TestLoan is not displayed");
            GenericPage.GetLabelByXPath("BusinessLoan_TestLoan").ClickByJsExecutor();

            //Delete Loan
            DeleteButton.WaitUntilElementCssDisplayed(DriverContext.WebDriver);
            DeleteButton.Click();
            ModalDeleteButton.WaitUntilElementCssDisplayed(DriverContext.WebDriver);
            ModalDeleteButton.Click();
        }
    }
}
