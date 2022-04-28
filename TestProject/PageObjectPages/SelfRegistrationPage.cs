
using Automation.Core.Selenium.Base;
using Automation.Core.Selenium.ExtensionMethods;
using Integration.UIAutomation.Tests.TableEntities;
using IntegrationAutomation.CurrentRelease.Tests.PageObjectPages.GenericObjects;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Should;
using TechTalk.SpecFlow.Assist;
using Table = TechTalk.SpecFlow.Table;

namespace IntegrationAutomation.CurrentRelease.Tests.PageObjectPages
{
    public class SelfRegistrationPage:BasePage
    { 
        public GenericPage GenericPage => new GenericPage();

        [FindsBy(How = How.CssSelector, Using = "input[name= firstName]")]
        private IWebElement FirstName;

        [FindsBy(How = How.CssSelector, Using = "input[name= lastName]")]
        private IWebElement LastName;

        [FindsBy(How = How.CssSelector, Using = "input[name= email]")]
        private IWebElement Email;

        [FindsBy(How = How.CssSelector, Using = "input[name= mobile]")]
        private IWebElement Mobile;

        [FindsBy(How = How.CssSelector, Using = "#registerUser")]
        private IWebElement ContinueBtn;

        [FindsBy(How = How.CssSelector, Using = "[name='LLC_BI__Amount__c' ] [type = 'text']")]
        private IWebElement LoanAmountField;

        [FindsBy(How = How.CssSelector, Using = "textarea[id= LLC_BI__Description__c-input]")]
        private IWebElement LoanPurposeField;

        [FindsBy(How = How.XPath, Using = "//input[@id='dynamic-input']")]
        private IWebElement CompanyNameField;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Next')]")]
        private IWebElement nextBtn;

        [FindsBy(How = How.CssSelector, Using =  "[index= '0']")]
        private IWebElement SearchResult;

        [FindsBy(How = How.XPath, Using = "//h3[contains(text(),'determine your eligibility')]")]
        private IWebElement EligibiltyPage;

        [FindsBy(How = How.XPath, Using = "//h3[contains(text(),'Your Business (ABR Search)')]")]
        private IWebElement ABRSearchPage;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'NCINO APAC PTY LTD')]")]
        private IWebElement EntityNameField;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'42622945493')]")]
        private IWebElement ABNField;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Australian Private Company')]")]
        private IWebElement EntityTypeField;

        [FindsBy(How = How.CssSelector, Using = "[name = 'SIOC__CompanyInfo__c.SIOC__VendorId__c']")]
        private IWebElement ASICField;

        [FindsBy(How = How.CssSelector, Using = "[name = 'SIOC__CompanyInfo__c.SIOC__Address1PostalCode__c']")]
        private IWebElement BusinessPostCode;

        [FindsBy(How = How.CssSelector, Using = "[name = 'SIOC__CompanyInfo__c.SIOC__Address1Line6__c']")]
        public IWebElement BusinessState;


        public  SelfRegistrationPage EnterUserDetails(Table table)
        {
            var user = table.CreateInstance<User>();
            GenericPage.GetTextFieldByxPath("firstName").WaitUntilElementIsDisplayed();
            GenericPage.GetTextFieldByxPath("firstName").IsDisplayed().ShouldBeTrue("Firstname field is not displayed");
            GenericPage.GetTextFieldByxPath("firstName").EnterText(user.FirstName);
            GenericPage.GetTextFieldByxPath("lastName").EnterText(user.LastName);
            GenericPage.GetTextFieldByxPath("email").EnterText(user.Email);
            GenericPage.GetTextFieldByxPath("mobile").EnterText(user.Mobile);
            return new SelfRegistrationPage();
        }

        public SelfRegistrationPage ClickContinue()
        {
            GenericPage.GetButtonByxPath("registerUser").IsDisplayed().ShouldBeTrue("Continue button is not displayed");
            GenericPage.GetButtonByxPath("registerUser").Click();
            return new SelfRegistrationPage();
        }

        public SelfRegistrationPage EnterLoanAmount(string amount)
        {
            LoanAmountField.WaitUntilElementVisible();
            LoanAmountField.IsDisplayed().ShouldBeTrue("Loan amount field is not displayed");
            LoanAmountField.Click();
            LoanAmountField.EnterText(amount);
            return new SelfRegistrationPage();
        }

        public SelfRegistrationPage EnterLoanPurpose(string purpose)
        {
            LoanPurposeField.IsDisplayed().ShouldBeTrue("Loan amount field is not displayed");
            LoanPurposeField.EnterText(purpose);
            return new SelfRegistrationPage();
        }

        public SelfRegistrationPage ClickNext()
        {
            nextBtn.IsDisplayed().ShouldBeTrue("Next button is not displayed");
            nextBtn.Click();
            return new SelfRegistrationPage();
        }

        public SelfRegistrationPage EnterCompanyName(string companyName)
        {
            GenericPage.GetTextFieldByxPath("dynamic-input").WaitUntilElementIsDisplayed();
            //CompanyNameField.WaitUntilElementVisible();
            GenericPage.GetTextFieldByxPath("dynamic-input").IsDisplayed().ShouldBeTrue("Company name field is not displayed");
            GenericPage.GetTextFieldByxPath("dynamic-input").EnterText(companyName);
            return new SelfRegistrationPage();
        }

        public SelfRegistrationPage SelectFirstResult()
        {
            GenericPage.GetTextFieldByxPath("dynamic-input").Click();
            SearchResult.WaitUntilElementVisible();
            SearchResult.IsDisplayed().ShouldBeTrue("NCINO APAC PTY LTD is not displayed");
            SearchResult.Click();
            return new SelfRegistrationPage();
        }

        public SelfRegistrationPage DisplayEligibilityPage()
        {
            GenericPage.GetLabelByText("determine your eligibility").WaitUntilElementIsDisplayed();
            // EligibiltyPage.WaitUntilElementVisible();
            GenericPage.GetLabelByText("determine your eligibility").IsDisplayed().ShouldBeTrue("");
            //EligibiltyPage.IsDisplayed().ShouldBeTrue("Eligibility page is not displayed");
            return new SelfRegistrationPage();
        }

        public SelfRegistrationPage DisplayABRSearch()
        {
            GenericPage.GetButtonByXPathText("Your Business (ABR Search)").WaitUntilElementIsDisplayed();
            GenericPage.GetButtonByXPathText("Your Business (ABR Search").IsDisplayed().ShouldBeTrue("Eligibility page is not displayed");
            return new SelfRegistrationPage();
        }

        public SelfRegistrationPage VerifyFields(Table table)
        {
            EntityNameField.WaitUntilElementVisible();
            var fields = table.CreateInstance<ABRSearch>();
            EntityNameField.Text.ShouldEqual(fields.EntityName);
            ABNField.Text.ShouldEqual(fields.ABN);
            EntityTypeField.Text.ShouldEqual(fields.EntityType);
            ASICField.Text.ShouldEqual(fields.ASICRegistration);
            BusinessState.Text.ShouldEqual(fields.BusinessLocationState);
            BusinessPostCode.Text.ShouldEqual(fields.BusinessPostcode);
            return new SelfRegistrationPage();
        }
    }
}
