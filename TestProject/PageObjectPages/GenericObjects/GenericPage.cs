
using Automation.Core.Selenium.Base;
using Automation.Core.Selenium.PageObjects;
using Automation.Core.Selenium.WebDriver.WebDriver.WebElementObjects.Attributes;
using Automation.Core.Selenium.WebDriver.WebDriver.WebElementObjects.WebElements;

using OpenQA.Selenium;
using Label = Automation.Core.Selenium.WebDriver.WebDriver.WebElementObjects.WebElements.Label;

namespace IntegrationAutomation.CurrentRelease.Tests.PageObjectPages.GenericObjects
{
    public class GenericPage:PageObjectBase
    {
        public GenericPage(bool useWaitForAjax = true) : base(DriverContext.WebDriver, useWaitForAjax)
        {
        }

        [WebElementLocator(LocatorTypeEnum.Css, "")]
        public Button GenericWindowButton;

        [WebElementLocator(LocatorTypeEnum.Css, "")]
        public TextField GenericTextfield;

        [WebElementLocator(LocatorTypeEnum.Css, "")]
        public Label GenericWindowLabel;

        [WebElementLocator(LocatorTypeEnum.Css, "")]
        public CheckBox GenericCheckBox;

        [WebElementLocator(LocatorTypeEnum.XPath, "")]
        public Frame GenericFrame;

        [WebElementLocator(LocatorTypeEnum.XPath, "")]
        public Table GenericTable;

        [WebElementLocator(LocatorTypeEnum.XPath, "")]
        public ButtonDropDown GenericDropdown;

        [WebElementLocator(LocatorTypeEnum.XPath, "")]
        public Radio GenericRadioButton;

        [WebElementLocator(LocatorTypeEnum.XPath, "//div[contains(text(),'Loading...')]")]
        public Label LoadingIcon;

        /// <summary>
        /// This method helps to get buttons across the system by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Button GetButtonByName(string name)
        {
            GenericWindowButton.ByLocator = By.CssSelector($"[name = '{name}']");
            return GenericWindowButton;
        }

        public Button GetButtonByCss(string buttonName)
        {
            GenericWindowButton.ByLocator = By.CssSelector($"[title= '{buttonName}']," +
                                                           $"[type='{buttonName}']," +
                                                           $"[name ='{buttonName}']," +
                                                           $"[value = '{buttonName}']," +
                                                           $"[id = '{buttonName}']," +
                                                           $"[data-automationid = '{buttonName}']," +
                                                           $"[uni-has-permission='{buttonName}']," +
                                                           $"[data-toggle='{buttonName}']");
            return GenericWindowButton;
        }

        public Button GetButtonFromMultiElementsByXpath(string element, int elementNumber)
        {
            GenericWindowButton.ByLocator = By.XPath($"(//span[contains(text(),'{element}')])[{elementNumber}]");
            return GenericWindowButton;
        } 
        
        public Button GetButtonFromMultiElementsBycss(string element, int elementNumber)
        {
            GenericWindowButton.ByLocator = By.XPath($"(//div[@data-toggle='{element}'])[{elementNumber}]");
            return GenericWindowButton;
        }
        public Label GetlabelFromMultiElementsByXpath(string element, int elementNumber)
        {
            GenericWindowLabel.ByLocator = By.XPath($"(//span[contains(text(),'{element}')])[{elementNumber}] | (//div[@placeholder ='{element}'])[{elementNumber}]");
            return GenericWindowLabel;
        }

        public Button GetBusinessLookupButton(string element)
        {
            GenericWindowButton.ByLocator = By.XPath($"//*[@class='slds-no-flex']//*[contains(text(),'{element}')]");
            return GenericWindowButton;
        }

        
        /// <summary>
        /// This method gets textfield by xpath across the system.
        /// </summary>
        /// <param name="name"></param>
        /// 
        /// <returns></returns>
        public TextField GetTextFieldByxPath(string TextFieldName)
        {
            GenericTextfield.ByLocator = By.XPath($"//*[@id='{TextFieldName}' or" +
                                                  $"@placeholder = '{TextFieldName}' or" +
                                                  $"@title = '{TextFieldName}' or" +
                                                  $"@type = '{TextFieldName}' or " +
                                                  $"@name = '{TextFieldName}']");
            return GenericTextfield;
        }

        public TextField GetCBILSTextfieldByCss(string textFieldName)
        {
            GenericTextfield.ByLocator = By.CssSelector($"[name= '{textFieldName}']");
            return GenericTextfield;
        }

        public TextField  GetTextFieldByXpathText(string text)
        {
            GenericTextfield.ByLocator = By.XPath($"//*[contains(text(),'{text}')]");
            return GenericTextfield;
        }

