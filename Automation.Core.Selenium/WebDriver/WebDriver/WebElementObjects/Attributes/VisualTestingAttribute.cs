using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Core.Selenium.WebDriver.WebDriver.WebElementObjects.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class VisualTestingAttribute:Attribute
    {
        public string Value { get; set; }

        public VisualTestingAttribute(string visualTestingAttributeValue)
        {
            this.Value = visualTestingAttributeValue;
        }
    }
}
