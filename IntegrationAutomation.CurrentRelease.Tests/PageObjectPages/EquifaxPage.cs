using System;
using Automation.Core.Selenium.Base;
using IntegrationAutomation.CurrentRelease.Tests.PageObjectPages.GenericObjects;
using IntegrationAutomation.CurrentRelease.Tests.StepDefinitions;
using Should;

namespace IntegrationAutomation.PreviousRelease.Tests.PageObjectPages
{
    public class EquifaxPage:BasePage
    {
        private GenericPage GenericPage => new GenericPage();
        
        public void RunCreditReport(string creditName)
        {
            //Click equifax checkbox
            GenericPage.GetCreditType(creditName).Click();
            
            //Click "run selected report" button to initiate 
            ButtonSteps.SmartClick("runSelectedReports()");
        }
         public void RunBusinessAndIndividualCreditReport(string businessCredit, string consumerCredit)
        {
            //Click equifax checkbox
            GenericPage.GetCreditType(businessCredit).Click();
            GenericPage.GetCreditType(consumerCredit).Click();
            
            //Click "run selected report" button to initiate 
            ButtonSteps.SmartClick("runSelectedReports()");
        }
        
        public void RunMultipleCreditReports(string creditName)
        {
            //Click equifax checkbox
            GenericPage.GetMultipleCreditTypes(creditName,1).Click();
            GenericPage.GetMultipleCreditTypes(creditName,2).Click();
            
            //Click "run selected report" button to initiate 
            ButtonSteps.SmartClick("runSelectedReports()");
        }

        public void VerifyCurrentDate(string creditType)
        {
            var currentDate = DateTime.Now.ToString("M/d/yyyy");
            GenericPage.GetTableRowDataByXPath(creditType, currentDate).WaitUntilTextIsVisible(currentDate);
            GenericPage.GetTableRowDataByXPath(creditType,currentDate).GetText().ShouldEqual(currentDate);
        }
        
        public void VerifyMultipleCurrentDates(string creditType)
        {
            var currentDate = DateTime.Now.ToString("M/d/yyyy");
            GenericPage.GetMultTableRowDataByXPath(creditType, currentDate, 1).WaitUntilTextIsVisible(currentDate);
            GenericPage.GetMultTableRowDataByXPath(creditType,currentDate,1).GetText().ShouldEqual(currentDate);
            GenericPage.GetMultTableRowDataByXPath(creditType,currentDate,2).GetText().ShouldEqual(currentDate);
        }

        public void VerifyStatus(string creditType, string status)
        {
            GenericPage.GetTableRowDataByXPath(creditType, status).WaitUntilTextIsVisible(status); 
            GenericPage.GetTableRowDataByXPath(creditType,status).GetText().ShouldEqual(status);
        }
        
        public void VerifyMultipleStatus(string creditType, string status)
        {
            GenericPage.GetMultTableRowDataByXPath(creditType, status,1).WaitUntilTextIsVisible(status); 
            GenericPage.GetMultTableRowDataByXPath(creditType,status,1).GetText().ShouldEqual(status);
            GenericPage.GetMultTableRowDataByXPath(creditType,status,2).GetText().ShouldEqual(status);
        }
        public void ReportType(string reportName)
        {
            GenericPage.GetLabelByText(reportName).WaitUntilTextIsVisible(reportName);
            GenericPage.GetLabelByText(reportName).IsDisplayed().ShouldBeTrue("Report type is not displayed");
            GenericPage.GetLabelByText(reportName).GetText().ShouldEqual(reportName);
        }
        
        public void MultipleReportTypes(string reportName)
        {
            GenericPage.GetMultiElementsByText(reportName, 1).WaitUntilTextIsVisible(reportName);
            GenericPage.GetMultiElementsByText(reportName, 1).IsDisplayed().ShouldBeTrue($"{reportName} is not displayed");
            GenericPage.GetMultiElementsByText(reportName, 2).GetText().ShouldEqual(reportName);
        }
                

        public void validateDate(string creditType, string text)
        {
            GenericPage.GetTableRowDataByXPath(creditType,text).WaitUntilTextIsVisible(text);
            GenericPage.GetTableRowDataByXPath(creditType,text).IsDisplayed().ShouldBeTrue($"{text} is not displayed");
            GenericPage.GetTableRowDataByXPath(creditType,text).GetText().ShouldEqual(text);
        }
    }
}