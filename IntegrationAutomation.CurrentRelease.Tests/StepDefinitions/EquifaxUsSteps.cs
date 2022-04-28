using System;
using System.Threading;
using Automation.Core.Selenium.APIHandler;
using Automation.Core.Selenium.Base;
using Automation.Core.Selenium.ComponentHelper;
using Automation.Core.Selenium.Config;
using Google.Protobuf;
using IntegrationAutomation.CurrentRelease.Tests.PageObjectPages;
using IntegrationAutomation.CurrentRelease.Tests.PageObjectPages.GenericObjects;
using IntegrationAutomation.CurrentRelease.Tests.StepDefinitions;
using IntegrationAutomation.PreviousRelease.Tests.PageObjectPages;
using NUnit.Framework;
using OpenQA.Selenium;
using Should;
using TechTalk.SpecFlow;
using RestSharp;
using Selenium.Essentials;

namespace IntegrationAutomation.PreviousRelease.Tests.StepDefinitions
{
    [Binding]
    public class EquifaxUsSteps : BasePage
    {
        private static GenericPage GenericPage => new GenericPage();

        [When(@"I click on the '(.*)' tab")]
        public void WhenIClickOnTheTab(string tabName)
        {
            Thread.Sleep(2000);
            GenericPage.GetTabByXPath(tabName).WaitUntilElementIsDisplayed();
            GenericPage.GetTabByXPath(tabName).IsDisplayed().ShouldBeTrue($"{tabName} is not displayed");
            GenericPage.GetTabByXPath(tabName).ClickByJsExecutor();
        }

        [When(@"I search for '(.*)' in the '(.*)' textfield")]
        public void WhenISearchForInTheTextfield(string searchItem, string searchField)
        {
            Thread.Sleep(2000);
            GenericPage.GetTextFieldByxPath(searchField).WaitUntilElementIsDisplayed();
            GenericPage.GetTextFieldByxPath(searchField).IsDisplayed().ShouldBeTrue($"{searchField} is not displayed");
            TextfieldSteps.SmartEnterText(searchItem, searchField);
        }

        [When(@"I click on '(.*)'")]
        public void WhenIClickOn(string elementName)
        {
            Thread.Sleep(2000);
            GenericPage.GetLabelByXPath(elementName).IsDisplayed().ShouldBeTrue($"{elementName} is not displayed");
            GenericPage.GetLabelByXPath(elementName).ClickByJsExecutor();
        }

        [When(@"I click on the '(.*)' button")]
        public void  WhenIClickOnTheButton(string elementName)
        {
            ButtonSteps.SmartClick(elementName);
        }

        [When(@"I click the '(.*)' button")]
        public void WhenIClickTheButton(string buttonName)
        {
            //Thread.Sleep(3000);
            GenericPage.GetButtonByClass(buttonName).WaitUntilElementIsDisplayed();
            GenericPage.GetButtonByClass(buttonName).Click();
        }

        [Then(@"I should see '(.*)'")]
        public void ThenIShouldSeeInTheResult(string elementName)
        {
            Thread.Sleep(2000);
            GenericPage.GetLabelByXPath(elementName).OnfidoWaitUntilElementIsDisplayed();
            GenericPage.GetLabelByXPath(elementName).IsDisplayed().ShouldBeTrue($"{elementName} is not displayed");
        }

        [Then(@"I should see '(.*)' under report")]
        public void ThenIShouldSeeUnderReport(string reportName)
        {
            CurrentPage = GetInstance<EquifaxPage>();
            CurrentPage.As<EquifaxPage>().ReportType(reportName);
        }
        
        [Then(@"I should see '(.*)' under report for both accounts")]
        public void ThenIShouldSeeUnderReportForBothAccounts(string reportName)
        {
            CurrentPage = GetInstance<EquifaxPage>();
            CurrentPage.As<EquifaxPage>().ReportType(reportName);
        }

