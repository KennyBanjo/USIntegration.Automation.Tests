using System;
using System.IO;
using System.Net;
using Automation.Core.Selenium.Config;
using TechTalk.SpecFlow;

namespace Automation.Core.Selenium.ComponentHelper
{
    [Binding]
    public class LogHelper
    {
        //Global Declaration
        private static string _logFileName = "logFile";
        private static StreamWriter _stream = null;


        //Create a file to store the log information
        
        public static void CreateLogFile()
        {
            string dir = @"/Users/kennybanjo/Desktop/CircleCI/TestResults/";
            if (Directory.Exists(dir))
            {
                Settings.FileCreated = true;
                _stream = File.AppendText(dir + _logFileName + ".log");
            }
            else
            {
                Settings.FileCreated = true;
                Directory.CreateDirectory(dir);
                _stream = File.AppendText(dir + _logFileName + ".log");
            }
        }

        //Create a methods to write test to the log file
        public static void Info(string logMessage)
        {
            _stream.Write("INFO {0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _stream.WriteLine("{0}", logMessage);
            _stream.Flush();
        }
        
        public static void Info(Exception logMessage)
        {
            _stream.Write("INFO {0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _stream.WriteLine("{0}", logMessage);
            _stream.Flush();
        }
        
        public static void Info(HttpStatusCode logMessage)
        {
            _stream.Write("INFO {0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _stream.WriteLine("{0}", logMessage);
            _stream.Flush();
        }

        
        public static void Error(string logMessage)
        {
            _stream.Write("ERROR {0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _stream.WriteLine("{0}", logMessage);
            _stream.Flush();
        }
        public static void Error(Exception logMessage)
        {
            _stream.Write("ERROR {0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _stream.WriteLine("{0}", logMessage);
            _stream.Flush();
        }

        public static void Warn(string logMessage)
        {
            _stream.Write("WARN {0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _stream.WriteLine("{0}", logMessage);
            _stream.Flush();
        }

    }
}
