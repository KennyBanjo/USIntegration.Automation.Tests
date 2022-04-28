using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Core.Selenium.WebDriver.WebDriver.WebElementObjects.Attributes
{
    public class FieldAttributeHelper <TAttributeType>
    {
        public static List<TAttributeType> ReturnAttribute(FieldInfo field)
        {
            return field
                .GetCustomAttributes(typeof(TAttributeType), true)
                .Cast<TAttributeType>()
                .ToList();
        }
    }
}