        // [When(@"I click the checkbox for equifax")]
        // public void WhenIClickTheCheckbox()
        // {
        //     GenericPage.GetTableRowDataByXPath(2,1).Click();
        //     // GenericPage.GetLabelByText("Soft Equifax Credit").ClickByJsExecutor();
        // }

        [Then(@"the modal '(.*)' should be displayed")]
        public void ThenTheModalShouldBeDisplayed(string modalName)
        {
            Thread.Sleep(2000); 
            GenericPage.GetModalNameByXPath(modalName).WaitUntilElementIsDisplayed();
            GenericPage.GetModalNameByXPath(modalName).IsDisplayed().ShouldBeTrue($"{modalName} is not displayed");
        }

        [When(@"I click the '(.*)' modal button")]
        public void WhenIClickTheModalButton(string buttonName)
        {
            Thread.Sleep(2000);
            GenericPage.GetModalButtonByXPath(buttonName).WaitUntilElementIsDisplayed();
            GenericPage.GetModalButtonByXPath(buttonName).IsDisplayed().ShouldBeTrue($"{buttonName}");
            GenericPage.GetModalButtonByXPath(buttonName).Click();
        }

        [Then(@"the '(.*)' status should display '(.*)'")]
        public void ThenTheStatusShouldRead(string creditType, string status)
        {
            CurrentPage = GetInstance<EquifaxPage>();
            CurrentPage.As<EquifaxPage>().VerifyStatus(creditType, status);
        }

        [Then(@"the '(.*)' report date should equal today's date")]
        public void ThenTheReportDateShouldEqualTodaysDate(string creditType )
        {
            CurrentPage = GetInstance<EquifaxPage>();
            CurrentPage.As<EquifaxPage>().VerifyCurrentDate(creditType);
        }

        [Then(@"the '(.*)' actions column should display '(.*)'")]
        public void ThenTheColumnShouldDisplay(string creditType, string text)
        {
            // GenericPage.GetTableHeadsByXPath(6).GetText().ShouldEqual($"{column}");
            GenericPage.GetTableRowDataByXPath(creditType,text).WaitUntilTextIsVisible(text);
            GenericPage.GetTableRowDataByXPath(creditType,text).IsDisplayed().ShouldBeTrue($"{text} is not displayed");
            GenericPage.GetTableRowDataByXPath(creditType,text).GetText().ShouldEqual(text);
        }
        
        // [When(@"I click all the checkboxes")]
        // public void WhenIClickAllTheCheckboxForEquifax()
        // {
        //     GenericPage.GetTableRowDataByXPath(1, 1).Click();
        //     GenericPage.GetTableRowDataByXPath(2,1).Click();
        //     GenericPage.GetTableRowDataByXPath(3,1).Click();
        // }
        
        // [When(@"I click the checkbox in row '(.*)'")]
        // public void WhenIClickTheCheckboxForEquifax(int rowNumber)
        // {
        //     GenericPage.GetTableRowDataByXPath(rowNumber,1).Click();
        // }

        [Then(@"all statuses should read '(.*)'")]
        public void ThenAllEquifaxStatusShouldReadInfileOrNeedsReviewOrPass(string status)
        {
            // GenericPage.GetTableRowDataByXPath(1,2).WaitUntilTextIsVisible(status);
            // var status1 = GenericPage.GetTableRowDataByXPath(1,2).GetText();
            // GenericPage.GetTableRowDataByXPath(1,2).GetText().ShouldEqual(status);
            //
            // GenericPage.GetTableRowDataByXPath(2,2).WaitUntilTextIsVisible(status);
            // var status2 = GenericPage.GetTableRowDataByXPath(2,2).GetText();
            // GenericPage.GetTableRowDataByXPath(2,2).GetText().ShouldEqual(status);
            //
            // GenericPage.GetTableRowDataByXPath(3,2).WaitUntilTextIsVisible(status);
            // var status3 = GenericPage.GetTableRowDataByXPath(3,2).GetText();
            // GenericPage.GetTableRowDataByXPath(3,2).GetText().ShouldEqual(status);        
        }
        
