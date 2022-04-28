using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Automation.Core.Selenium.Base
{
    public class Browser
    {
        private IWebDriver _driver;
        public Browser(IWebDriver driver)
        {
            _driver = driver;
        }

        public BrowserType Type { get; set; }

        public enum BrowserType
        {
            Chrome,
            Firefox,
            ChromeHeadless
        }
    }
}
