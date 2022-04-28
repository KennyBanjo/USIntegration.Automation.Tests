using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Automation.Core.Selenium.Base;
using OpenQA.Selenium;


namespace Automation.Core.Selenium.ComponentHelper
{
    public class GenericHelper:BasePage
    {
        public static bool IsElementPresent(By byLocator)
        {
            return DriverContext.WebDriver.FindElements(byLocator).Count == 1;
        }

        
        public static void JsClick(IWebElement elem)
        {
           var jsExecutor =  DriverContext.WebDriver as IJavaScriptExecutor;
           jsExecutor.ExecuteScript("arguments[0].click();", elem);
           try
           {
                Thread.Sleep(1000);
           }
           catch (Exception e)
           {
               Console.WriteLine(e);
               throw;
           }
        }

        public static void TakeScreenShot(string fileName = "Screen")
        {

            var screen = DriverContext.WebDriver as ITakesScreenshot;
            var screenShot = screen.GetScreenshot();
            
            if (fileName.Equals("Screen"))
            {
                fileName = fileName + DateTime.UtcNow.ToString("yyyy MMMM dd") + ".png";
                LogHelper.Info(" " + "ScreenShot taken: " + fileName);
                return;
            }
            screenShot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
            LogHelper.Info(" " + "ScreenShot taken: " + fileName);
        }

        public static void TakeScreenShot(string directoryName, string fileName)
        {
             
            if (Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            fileName = GetPath(directoryName, fileName);
            var screen = DriverContext.WebDriver as ITakesScreenshot;
            var screenShot = screen.GetScreenshot();
            screenShot.SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
            LogHelper.Info("ScreenShot taken: " + fileName);
            return;
        }

        public static string GetPath(string directoryName, string fileName)
        {
            string location = Path.GetDirectoryName((Assembly.GetExecutingAssembly().Location));
            fileName = location + Path.DirectorySeparatorChar + directoryName + Path.DirectorySeparatorChar + fileName +
                       DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".png";
            return fileName;
        }
    }
}