        // [Then(@"the status in row '(.*)' should read '(.*)'")]
        // public void TheStatusInRowShouldRead(int rowNumber, string status)
        // {
        //     GenericPage.GetTableRowDataByXPath(rowNumber,2).WaitUntilTextIsVisible(status);
        //     var status1 = GenericPage.GetTableRowDataByXPath(1,2).GetText();
        //     GenericPage.GetTableRowDataByXPath(rowNumber,2).GetText().ShouldEqual(status);
        // }

        // [Then(@"all report dates should equal today's date")]
        // public void ThenAllEquifaxReportDateShouldEqualTodaysDate()
        // {
        //     var currentDate = DateTime.Now.ToString("MM/dd/yyyy");
        //     GenericPage.GetTableRowDataByXPath(1,5).GetText().ShouldEqual(currentDate);
        //     GenericPage.GetTableRowDataByXPath(2,5).GetText().ShouldEqual(currentDate);
        //     GenericPage.GetTableRowDataByXPath(3,5).GetText().ShouldEqual(currentDate);
        // }
        
        // [Then(@"the report date in row '(.*)' should equal today's date")]
        // public void ThenTheEquifaxReportDateShouldEqualTodaysDate(int rowNumber)
        // {
        //     var currentDate = DateTime.Now.ToString("MM/dd/yyyy");
        //     GenericPage.GetTableRowDataByXPath(rowNumber, 5).GetText().ShouldEqual(currentDate);
        // }

        // [Then(@"the '(.*)' columns should display '(.*)'")]
        // public void ThenTheEquifaxActionsColumnsShouldDisplayViewReport(string column, string text )
        // {
        //     GenericPage.GetTableHeadsByXPath(6).GetText().ShouldEqual($"{column}");
        //     GenericPage.GetTableRowDataByXPath(1,6).IsDisplayed().ShouldBeTrue($"{text} is not displayed");
        //     GenericPage.GetTableRowDataByXPath(1,6).GetText().ShouldEqual(text);
        //     GenericPage.GetTableRowDataByXPath(2,6).IsDisplayed().ShouldBeTrue($"{text} is not displayed");
        //     GenericPage.GetTableRowDataByXPath(2,6).GetText().ShouldEqual(text);
        //     GenericPage.GetTableRowDataByXPath(3,6).IsDisplayed().ShouldBeTrue($"{text} is not displayed");
        //     GenericPage.GetTableRowDataByXPath(3,6).GetText().ShouldEqual(text);
        // }
        
        // [Then(@"the '(.*)' column in row '(.*)' should display '(.*)'")]
        // public void ThenTheColumnShouldDisplay(string column, int rowNumber,string text )
        // {
        //     GenericPage.GetTableHeadsByXPath(6).GetText().ShouldEqual($"{column}");
        //     GenericPage.GetTableRowDataByXPath(rowNumber,6).IsDisplayed().ShouldBeTrue($"{text} is not displayed");
        //     GenericPage.GetTableRowDataByXPath(rowNumber,6).GetText().ShouldEqual(text);
        // }

        // [Then(@"the Fico score should be lower than '(.*)'")]
        // public void ThenTheFicoScoreShouldLowerThen250(int score)
        // {
        //     var element = GenericPage.GetTableRowDataByXPath(1, 5).GetText();
        //     var ficoScore = Convert.ToInt32(element);
        //     Assert.LessOrEqual(ficoScore, score);
        // }

        // [Then(@"the Fico score should be higher than '(.*)'")]
        // public void ThenTheFicoScoreShouldBeHigherThen250(string score)
        // {
        //     var element = GenericPage.GetTableRowDataByXPath(1, 5).GetText();
        //     var ficoScore = Convert.ToInt32(element);
        //     Assert.GreaterOrEqual(ficoScore, score);
        // }

