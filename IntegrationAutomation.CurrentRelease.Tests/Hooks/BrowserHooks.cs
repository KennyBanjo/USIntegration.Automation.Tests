using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Selenium.Base;
using BoDi;
using Gherkin.Ast;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;



namespace Integration.UIAutomation.Tests.Hooks
{
    public class BrowserHooks
    {
        private static  IObjectContainer _objectContainer;
        private  static IWebDriver _driver;


        public BrowserHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        //This method provides option for choosing browser types.
        public static void OpenBrowser(Browser.BrowserType browserType)
        {
            switch (browserType)
            {
                case Browser.BrowserType.ChromeHeadless:
                   // new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    ChromeOptions option = new ChromeOptions();
                    option.AddArgument("--window-size=1920,1080");
                    option.AddArgument("--headless");
                    option.AddArgument("--no-sandbox");
                    //option.AddArgument("--disable-dev-shm-usage");
                    DriverContext.WebDriver = new ChromeDriver(option);
                    DriverContext.Browser = new Browser(DriverContext.WebDriver);
                   break;
                case Browser.BrowserType.Chrome:
                    DriverContext.WebDriver = new ChromeDriver();
                    DriverContext.Browser = new Browser(DriverContext.WebDriver);
                    DriverContext.WebDriver.Manage().Window.Maximize();
                    //DriverContext.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    break;
                case Browser.BrowserType.Firefox:
                    DriverContext.WebDriver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.WebDriver);
                    DriverContext.WebDriver.Manage().Window.Maximize();
                    DriverContext.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    break;
            }
        }
    }
}
