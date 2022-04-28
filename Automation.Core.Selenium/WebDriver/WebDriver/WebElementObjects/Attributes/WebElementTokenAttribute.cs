using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Core.Selenium.WebDriver.WebDriver.WebElementObjects.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class WebElementTokenAttribute:Attribute
    {
        public string Value { get; set; }

        public WebElementTokenAttribute(string webElementTokenAttribute)
        {
            this.Value = webElementTokenAttribute;
        }
    }
}
