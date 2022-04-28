using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Selenium.WebDriver.WebElementObjects;
using Automation.Core.Selenium.WebDriver.WebElementObjects.Interfaces;
using OpenQA.Selenium.Interactions;

namespace Automation.Core.Selenium.WebDriver.WebDriver.WebElementObjects.WebElements
{
    public class Table:WebElementObjectBase, ITable
    {
        public void Click()
        {
            //Wait until the button is there
            WaitForElement();
            //perform the click
            var action = new Actions(Driver);
            action.MoveToElement(GetElement()).Click().Perform();
        }

        public override  string GetText()
        {
            return GetElement().Text;
        }
    }
}
