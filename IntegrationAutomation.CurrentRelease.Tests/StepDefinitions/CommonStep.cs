using System;
using System.Collections.Generic;
using System.Text;
using Automation.Core.Selenium.Base;
using Automation.Core.Selenium.ComponentHelper;
using IntegrationAutomation.CurrentRelease.Tests.PageObjectPages.GenericObjects;
using OpenQA.Selenium;
using Should;
using TechTalk.SpecFlow;

namespace IntegrationAutomation.PreviousRelease.Tests.StepDefinitions
{
    [Binding]
    public class CommonStep:BasePage
    {
        private GenericPage GenericPage => new GenericPage();

        [When(@"I enter (.*) the endpoint URL configuration name")]
        public void WhenIEnterTheEndpointUrlConfigurationName(string name)
        {
            CurrentPage = GetInstance<CommonActions>();
            CurrentPage.As<CommonActions>().EnterConfigurationName(name);
        }

        [When(@"I click the save button")]
        public void WhenIClickTheSaveButton()
        {
            CurrentPage = GetInstance<CommonActions>();
            CurrentPage.As<CommonActions>().ClickSaveButton();
        }

        [When(@"I click the Back button")]
        public void WhenIClickTheBackButton()
        {
            CurrentPage = GetInstance<CommonActions>();
            CurrentPage.As<CommonActions>().ClickBackButton();
        }


        [When(@"I click the Back button in configuration")]
        public void WhenIClickTheBackButtonInConfiguration()
        {
            CurrentPage = GetInstance<CommonActions>();
            CurrentPage.As<CommonActions>().ClickConfigurationBackButton();
        }

        [Then(@"I exit the configuration frame")]
        public void ThenIExitTheConfigurationFrame()
        {
            GenericPage.GetFrameByXPath("accessibility title").SwitchToDefaultContent();
        }

        [Then(@"An '(.*)' should appear with the message '(.*)'")]
        public void DisplayErrorMessage(string error, string errorMsg)
        {
            GenericPage.GetErrorMsgByXPath(error).WaitUntilElementIsDisplayed();
            GenericPage.GetErrorMsgByXPath(error).IsDisplayed().ShouldBeTrue($"{error} is not displayed");
            GenericPage.GetErrorMsgByXPath(errorMsg).IsDisplayed().ShouldBeTrue($"{errorMsg} is not displayed");
        }

        [When(@"I refresh the page")]
        public void WhenIRefreshThePage()
        {
            DriverContext.WebDriver.Navigate().Refresh();
        }


        [When(@"I switch to the current frame")]
        public void WhenISwitchToTheCurrentFrame()
        {
            GenericPage.GetFrameByXPath("accessibility title").WaitUntilElementIsDisplayed();
            GenericPage.GetFrameByXPath("accessibility title").SwitchToFrame();
        }

        [When(@"I click the button '(.*)'")]
        public bool  WhenIClickTheButton(string button)
        {
            var result = false;
           var attempt = 0;
           while (attempt < 2)
           {
               try
               {
                   GenericPage.GetLabelByText(button).WaitUntilElementIsClickable();
                   GenericPage.GetLabelByText(button).ClickByJsExecutor();
                   result = true;
                   break;
               }
               catch (StaleElementReferenceException e)
               {
                   LogHelper.Info(e);
               }
               attempt++;
           }
           return result;
        }

        [When(@"I enter '(.*)' in the '(.*)' textfield")]
        public void WhenIEnterInTheTextfield(string text, string textField)
        {
            GenericPage.GetTextFieldByxPath(textField).WaitUntilElementIsDisplayed();
            GenericPage.GetTextFieldByxPath(textField).IsDisplayed().ShouldBeTrue("Textfield is not displayed");
            GenericPage.GetTextFieldByxPath(textField).ScrollToView();
            GenericPage.GetTextFieldByxPath(textField).EnterText(text);
        }

        [When(@"I select '(.*)' from the '(.*)' dropdown list")]
        public void WhenISelectFromTheDropdownList(string text, string dropdown)
        {
           GenericPage.GetDropdownByXpath(dropdown).WaitUntilElementIsDisplayed();
           GenericPage.GetDropdownByXpath(dropdown).IsDisplayed().ShouldBeTrue($"{dropdown} is not displayed");
           GenericPage.GetDropdownByXpath(dropdown).ClickByJsExecutor();
           GenericPage.GetDropdownByXpath(dropdown).SelectElementWithWait(text);
        }
    }
}
