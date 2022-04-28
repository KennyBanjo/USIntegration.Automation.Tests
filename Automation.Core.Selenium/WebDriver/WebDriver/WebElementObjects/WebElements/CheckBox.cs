using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Selenium.ExtensionMethods;
using Automation.Core.Selenium.WebDriver.WebElementObjects;
using Automation.Core.Selenium.WebDriver.WebElementObjects.Interfaces;

namespace Automation.Core.Selenium.WebDriver.WebDriver.WebElementObjects.WebElements
{
    public class CheckBox: WebElementObjectBase, IClickable
    {
        public void Click()
        {
            GetElement().ClickByJsExecutor();
        }

        public bool Selected()
        {
            return IsElementSelected();
        }
        
        public bool DeSelected()
        {
            return !IsElementSelected();
        }

        public void Check()
        {
            GetElement();
            if (!IsElementSelected())
            {
                Click();
            }
        }

        public void UnCheck()
        {
            if (IsElementSelected())
            {
                Click();
            }
        }
        private bool IsElementSelected()
        {
            try
            {
                return GetElement().Selected;
            }
            catch (Exception)
            {
                return GetElement().Selected;
            }
        }
    }
}
