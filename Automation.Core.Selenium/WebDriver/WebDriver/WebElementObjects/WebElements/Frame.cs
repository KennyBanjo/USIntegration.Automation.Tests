using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Selenium.WebDriver.WebElementObjects;
using Automation.Core.Selenium.WebDriver.WebElementObjects.Interfaces;
using OpenQA.Selenium;

namespace Automation.Core.Selenium.WebDriver.WebDriver.WebElementObjects.WebElements
{
    public class Frame:WebElementObjectBase, IFrame
    {
        public void SwitchToFrame()
        {
            WaitForElement();
            Driver.SwitchTo().Frame(GetElement());
        }

        public void SwitchToDefaultContent()
        {
            WaitForElement();
            Driver.SwitchTo().DefaultContent();
        }
    }
}
