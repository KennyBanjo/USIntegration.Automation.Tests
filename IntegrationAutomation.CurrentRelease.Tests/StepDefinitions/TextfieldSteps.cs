using System;
using Automation.Core.Selenium.ComponentHelper;
using IntegrationAutomation.CurrentRelease.Tests.PageObjectPages.GenericObjects;


namespace IntegrationAutomation.CurrentRelease.Tests.StepDefinitions
{
    public class TextfieldSteps
    {
        private static GenericPage GenericPage => new GenericPage();
        
        /// <summary>
        /// This methods helps get past the stale element reference error
        /// </summary>
        /// <param name="text"></param>
        /// <param name="searchField"></param>
        /// <returns></returns>
        public static bool SmartEnterText(string text, string searchField)
        {
            var result = false;
            var attempt = 0;
            while (attempt < 2)
            {
                try
                {
                    GenericPage.GetTextFieldByxPath(searchField).JsEnterText(text);
                    GenericPage.GetTextFieldByxPath(searchField).Enter();
                    result = true;
                    break;
                }
                catch (Exception e)
                {
                    LogHelper.Info(e);
                }

                attempt++;
            }
            return result;
        }
        
    }
}