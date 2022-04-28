using System;
using System.Threading;
using Automation.Core.Selenium.Base;
using Automation.Core.Selenium.ComponentHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Automation.Core.Selenium.ExtensionMethods
{
    public static class ExtensionMethods
    {
        /// Waits for element to be visible for up to max 30 seconds.
        /// </summary>
        /// <param name="element"></param>
        public static void WaitUntilElementVisible(this IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(DriverContext.WebDriver, TimeSpan.FromSeconds(180));
            wait.Until(ElementIsVisible(element));
        }
        public static void OnfifoWaitUntilElementVisible(this IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(DriverContext.WebDriver, TimeSpan.FromSeconds(300));
            wait.Until(ElementIsVisible(element));
        }
        
        public static void SelectElementByIndex(this IWebElement element, int index)
        {
            element.WaitUntilElementVisible();
            var select = new SelectElement(element);
            select.SelectByIndex(index);
        }
        
        public static void SelectElementByValue(this IWebElement element, string value)
        {
            element.WaitUntilElementVisible();
            var select = new SelectElement(element);
            select.SelectByValue(value);
        }

        public static Func<IWebDriver, bool> ElementIsVisible(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    return element.IsDisplayed();
                }
                catch (Exception)
                {
                    return false;
                }
            };
        }

        public static void WaitUntilElementClickable(this IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(DriverContext.WebDriver, TimeSpan.FromSeconds(60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        /// <summary>
        /// Returns true if element is displayed and false if not
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsDisplayed(this IWebElement element)
        {
            bool result;
            try
            {
                result = element.Displayed;
            }
            catch (NoSuchElementException)
            {

                result = false;
            }
            return result;
        }

        public static void EnterText(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
        
        public static void ClickByJsExecutor(this IWebElement element)
        {
            var jsExecutor = DriverContext.WebDriver as IJavaScriptExecutor;
            jsExecutor.ExecuteScript("arguments[0].click();", element);
            try
            {
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                LogHelper.Info(e);
                throw;
            }
        }
        
        public static bool IsElementPresent(this By byLocator)
        {
            return DriverContext.WebDriver.FindElements(byLocator).Count == 1;
        }

    }
}
