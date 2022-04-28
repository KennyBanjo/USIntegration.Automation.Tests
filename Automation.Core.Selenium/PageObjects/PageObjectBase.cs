using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Selenium.Base;
using Automation.Core.Selenium.WebDriver.WebDriver.WebElementObjects;
using Automation.Core.Selenium.WebDriver.WebDriver.WebElementObjects.Attributes;
using Automation.Core.Selenium.WebDriver.WebElementObjects;
using OpenQA.Selenium;

namespace Automation.Core.Selenium.PageObjects
{
    public class PageObjectBase
    {
        private IWebDriver Driver { get; set; }
        private bool WaitForAjax { get; set; }
        private string PageUrl { get; set; }

        private string BaseUrl;
        public PageObjectBase(IWebDriver driver, bool useWaitForAjax = true)
        {
            Driver = driver;
            InitialiseFields();
            WaitForAjax = useWaitForAjax;
        }

        private void InitialiseFields()
        {
            var fields = GetType().GetFields();
            foreach (var field in fields)
            {
                var webElementLocatorAttribute =
                    FieldAttributeHelper<WebElementLocatorAttribute>.ReturnAttribute(field);
                var dataBindingAttribute = FieldAttributeHelper<DataBindingAttribute>.ReturnAttribute(field);
                var viewModelBindingAttribute = FieldAttributeHelper<ViewModelBindingAttribute>.ReturnAttribute(field);

                if (webElementLocatorAttribute.Count < 0) continue;

                var constructor = field.FieldType.GetConstructor(new Type[] { });
                var instance = constructor?.Invoke(new object[] { });
                if (instance is WebElementObjectBase)
                {
                    var controlBase = instance as WebElementObjectBase;
                    controlBase.ByLocator = webElementLocatorAttribute[0].ByLocator;
                    controlBase.Locator = webElementLocatorAttribute[0].Locator;
                    controlBase.Driver= Driver;
                    controlBase.UseWaitAjax = WaitForAjax;
                    controlBase.Url = BaseUrl +PageUrl;
                    controlBase.BindedDataAttribute =
                        dataBindingAttribute.Count <= 0 ? null : dataBindingAttribute[0].Value;
                    controlBase.ViewModelBinding =
                        viewModelBindingAttribute.Count <= 0 ? null : viewModelBindingAttribute[0].Value;
                }
                field.SetValue(this,instance);
            }
        }

    }
}
