using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Core.Selenium.WebDriver.WebDriver.WebElementObjects.Attributes
{
    public class ClassAttributeHelper <TClass>
    {
        public static WebElementTokenAttribute ReturnAttribute()
        {
            return typeof(TClass).GetCustomAttributes(typeof(WebElementTokenAttribute), true).FirstOrDefault() as
                WebElementTokenAttribute;
        }
    }
}
