using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Selenium.ExtensionMethods;
using Automation.Core.Selenium.WebDriver.WebElementObjects;
using Automation.Core.Selenium.WebDriver.WebElementObjects.Interfaces;
using OpenQA.Selenium;

namespace Automation.Core.Selenium.WebDriver.WebDriver.WebElementObjects.WebElements
{
    public class SelectList:WebElementObjectBase, IDropDown
    {
        public void Select(string valueToSelect)
        {
            Driver.WaitForAjax();
            GetElement().SelectElementByValue(valueToSelect);
        }

        public IList<IWebElement> ReturnAllOptions()
        {
            throw new NotImplementedException();
        }

        public string ReturnSelectedItem()
        {
            throw new NotImplementedException();
        }
    }
}
