using Automation.Core.Selenium.ComponentHelper;
using IntegrationAutomation.CurrentRelease.Tests.PageObjectPages.GenericObjects;
using OpenQA.Selenium;

namespace IntegrationAutomation.CurrentRelease.Tests.StepDefinitions
{
    public class ButtonSteps
    {
        private static GenericPage GenericPage => new GenericPage();
        
        /// <summary>
        /// This methods helps get past the stale element reference error
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool SmartClick(string element)
        {
            var result = false;
            var attempt = 0;
            while (attempt < 2)
            {
                try
                {
                    GenericPage.GetButtonByXPathText(element).WaitUntilElementIsClickable();
                    GenericPage.GetButtonByXPathText(element).ClickByJsExecutor();
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
    }
}