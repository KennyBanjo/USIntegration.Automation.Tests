using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Automation.Core.Selenium.Base;
using Automation.Core.Selenium.ComponentHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace Automation.Core.Selenium.WebDriver.WebDriver.WebElementObjects
{
    public class WebElementObjectBase
    {
        private WebDriverWait Wait => new WebDriverWait(DriverContext.WebDriver, TimeSpan.FromSeconds(120));
        private WebDriverWait onfidoWait => new WebDriverWait(DriverContext.WebDriver, TimeSpan.FromSeconds(300));

        public By ByLocator { get; set; }
        public string Locator { get; set; }
        public IWebDriver  Driver { get; set; }
        public IWebElement Element { get; set; }
        public string BindedDataAttribute { get; set; }
        public bool IsMandatory { get; set; }
        public string Url { get; set; }
        public string  ViewModelBinding { get; set; }
        public bool UseWaitAjax { get; set; }
        public IWebElement RootElement { get; set; }

        public bool ReturnIsMandatory()
        {
            return IsMandatory;
        }
        public string ReturnBindedDataAttribute()
        {
            return BindedDataAttribute;
        }

        public virtual IWebElement GetElement()
        {
            return GetElement(10);
        }

        public virtual IWebElement GetElement(int seconds)
        {
            try
            {
                if (UseWaitAjax)
                {
                    Driver.WaitForAjax();
                }

                Element = RootElement != null
                    ? Wait.Until(d => RootElement.FindElement(ByLocator))
                    : Wait.Until(d => d.FindElement(ByLocator));
                return Element;
            }
            catch (Exception)
            {
                return null;
            }
            
        }
        /// <summary>
        /// Verifies if an element is displayed on the interface
        /// </summary>
        /// <returns></returns>
        public bool IsDisplayed()
        {
            return IsDisplayed(ByLocator);
        } 
        
        public bool IsNotDisplayed()
        {
            return !IsDisplayed(ByLocator);
        }

        public bool IsDisplayed(By byLocator)
        {
            try
            {
                return Wait.Until(d =>
                {
                    try
                    {
                        return d.FindElement(ByLocator).Displayed;
                    }
                    catch (StaleElementReferenceException)
                    {
                        return d.FindElement(ByLocator).Displayed;
                    }
                    catch (NoSuchElementException)
                    {
                        return false;
                    }
                });
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (TimeoutException)
            {
                return false;
            }
        }

        public bool IsEnabled()
        {
            try
            {
                return GetElement().Enabled;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public void ClickByJsExecutor()
        {
            var jsExecutor = DriverContext.WebDriver as IJavaScriptExecutor;
            jsExecutor.ExecuteScript("arguments[0].click();", GetElement());
            try
            {
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                LogHelper.Error(e);
                throw;
            }
        }

        public bool SmartJsClick()
        {
            var attempt = 0;
            var result = false;
            while (attempt < 2)
            {
                try
                {
                    ClickByJsExecutor();
                    result = true;
                    break;
                }
                catch (Exception e)
                {
                    LogHelper.Error(e);
                }
                attempt++;
            }
            return result;
        }

        public void WaitUntilElementIsDisplayed()
        {
            try
            {
                Wait.Until(ExpectedConditions.ElementIsVisible(ByLocator));
            }
            catch (Exception e)
            {
                LogHelper.Error(e);
                throw;
            }
        }
        
        public void OnfidoWaitUntilElementIsDisplayed()
        {
            try
            {
                onfidoWait.Until(ExpectedConditions.ElementIsVisible(ByLocator));
            }
            catch (Exception e)
            {
                LogHelper.Error(e);
                throw;
            }
        }

        public void WaitUntilElementIsClickable()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(ByLocator));
        }
        public void WaitUntilTextIsVisible(string text)
        {
            Wait.Until(ExpectedConditions.TextToBePresentInElementLocated(ByLocator, text));
        }

        public void WaitForElementToDisappear()
        {
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(ByLocator));
        }

        public void WaitForElementToBeSelected()
        {
            Wait.Until(ExpectedConditions.ElementSelectionStateToBe(ByLocator, true));
        }
        
        public void WaitForElementToBeDeSelected()
        {
            Wait.Until(ExpectedConditions.ElementSelectionStateToBe(ByLocator, false));
        }

        public void WaitForElement()
        {
            WaitForElement(ByLocator);
        }
        public void WaitForElement(By byLocator)
        {
            if (IsDisplayed(byLocator) && IsEnabled()) return;
            {
                WaitUntilElementIsDisplayed();
                if (!IsEnabled())
                {
                    WaitUntilElementIsClickable();
                }
            }
        }

        public virtual string GetText()
        {
            WaitForElement();
            return GetElement().Text;
        }

        public virtual string GetErrorText()
        {
            WaitForElement(); 
            return GetElement().GetAttribute("");
        }

        public void DoubleClick()
        {
            WaitForElement();
            var action = new Actions(Driver);
            action.DoubleClick(GetElement());
            action.Perform();
        }

        public  void SelectElementWithWait( string text)
        {
            WebDriverWait wait = new WebDriverWait(DriverContext.WebDriver, TimeSpan.FromSeconds(30));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(ByLocator));
            SelectElement select = new SelectElement(element);
            select.SelectByText(text);
        }
        
        public void SelectByValue(string value)
        {
            WebDriverWait wait = new WebDriverWait(DriverContext.WebDriver, TimeSpan.FromSeconds(30));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(ByLocator));
            var select = new SelectElement(GetElement());
            select.SelectByValue(value);
        }

        public void ScrollToView()
        {
            var jsExecutor = DriverContext.WebDriver as IJavaScriptExecutor;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", GetElement());
        }

        public void MoveToElement(IWebElement element)
        {
            Actions action = new Actions(DriverContext.WebDriver);
            action.MoveToElement(element);
            action.Perform();
            action.Build();
        }
        
        /// <summary>
        /// Does the element exist regardless of visibility
        /// </summary>
        /// <param name="shouldWait"></param>
        /// <param name="timeoutSeconds"></param>
        /// <param name="checkIfDisplayed"></param>
        /// <returns></returns>
        public bool Exists(bool shouldWait = true, int timeoutSeconds = 10, bool checkIfDisplayed = false)
        {
            const int preSleepMs = 100;
            //set the Wait time to a new value - either user specified, or 1 second
            var newWaitTime = shouldWait ? timeoutSeconds*1000 : 1000;
            //take away the time we spend preparing
            newWaitTime -= preSleepMs;
            //we have to find the element twice if we check visibility
            if (checkIfDisplayed) newWaitTime /= 2;
            //make sure it isn't a negative value
            newWaitTime = Math.Max(newWaitTime, 1);
            //set the new timeout period
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(newWaitTime);

            Thread.Sleep(preSleepMs);

            try
            {
                //make sure we dont return straight away, we need to reset the wait time
                var el = Driver.FindElements(ByLocator);
                var exists = el.Any();
                if (exists && checkIfDisplayed)
                {
                    //we may want to make sure it is visible as well
                    exists = el.First().GetCssValue("display") != "none";
                }
                return exists;
            }
            catch (Exception e)
            {
               LogHelper.Info($"Exception {e.Message}");
                //LogHelper.Error(e);
                return false;
            }
            finally
            {
                // Important: reset the Wait time back to default
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(int.Parse(ConfigurationManager.AppSettings["TimeOut"]));
            }
        }
    }
}
