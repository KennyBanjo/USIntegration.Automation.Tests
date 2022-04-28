
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Automation.Core.Selenium.Base
{
    public class BaseClass
    {
        private IWebDriver _driver;

        public BasePage  CurrentPage { get; set; }

        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            TPage PageInstance = new TPage();
            {
                _driver = DriverContext.WebDriver;
            }
            PageFactory.InitElements(DriverContext.WebDriver, PageInstance);
            return PageInstance;
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage) this;
        }

       
    }
}