       /// <summary>
       /// This method gets the textfield by css. Provide elementName when called.
       /// </summary>
       /// <param name="textFieldName"></param>
       /// <returns></returns>
        public TextField GetTextFieldByCss(string textFieldName)
        {
            GenericTextfield.ByLocator = By.CssSelector($"[type='{textFieldName}']," +
                                                        $"[value='{textFieldName}']," +
                                                        $"[name = '{textFieldName}']," +
                                                        $"[list='{textFieldName}']," +
                                                        $"[aria-label='{textFieldName}']");
           
            return GenericTextfield;
        }

       /// <summary>
       /// This method gets buttons by xpath. Provide elementName when called
       /// </summary>
       /// <param name="elementName"></param>
       /// <returns></returns>
        public Button GetButtonByxPath(string elementName)
       {
           GenericWindowButton.ByLocator = By.XPath($"//*[@title='{elementName}' or " +
                                                    $"@class = '{elementName}' or " +
                                                    $"@id = '{elementName}' or" +
                                                    $"@value='{elementName}']");
            
            return GenericWindowButton;
        }
        /// <summary>
        /// Get button by xpath where only the text forms the xpath
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
       public Button GetButtonByXPathText(string text)
        {
            GenericWindowButton.ByLocator = By.XPath($"//*[contains(text(),'{text}')] | //button[@name='{text}'] | //button[@title='{text}'] | //button[contains(text(),'{text}')] | //*[@ng-click='{text}'] | //*[@value='{text}' or " +
                                                     $"@class='ng-scope item']//*[contains(text(),'{text}') or" +
                                                     $"@class='slds-no-flex']//*[contains(text(),'{text}')]"); 
           return GenericWindowButton;
        }

        public Button GetButtonByText(string buttonName)
        {
            GenericWindowButton.ByLocator = By.XPath($"//span[contains(text(),'{buttonName}')] | //a[contains(text(),'{buttonName}')]");
            return GenericWindowButton;
        }
        
        
        
        public Button GetButtonWithButtonAnchor(string buttonName)
        {
            GenericWindowButton.ByLocator = By.XPath($"//button[contains(text(),'{buttonName}')] | //button[@title='{buttonName}']");
            return GenericWindowButton;
        }

         public Button GetButtonByLinkText(string elementName)
       {
           GenericWindowButton.ByLocator = By.LinkText($"{elementName}");
           return GenericWindowButton;
       }

        //public Button GetButtonByName(string buttonName)
        //{
        //    GenericWindowButton.ByLocator = By.XPath($"//button[@name='{buttonName}']");
        //    return GenericWindowButton;
        //}

        public Button GetButtonByClass(string text)
        {
            GenericWindowButton.ByLocator = By.XPath($"//*[contains(@class, '{text}')] | //input[@value='{text}']");
            return GenericWindowButton;
        }

        public Button GetButtonByInput(string element)
        {
            GenericWindowButton.ByLocator = By.XPath($"//input[@value='{element}'");
            return GenericWindowButton;
        }

        public Label GetLabelByText(string elementName)
        {
            GenericWindowLabel.ByLocator = By.XPath($"//span[contains(text(),'{elementName}')] | //div[contains(text(),'{elementName}')] | //h3[contains(text(),'{elementName}')] | //h2[contains(text(),'{elementName}')] | //b[contains(text(),'{elementName}')] | //p[contains(text(),'{elementName}')] | //a[contains(text(),'{elementName}')] | //button[contains(text(), '{elementName}')]");
            return GenericWindowLabel;
        }

        public Label GetLabelByCss(string labelName)
        {
            GenericWindowLabel.ByLocator = By.CssSelector($"[title = '{labelName}']," +
                                                          $"[ng-if='{labelName}']");
            return GenericWindowLabel;
        }

        public Label GetLabelByXPath(string elementName)
        {
            GenericWindowLabel.ByLocator = By.XPath($"//a[@title='{elementName}'] | //*[contains(text(),'{elementName}')]");
            return GenericWindowLabel;
        }

        /// <summary>
        /// This is to get the salesforce tabs
        /// </summary>
        /// <param name="elementName"></param>
        /// <returns></returns>
        public Button GetTabByXPath(string elementName)
        {
            GenericWindowButton.ByLocator = By.XPath($"//a[@title = '{elementName}'] | //a[@data-label = '{elementName}']");
            return GenericWindowButton;
        }

        public CheckBox GetPluginCheckboxByXPath(string checkBoxName)
        {
            GenericCheckBox.ByLocator = By.XPath($"//tr[.//a[contains(text(), '{checkBoxName}')]]//*[@ng-click='toggleActivation(plugin)']");
            return GenericCheckBox;
        }

