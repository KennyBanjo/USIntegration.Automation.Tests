using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Core.Selenium.Config
{
    public static class Settings
    {
        public static string Url { get; set; }
        
        public static string QaFallUrl { get; set; }

        public static string Twenty7TecUrl { get; set; }

        public static string Twenty7TecUsername { get; set; }
        
        public static string Twenty7TecPassword { get; set; }
        public static string  Username { get; set; }
        public static string  PreviousReleaseUsername { get; set; }
        public static string  PreviousReleasePassword { get; set; }
        
        public static string  QaFallUsername { get; set; }
        public static string ApiPassword  { get; set; }
        public static string Password  { get; set; }
        
        public static string QaFallPassword  { get; set; }
        
        public static string QaFallApiPassword  { get; set; }
        
        public static string ClientId { get; set; }
        
        public static string QaFallClientId { get; set; }

        public static string ClientSecret { get; set; }
        
        public static string QaFallClientSecret { get; set; }
        public static string ApiUrl { get; set; }
        
        public static string QaFallApiUrl { get; set; }
        
        public static string LoanUrl { get; set; }
        public static string QaFallLoanUrl { get; set; }

        public static string  LinkLoanUrl { get; set; }
        public static string  QaFallLinkLoanUrl { get; set; }

        public static string MiddlewareConfig { get; set; }
        
        public static string QaFallMiddlewareConfig { get; set; }

        public static string FileUpload { get; set; }

        public static string CompositesObjectUrl { get; set; }
        public static string QaFallCompositesObjectUrl { get; set; }

        public static bool _fileCreated = false;
        public static bool FileCreated
        {
            get
            {
                return _fileCreated;
            }
            set
            {
                _fileCreated = value;
            }
        }
    }
}
