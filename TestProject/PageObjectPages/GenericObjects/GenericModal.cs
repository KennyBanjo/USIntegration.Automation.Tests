using Automation.Core.Selenium.Base;
using Automation.Core.Selenium.PageObjects;
using Automation.Core.Selenium.WebDriver.WebDriver.WebElementObjects.Attributes;
using Automation.Core.Selenium.WebDriver.WebDriver.WebElementObjects.WebElements;

using OpenQA.Selenium;

namespace IntegrationAutomation.CurrentRelease.Tests.PageObjectPages.GenericObjects
{
    public class GenericModal:PageObjectBase
    {
        public GenericModal( bool useWaitForAjax = true) : base(DriverContext.WebDriver, useWaitForAjax)
        {
        }
        
        [WebElementLocator(LocatorTypeEnum.Css, "")]
        private Button GenericWindowButton;
        
        [WebElementLocator(LocatorTypeEnum.Css, "")]
        private Label GenericWindowLabel;

        [WebElementLocator(LocatorTypeEnum.Css, ".loadingSpinner ")]
        public Label LoadingSpinner;

        public Label GetModalHeader()
        {
            GenericWindowLabel.ByLocator = By.CssSelector(".modal-header");
            return GenericWindowLabel;
        }

    }
}