        public Radio GetRadioButtonByXPath(string elementName)
        {
            GenericRadioButton.ByLocator = By.XPath($"//tr[.//*[contains(text(), '{elementName}')]]//*[@class='slds-radio']");
            return GenericRadioButton;
        }

        public Frame GetLoanFrameByXPath(string frameTitle)
        {
            GenericFrame.ByLocator = By.XPath($"//*[@class='content iframe-parent']//iframe[@title='{frameTitle}']");
            return GenericFrame;
        }
         public Frame GetLoanFrameWithMultiElementsByXPath(string frameTitle, int elementNumber)
        {
            GenericFrame.ByLocator = By.XPath($"(//*[@class='content iframe-parent']//iframe[@title='{frameTitle}'])[{elementNumber}]");
            return GenericFrame;
        }
        
        public Frame GetFrameByXPath(string frameTitle)
        {
            GenericFrame.ByLocator = By.XPath($"//*[@class='iframe-parent slds-template_iframe slds-card']//iframe[@title='{frameTitle}']");
            return GenericFrame;
        }

        /// <summary>
        /// Gets elements in a table. Add xpaths as needed separating by 'or'
        /// </summary>
        /// <param name="columnNUmber"></param>
        /// <returns></returns>
        public Table GetTableRowDataByXPath(int rowNumber, int columnNumber)
        {
            GenericTable.ByLocator = By.XPath($"//table[@class='lds-table']//tbody[{rowNumber}]//tr//td[{columnNumber}] | //table[@role='grid']//tbody//tr[{rowNumber}]//td[{columnNumber}]");
            return GenericTable;
        }

        /// <summary>
        /// Use to click configure button under Quick Links -> system configuration
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public Table GetSystemConfigTable(int row, int column)
        {
            GenericTable.ByLocator =
                By.XPath($"//table[@class ='table table-striped  table-hover']//tbody//tr[{row}]//td[{column}]//*[@value = 'Configure']");
            return GenericTable;
        }

        public Table GetTableHeadsByXPath(int columnNUmber)
        {
            GenericTable.ByLocator = By.XPath($"//table[@class='lds-table']//tr//th[{columnNUmber}]");
            return GenericTable;
        }

        /// <summary>
        /// Gets modal header using xpath
        /// </summary>
        /// <param name="modalName"></param>
        /// <returns></returns>
        public Label GetModalNameByXPath(string modalName)
        { 
            GenericWindowLabel.ByLocator =
                By.XPath($"//*[contains(text(), '{modalName}')]");
            return GenericWindowLabel;
        }

        public Button GetModalButtonByXPath(string buttonName)
        {
            GenericWindowButton.ByLocator =
                By.XPath($"//div[@class='slds-modal__footer']//button[contains(text(),'{buttonName}')]");
            return GenericWindowButton;
        }

        public Label GetLoadingBox(string elementName)
        {
            GenericWindowLabel.ByLocator = By.XPath($"//div[@id='{elementName}']");
            return GenericWindowLabel;
        }

        public ButtonDropDown GetDropdownByXpath(string elementName)
        {
            GenericDropdown.ByLocator = By.XPath($"//*[@name='{elementName}'] | //*[@title = '{elementName}']");
            return GenericDropdown;
        }
        public ButtonDropDown GetDropdownCss(string elementName)
        {
            GenericDropdown.ByLocator = By.CssSelector($"[list='{elementName}']," +
                                                       $"[value='{elementName}']," +
                                                       $"[name='{elementName}']");
            return GenericDropdown;
        }

        public Label GetErrorMsgByXPath(string element)
        {
            GenericWindowLabel.ByLocator =By.XPath($"//*[contains(text(),'{element}')] | //p[normalize-space(.)='{element}']");
            return GenericWindowLabel;
        }

        public Label GetErrorLabelByXpath(string element)
        {
            GenericWindowLabel.ByLocator =By.XPath($"//h2[contains(text(),'{element}')]");
            return GenericWindowLabel;
        }

        public TextField GetOnfidoImagePath(int imageInput)
        {
            GenericTextfield.ByLocator = By.XPath($"(//input[@type='file'])[{imageInput}]");
            return GenericTextfield;
        }
        public TextField GetLoanImagePath(string elementName)
        {
            GenericTextfield.ByLocator = By.XPath($"//input[@id='{elementName}']");
            return GenericTextfield;
        }

        public TextField GetContactAddressFields(string element)
        {
            GenericTextfield.ByLocator = By.XPath($"(//lightning-formatted-text[contains(text(),'{element}')]");
            return GenericTextfield;
        }

        public CheckBox GetCheckboxByName(string element)
        {
            GenericCheckBox.ByLocator = By.XPath($"//input[@name='{element}'] | //input[@id = '{element}']");
            return GenericCheckBox;
        }
    }
}
