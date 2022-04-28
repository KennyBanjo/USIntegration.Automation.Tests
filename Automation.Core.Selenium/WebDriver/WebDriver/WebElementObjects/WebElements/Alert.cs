using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Selenium.WebDriver.WebElementObjects;
using Automation.Core.Selenium.WebDriver.WebElementObjects.Interfaces;

namespace Automation.Core.Selenium.WebDriver.WebDriver.WebElementObjects.WebElements
{
    public class Alert:WebElementObjectBase, IAlertMessages
    {
        public void Accept()
        {
            throw new NotImplementedException();
        }

        public void Dismiss()
        {
            throw new NotImplementedException();
        }

        public string ReturnAlertMessage()
        {
            throw new NotImplementedException();
        }
    }
}
