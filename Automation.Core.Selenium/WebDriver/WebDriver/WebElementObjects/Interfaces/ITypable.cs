namespace Automation.Core.Selenium.WebDriver.WebElementObjects.Interfaces
{
    public interface ITypable
    {
        void EnterText(string text);
        string GetText();
        string GetValue();
        void ClearText();
    }
}