namespace Automation.Core.Selenium.WebDriver.WebElementObjects.Interfaces
{
    public interface IAlertMessages
    {
        void Accept();

        void Dismiss();

        string ReturnAlertMessage();
    }
}