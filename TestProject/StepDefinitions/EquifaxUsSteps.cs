using System;
using System.Threading;
using Automation.Core.Selenium.APIHandler;
using Automation.Core.Selenium.Base;
using Automation.Core.Selenium.ComponentHelper;
using IntegrationAutomation.CurrentRelease.Tests.PageObjectPages.GenericObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using Should;
using TechTalk.SpecFlow;
using RestSharp;
using Selenium.Essentials;

namespace IntegrationAutomation.CurrentRelease.Tests.StepDefinitions
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
        public void ThenIShouldSeeUnderReport(string elementName)
        {
            GenericPage.GetTableRowDataByXPath(1,3).WaitUntilTextIsVisible(elementName);
            GenericPage.GetTableRowDataByXPath(1,3).IsDisplayed().ShouldBeTrue("Report type is not displayed");
            GenericPage.GetTableRowDataByXPath(1,3).GetText().ShouldEqual(elementName);
        }

        [When(@"I click the checkbox for equifax")]
        public void WhenIClickTheCheckbox()
        {
            GenericPage.GetTableRowDataByXPath(1,1).Click();
        }

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

        [Then(@"the status should display '(.*)'")]
        public void ThenTheStatusShouldRead(string element)
        {
            GenericPage.GetTableRowDataByXPath(1,2).WaitUntilTextIsVisible(element); 
            GenericPage.GetTableRowDataByXPath(1,2).GetText().ShouldEqual(element);
        }

        [Then(@"the report date should equal today's date")]
        public void ThenTheReportDateShouldEqualTodaysDate()
        {
            var currentDate = DateTime.Now.ToString("MM/dd/yyyy");
            GenericPage.GetTableRowDataByXPath(1,5).WaitUntilTextIsVisible(currentDate);
            GenericPage.GetTableRowDataByXPath(1,5).GetText().ShouldEqual(currentDate);
        }

        [Then(@"the '(.*)' column should display '(.*)'")]
        public void ThenTheColumnShouldDisplay(string column, string text)
        {
            GenericPage.GetTableHeadsByXPath(6).GetText().ShouldEqual($"{column}");
            GenericPage.GetTableRowDataByXPath(1,6).IsDisplayed().ShouldBeTrue($"{text} is not displayed");
            GenericPage.GetTableRowDataByXPath(1,6).GetText().ShouldEqual(text);
        }
        
        [When(@"I click all the checkboxes")]
        public void WhenIClickAllTheCheckboxForEquifax()
        {
            GenericPage.GetTableRowDataByXPath(1, 1).Click();
            GenericPage.GetTableRowDataByXPath(2,1).Click();
            GenericPage.GetTableRowDataByXPath(3,1).Click();
        }
        
        [When(@"I click the checkbox in row '(.*)'")]
        public void WhenIClickTheCheckboxForEquifax(int rowNumber)
        {
            GenericPage.GetTableRowDataByXPath(rowNumber,1).Click();
        }

        [Then(@"all statuses should read '(.*)'")]
        public void ThenAllEquifaxStatusShouldReadInfileOrNeedsReviewOrPass(string status)
        {
            GenericPage.GetTableRowDataByXPath(1,2).WaitUntilTextIsVisible(status);
            var status1 = GenericPage.GetTableRowDataByXPath(1,2).GetText();
            GenericPage.GetTableRowDataByXPath(1,2).GetText().ShouldEqual(status);
            
            GenericPage.GetTableRowDataByXPath(2,2).WaitUntilTextIsVisible(status);
            var status2 = GenericPage.GetTableRowDataByXPath(2,2).GetText();
            GenericPage.GetTableRowDataByXPath(2,2).GetText().ShouldEqual(status);
            
            GenericPage.GetTableRowDataByXPath(3,2).WaitUntilTextIsVisible(status);
            var status3 = GenericPage.GetTableRowDataByXPath(3,2).GetText();
            GenericPage.GetTableRowDataByXPath(3,2).GetText().ShouldEqual(status);        
        }
        
        [Then(@"the status in row '(.*)' should read '(.*)'")]
        public void TheStatusInRowShouldRead(int rowNumber, string status)
        {
            GenericPage.GetTableRowDataByXPath(rowNumber,2).WaitUntilTextIsVisible(status);
            var status1 = GenericPage.GetTableRowDataByXPath(1,2).GetText();
            GenericPage.GetTableRowDataByXPath(rowNumber,2).GetText().ShouldEqual(status);
        }

        [Then(@"all report dates should equal today's date")]
        public void ThenAllEquifaxReportDateShouldEqualTodaysDate()
        {
            var currentDate = DateTime.Now.ToString("MM/dd/yyyy");
            GenericPage.GetTableRowDataByXPath(1,5).GetText().ShouldEqual(currentDate);
            GenericPage.GetTableRowDataByXPath(2,5).GetText().ShouldEqual(currentDate);
            GenericPage.GetTableRowDataByXPath(3,5).GetText().ShouldEqual(currentDate);
        }
        
        [Then(@"the report date in row '(.*)' should equal today's date")]
        public void ThenTheEquifaxReportDateShouldEqualTodaysDate(int rowNumber)
        {
            var currentDate = DateTime.Now.ToString("MM/dd/yyyy");
            GenericPage.GetTableRowDataByXPath(rowNumber, 5).GetText().ShouldEqual(currentDate);
        }

        [Then(@"the '(.*)' columns should display '(.*)'")]
        public void ThenTheEquifaxActionsColumnsShouldDisplayViewReport(string column, string text )
        {
            GenericPage.GetTableHeadsByXPath(6).GetText().ShouldEqual($"{column}");
            GenericPage.GetTableRowDataByXPath(1,6).IsDisplayed().ShouldBeTrue($"{text} is not displayed");
            GenericPage.GetTableRowDataByXPath(1,6).GetText().ShouldEqual(text);
            GenericPage.GetTableRowDataByXPath(2,6).IsDisplayed().ShouldBeTrue($"{text} is not displayed");
            GenericPage.GetTableRowDataByXPath(2,6).GetText().ShouldEqual(text);
            GenericPage.GetTableRowDataByXPath(3,6).IsDisplayed().ShouldBeTrue($"{text} is not displayed");
            GenericPage.GetTableRowDataByXPath(3,6).GetText().ShouldEqual(text);
        }
        
        [Then(@"the '(.*)' column in row '(.*)' should display '(.*)'")]
        public void ThenTheColumnShouldDisplay(string column, int rowNumber,string text )
        {
            GenericPage.GetTableHeadsByXPath(6).GetText().ShouldEqual($"{column}");
            GenericPage.GetTableRowDataByXPath(rowNumber,6).IsDisplayed().ShouldBeTrue($"{text} is not displayed");
            GenericPage.GetTableRowDataByXPath(rowNumber,6).GetText().ShouldEqual(text);
        }

        [Then(@"the Fico score should be lower than '(.*)'")]
        public void ThenTheFicoScoreShouldLowerThen250(int score)
        {
            var element = GenericPage.GetTableRowDataByXPath(1, 5).GetText();
            var ficoScore = Convert.ToInt32(element);
            Assert.LessOrEqual(ficoScore, score);
        }

        [Then(@"the Fico score should be higher than '(.*)'")]
        public void ThenTheFicoScoreShouldBeHigherThen250(string score)
        {
            var element = GenericPage.GetTableRowDataByXPath(1, 5).GetText();
            var ficoScore = Convert.ToInt32(element);
            Assert.GreaterOrEqual(ficoScore, score);
        }

        [Then(@"I see '(.*)' under relationship in row '(.*)'")]
        public void ThenISeeUnderRelationshipInRow1(string elementName, int rowNumber)
        {
            GenericPage.GetTableRowDataByXPath(rowNumber,4).WaitUntilElementIsDisplayed();
            GenericPage.GetTableRowDataByXPath(rowNumber,4).IsDisplayed().ShouldBeTrue("Report type is not displayed");
            GenericPage.GetTableRowDataByXPath(rowNumber,4).GetText().ShouldEqual(elementName);
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
            var url = "https://emeaqaspring2021--nfuse.visualforce.com/apex/Verifications?id=" + CurrentReleaseDataloader.Id[0];
            DriverContext.WebDriver.Url = url;
        }

        [Given(@"I have navigated to plugin configuration")]
        public void GivenIHaveNavigatedToPluginConfiguration()
        {
            var pluginConfig = "https://emeaqaspring2021--nfuse.visualforce.com/apex/pluginconfiguration";
            DriverContext.WebDriver.Url = pluginConfig;
            
            //Login to Qa org
            LoginSteps.WhenILoginAsSystemAdministrator();
        }

        [When(@"I Navigate to Ursula cave's account")]
        public void WhenINavigateToUrsulaCavesAccount()
        {
            var ursulaCave = "https://emeaqaspring2021--nfuse.visualforce.com/apex/Verifications?id=" + CurrentReleaseDataloader.Id[6];
            DriverContext.WebDriver.Url = ursulaCave;
        }

        [When(@"I navigate to verification from loan")]
        public void WhenINavigateToVerificationFromLoan()
        {
            var businessLoan = "https://emeaqaspring2021--llc-bi.visualforce.com/apex/llc_bi__Loan?app=m-loan.verify-credit-checklist&id=" + CurrentReleaseDataloader.LoanId[0];
            DriverContext.WebDriver.Url = businessLoan;
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

        [When(@"I go to the verification page for Neal Springthorpe")]
        public void WhenIGoToTheVerificationPageForNealSpringThorpe()
        {
            var relationshipRecord = "https://emeaqaspring2021--nfuse.visualforce.com/apex/Verifications?id=" + CurrentReleaseDataloader.Id[8];
            DriverContext.WebDriver.Url = relationshipRecord;
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
    }
}

