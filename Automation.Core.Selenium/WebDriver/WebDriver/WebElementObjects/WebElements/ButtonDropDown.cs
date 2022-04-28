using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Selenium.ExtensionMethods;
using Automation.Core.Selenium.WebDriver.WebElementObjects;
using Automation.Core.Selenium.WebDriver.WebElementObjects.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Automation.Core.Selenium.WebDriver.WebDriver.WebElementObjects.WebElements
{
    public class ButtonDropDown: WebElementObjectBase, IDropDown, IWebElementObject
    {
        private const string ButtonLocator = "[type = 'button']";
        
        public void Select(string itemToSelect)
        {
            //Wait for it to drop down
            WaitForElement(ByLocator);
            //find and click on the required item
            var dropdownItem = GetElement().FindElement(ByLocator);
            dropdownItem.ClickByJsExecutor();
        }

        public void SelectByValue(string value)
        {
            var select = new SelectElement(GetElement());
            select.SelectByValue(value);
        }

        public IList<IWebElement> ReturnAllOptions()
        {
            GetElement();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElements(By.CssSelector("li")).Count > 0);
            return GetElement().FindElements(By.CssSelector("li"));
        }

        public string ReturnSelectedItem()
        {
            var selectedItems = GetElement().FindElement(ByLocator).Text;
            return selectedItems;
        }
        public void Click()
        {
            //Wait until the button is there
            WaitForElement();
            //perform the click
            var action = new Actions(Driver);
            action.MoveToElement(GetElement()).Click().Perform();
        }
    }
}
