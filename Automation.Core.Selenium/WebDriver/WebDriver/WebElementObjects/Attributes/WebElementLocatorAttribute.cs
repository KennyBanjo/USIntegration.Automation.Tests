using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Automation.Core.Selenium.WebDriver.WebDriver.WebElementObjects.Attributes
{
    public enum LocatorTypeEnum
    {
        Id,
        XPath,
        PartialLinkText,
        ClassName,
        Name,
        Css,
        NoLocator
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class WebElementLocatorAttribute:Attribute
    {
        public WebElementLocatorAttribute(LocatorTypeEnum locatorType, string locator)
        {
            this.ParseByDetails(locatorType, locator);
        }

        public By ByLocator  { get; set; }
        public string Locator { get; set; }

        private void ParseByDetails(LocatorTypeEnum locatorType, string locator)
        {
            By parsedBy = null;

            switch (locatorType)
            {
                case LocatorTypeEnum.Id:
                    parsedBy = By.Id(locator);
                    break;
                case LocatorTypeEnum.ClassName:
                    parsedBy = By.ClassName(locator);
                    break;
                case LocatorTypeEnum.Css:
                    parsedBy = By.CssSelector(locator);
                    break;
                case LocatorTypeEnum.Name:
                    parsedBy = By.Name(locator);
                    break;
                case LocatorTypeEnum.XPath:
                    parsedBy = By.XPath(locator);
                    break;
                case LocatorTypeEnum.PartialLinkText:
                    parsedBy = By.PartialLinkText(locator);
                    break;
                //The locator is ignored with this locator
                case LocatorTypeEnum.NoLocator:
                    parsedBy = By.TagName(locator);
                    break;
                default:throw new InvalidOperationException("Unhandled LocatorTypeEnum parsed in WebElementLocator ");
            }

            this.ByLocator = parsedBy;
        }
    }
}
