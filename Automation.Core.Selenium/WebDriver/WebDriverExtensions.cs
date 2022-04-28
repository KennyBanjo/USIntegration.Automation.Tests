using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Automation.Core.Selenium.WebDriver
{
    public static class WebDriverExtensions
    {
        public static void WaitForAjax(this IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var jsExecutor = driver as IJavaScriptExecutor;
            wait.Until(d =>
                jsExecutor != null && (bool) jsExecutor.ExecuteScript("return (jQuery != 'undefined') ? jQuery.active == 0)" + ""));
        }

        public static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeOut)
        {
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                };
        }

    }
}
