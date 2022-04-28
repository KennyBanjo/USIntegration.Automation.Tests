using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Core.Selenium.WebDriver.WebDriver.WebElementObjects.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ViewModelBindingAttribute:Attribute
    {
        public string Value { get; set; }

        public ViewModelBindingAttribute(string viewModelBindingAttribute)
        {
            this.Value = viewModelBindingAttribute;
        }
    }
}
