using System.Collections;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace Automation.Core.Selenium.WebDriver.WebElementObjects.Interfaces
{
    public interface IDropDown
    {
        void Select(string ItemToSelect);
        IList<IWebElement> ReturnAllOptions();
        string ReturnSelectedItem();
    }
}