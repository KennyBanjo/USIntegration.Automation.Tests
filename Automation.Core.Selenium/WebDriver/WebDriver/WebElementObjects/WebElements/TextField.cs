using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Automation.Core.Selenium.Base;
using Automation.Core.Selenium.ComponentHelper;
using Automation.Core.Selenium.WebDriver.WebElementObjects;
using Automation.Core.Selenium.WebDriver.WebElementObjects.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Automation.Core.Selenium.WebDriver.WebDriver.WebElementObjects.WebElements
{
    public class TextField:WebElementObjectBase, ITypable, IInput
    {
        public void EnterText(string text)
        {
            WaitForElement();
            //Click();
            GetElement().Clear();
            GetElement().SendKeys(text);
        }

        public void Click()
        {
            //Wait until the button is there
            WaitForElement();
            //perform the click
            var action = new Actions(Driver);
            action.MoveToElement(GetElement()).Click().Perform();
        }

        public void Enter()
        {
            GetElement().SendKeys(Keys.Enter);
        }
        public string GetValue()
        {
           return GetElement().GetAttribute("value");
        }

        public void ClearText()
        {
            WaitForElement();
            GetElement().Clear();
        }

        public void JsClick()
        {
            var jsExecutor = DriverContext.WebDriver as IJavaScriptExecutor;
            jsExecutor.ExecuteScript("arguments[0].click();", Element);
            try
            {
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void JsEnterText(string text)
        {
            var jsExecutor = DriverContext.WebDriver as IJavaScriptExecutor;
            jsExecutor.ExecuteScript($"arguments[0].value='{text}'", GetElement());
            try
            {
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Populate(object data)
        {
            EnterText(data.ToString());
        }

        public override string GetText()
        {
            WaitForElement();
            return GetValue();
        }
    }
}