        [Then(@"I see '(.*)' under relationship in row '(.*)'")]
        public void ThenISeeUnderRelationshipInRow1(string creditType, string name)
        {
            GenericPage.GetTableRowDataByXPath(creditType,name).WaitUntilElementIsDisplayed();
            GenericPage.GetTableRowDataByXPath(creditType,name).IsDisplayed().ShouldBeTrue("Report type is not displayed");
            GenericPage.GetTableRowDataByXPath(creditType,name).GetText().ShouldEqual(name);
        }

        [Given(@"I have updated the equifax review account credentials")]
        public void GivenIHaveUpdatedTheEquifaxReviewAccountCredentials()
        {
            CurrentReleaseRestClientHelper currentReleaseRestClientHelper = new CurrentReleaseRestClientHelper();
            var client = new RestClient("https://emeaqa.my.salesforce.com/services/data/v50.0/composite/sobjects");
            client.Timeout = -1;
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", currentReleaseRestClientHelper.token.getCredential());
            request.AddParameter("application/json", "{\n\t \"allOrNone\" : false,\n   \"records\" : [{\n      \"attributes\" : {\"type\" : \"Contact\"},\n      \"id\" : \"0034K00000JWxg3QAD\",\n      \"FirstName\": \"EMILLIO\",\n\t  \"LastName\": \"OSMOND\",\n\t  \"Birthdate\": \"1966-12-08\", \n      \"MailingStreet\": \"107 DOWNHAM ROAD\",\n      \"MailingCity\": \"ELY\",\n      \"MailingPostalCode\": \"CB6 1AF\"\n    }]\n}",  ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            LogHelper.Info(response.Content);
        }
        
        // [Then(@"the equifax credit score should be higher than '(.*)'")]
        // public void ThenTheCreditScoreShouldBeHigherThanCreditScore370(string creditScore)
        // {
        //     CurrentPage = GetInstance<PortalPage>();
        //     CurrentPage.As<PortalPage>().VerifyHighEquifaxScore(creditScore);
        // }
        
        // [Then(@"the equifax credit score should be lower than '(.*)'")]
        // public void ThenTheCreditScoreShouldBeLowerThan370(string creditScore)
        // {
        //     CurrentPage = GetInstance<PortalPage>();
        //     CurrentPage.As<PortalPage>().VerifyLowEquifaxScore(creditScore);
        // }

        [When(@"I navigate to verification on a business account")]
        public void WhenINavigateToTheBusinessAccount()
        {
            var url = "https://bankr-3316--data--nfuse.visualforce.com/apex/Verifications?id=" + CurrentReleaseDataloader.Id[0];
            DriverContext.WebDriver.Url = url;
            
            // LoginSteps.WhenILoginAsSystemAdministrator();
        }

        [Given(@"I have navigated to plugin configuration")]
        public void GivenIHaveNavigatedToPluginConfiguration()
        {
            var pluginConfig = "https://bankr-3316--data--nfuse.visualforce.com/apex/pluginconfiguration";
            DriverContext.WebDriver.Url = pluginConfig;
            
            //Login to Qa org
            LoginSteps.WhenILoginAsSystemAdministrator();
        }
        

        [When(@"I navigate to verification from a '(.*)' loan")]
        public void WhenINavigateToVerificationFromLoan(string accountType)
        {
            var businessLoan = "https://bankr-3316--data--llc-bi.visualforce.com/apex/llc_bi__Loan?app=loan.verify-credit&id=" +
                               CurrentReleaseDataloader.LoanId[0];
            
             var consumerLoan = "https://bankr-3316--data--llc-bi.visualforce.com/apex/llc_bi__Loan?app=loan.verify-credit&id=" +
                      CurrentReleaseDataloader.LoanId[0];
             
            if (accountType == "Business")
            {
                DriverContext.WebDriver.Url = businessLoan;
            }
            else if (accountType == "Consumer" )
            {
                DriverContext.WebDriver.Url = consumerLoan;
            }
                
            
            // LoginSteps.WhenILoginAsSystemAdministrator();
        }

        [When(@"I navigate to the contact record for '(.*)'")]
        public void WhenINavigateToTheContactRecordForVerenaisiHayter(string contact)
        {
            var contactRecord = $"https://emeaqaspring2021.my.salesforce.com/{contact}";
            DriverContext.WebDriver.Url = contactRecord;
        }

        [When(@"I navigate the the relationship record for EMILLIO OSMOND")]
        public void WhenINavigateTheTheRelationshipRecord()
        {
            var relationshipRecord = "https://emeaqaspring2021--nfuse.visualforce.com/apex/Verifications?id=" + CurrentReleaseDataloader.Id[5];
            DriverContext.WebDriver.Url = relationshipRecord;
        }

        [When(@"I navigate to verification on the relationship record for Wally Sallway")]
        public void WhenINavigateTheTheRelationshipRecordForWallySallway()
        {
            var relationshipRecord = "https://emeaqaspring2021--nfuse.visualforce.com/apex/Verifications?id=" + CurrentReleaseDataloader.Id[4];
            DriverContext.WebDriver.Url = relationshipRecord;
        }

        [When(@"I click the back to relationship button")]
        public void WhenIClickTheBackToRelationshipButton()
        {
            CurrentPage = GetInstance<CommonActions>();
            CurrentPage.As<CommonActions>().ClickBackToRelationship();
        }

        [When(@"I go to the verification page for missing SS account")]
        public void WhenIGoToTheVerificationPageForNealSpringThorpe()
        {
            var relationshipRecord = "https://bankr-3316--data--nfuse.visualforce.com/apex/Verifications?id=" + CurrentReleaseDataloader.Id[2];
            DriverContext.WebDriver.Url = relationshipRecord;
            
            LoginSteps.WhenILoginAsSystemAdministrator();
        }

        [When(@"I navigate to the verification page for Emanuel Harrison")]
        public void WhenINavigateToTheVerificationPageForEmanuelHarrison()
        {
            var relationshipRecord = "https://emeaqaspring2021--nfuse.visualforce.com/apex/Verifications?id=" + CurrentReleaseDataloader.Id[9];
            DriverContext.WebDriver.Url = relationshipRecord;
        }

        [When(@"I navigate to the verification page for Paxton Access Ltd")]
        public void WhenINavigateToTheVerificationPageForPaxtonAccessLtd()
        {
            var relationshipRecord = "https://emeaqaspring2021--nfuse.visualforce.com/apex/Verifications?id=" + CurrentReleaseDataloader.Id[3];
            DriverContext.WebDriver.Url = relationshipRecord;
        }

        [When(@"I navigate to the relationship record for Imagination Technologies")]
        public void WhenINavigateToTheRelationshipRecordForImaginationTechnologies()
        {
            var relationshipRecord = $"https://emeaqaspring2021.my.salesforce.com/" + CurrentReleaseDataloader.Id[0];
            DriverContext.WebDriver.Url = relationshipRecord;
            
            //Login to Qa org
           LoginSteps.WhenILoginAsSystemAdministrator();
        }

        [When(@"I click on the account save button")]
        public void WhenIClickOnTheAccountSaveButton()
        {
            GenericPage.GetButtonByXPathText("SaveEdit").WaitUntilElementIsDisplayed();
             GenericPage.GetButtonByXPathText("SaveEdit").Click();
            // GenericPage.GetButtonByXPathText("SaveEdit").
        }

        [Then(@"the tax identification number field should contain '(.*)'")]
        public void ThenTheTaxIdentificationNumberFieldShouldContainXxx1623(string fieldContent)
        {
            var field = DriverContext.WebDriver.FindElement(
                By.XPath($"//lightning-formatted-text[contains(text(),'{fieldContent}')]"));
            field.WaitUntilElementVisible(DriverContext.WebDriver);
            field.Text.ShouldEqual(fieldContent);
        }

        [When(@"I navigate to the credit report invoker url")]
        public void WhenINavigateToTheCreditReportInvokerUrl()
        {
            string url =
                "https://emeaqaspring2021--c.visualforce.com/flow/runtime.apexp?flowDevName=CreditReportInvoker&flowVersionId=3014K000000Q71R";
            DriverContext.WebDriver.Url = url;
        }

        [When(@"I select '(.*)' from the '(.*)' dropdown")]
        public void WhenISelectFromTheDropdown(string provider, string providerInput)
        {
            GenericPage.GetDropdownByXpath(providerInput).WaitUntilElementIsDisplayed();
            GenericPage.GetDropdownByXpath(providerInput).SelectByValue(provider);
        }

        [When(@"I enter the entity id in the '(.*)' textfield")]
        public void WhenIEnterTheEntityIdInTheTextfield(string entityIdInput)
        {
            GenericPage.GetTextFieldByxPath(entityIdInput).EnterText(CurrentReleaseDataloader.Id[4]);
        }

        [Then(@"I should see the error message '(.*)'")]
        public void ThenIShouldSeeTheErrorMessage(string errorMsg)
        {
            GenericPage.GetErrorMsgByXPath(errorMsg).IsDisplayed().ShouldBeTrue($"{errorMsg} is not displayed");
        }

        [When(@"I run the '(.*)' report")]
        public void WhenIRunTheEquifaxCreditReport(string reportType)
        {
            CurrentPage = GetInstance<EquifaxPage>();
            CurrentPage.As<EquifaxPage>().RunCreditReport(reportType);
        }

        [Given(@"I have navigated to an invalid SS consumer account")]
        public void GivenIHaveNavigatedToTheAccountId()
        {
            var url = $"https://bankr-3316--data--nfuse.visualforce.com/apex/Verifications?id={CurrentReleaseDataloader.Id[2]}";
            DriverContext.WebDriver.Url = url;
            // LoginSteps.WhenILoginAsSystemAdministrator();
        }

        [Given(@"The '(.*)' plugin is activated")]
        public void GivenThePluginIsActivated(string pluginName)
        {
            var pluginConfig = "https://bankr-3316--data--nfuse.visualforce.com/apex/pluginconfiguration";
            DriverContext.WebDriver.Url = pluginConfig;
            LoginSteps.WhenILoginAsSystemAdministrator();
            
            GenericPage.GetPluginCheckboxByXPath(pluginName).WaitUntilElementIsDisplayed();
            GenericPage.GetPluginCheckboxByXPath(pluginName).WaitUntilElementIsClickable();
            if (GenericPage.GetPluginCheckboxByXPath(pluginName).DeSelected())
            {
                GenericPage.GetPluginCheckboxByXPath(pluginName).Check();
            }
        }

        [When(@"I navigate to a consumer account")]
        public void WhenINavigateToAConsumerAccount()
        {
            var url = $"https://bankr-3316--data--nfuse.visualforce.com/apex/Verifications?id={CurrentReleaseDataloader.Id[1]}";
            DriverContext.WebDriver.Url = url;
        }

        [When(@"I run all the '(.*)' reports")]
        public void WhenIRunAllTheReport(string creditType)
        {
            CurrentPage = GetInstance<EquifaxPage>();
            CurrentPage.As<EquifaxPage>().RunMultipleCreditReports(creditType);
        }

        [Then(@"all '(.*)' statuses should read '(.*)'")]
        public void ThenAllStatusesShouldRead(string creditName, string status)
        {
            CurrentPage = GetInstance<EquifaxPage>();
            CurrentPage.As<EquifaxPage>().VerifyMultipleStatus(creditName, status);
        }

        [Then(@"all '(.*)' report dates should equal today's date")]
        public void ThenAllReportDatesShouldEqualTodaysDate(string creditType)
        {
            CurrentPage = GetInstance<EquifaxPage>();
            CurrentPage.As<EquifaxPage>().VerifyMultipleCurrentDates(creditType);
        }

        [When(@"I run both '(.*)' and '(.*)' report")]
        public void WhenIRunBothAndReport(string businessCredit, string consumerCredit)
        {
            CurrentPage = GetInstance<EquifaxPage>();
            CurrentPage.As<EquifaxPage>().RunBusinessAndIndividualCreditReport(businessCredit, consumerCredit);
        }
    }
}

