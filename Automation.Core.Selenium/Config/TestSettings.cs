using Newtonsoft.Json;


namespace Automation.Core.Selenium.Config
{
    [JsonObject("testSettings")]
    public class TestSettings
    {
        [JsonProperty("Url")]
        public string Url { get; set; }
        
        [JsonProperty("QaFallUrl")]
        public string QaFallUrl { get; set; }
        
        [JsonProperty("Twenty7TecUrl")]
        public string Twenty7TecUrl { get; set; }
        
        [JsonProperty("Twenty7TecUsername")]
        public string Twenty7TecUsername { get; set; }
        
        [JsonProperty("Twenty7TecPassword")]
        public string Twenty7TecPassword { get; set; }

        [JsonProperty("QaFallUsername")]
        public string QaFallUsername { get; set; }
        
        [JsonProperty("QaFallPassword")]
        public string QaFallPassword { get; set; } 
        
        [JsonProperty("QaFallApiPassword")]
        public string QaFallApiPassword { get; set; }
        
        [JsonProperty("Username")]
        public string Username { get; set; } 
        
        [JsonProperty("PreviousReleaseUsername")]
        public string PreviousReleaseUsername { get; set; }
        
        [JsonProperty("PreviousReleasePassword")]
        public string PreviousReleasePassword { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }
        
        [JsonProperty("ApiPassword")]
        public string ApiPassword { get; set; }

        [JsonProperty("ApiUrl")]
        public string ApiUrl { get; set; } 
        
        [JsonProperty("QaFallApiUrl")]
        public string QaFallApiUrl { get; set; }
        
        [JsonProperty("LoanUrl")]
        public string LoanUrl { get; set; }
        
        [JsonProperty("QaFallLoanUrl")]
        public string QaFallLoanUrl { get; set; }
        
        [JsonProperty("LinkLoanUrl")]
        public string LinkLoanUrl { get; set; }
        
        [JsonProperty("QaFallLinkLoanUrl")]
        public string QaFallLinkLoanUrl { get; set; }
        
        [JsonProperty("Middleware")]
        public string MiddlewareConfig { get; set; }
        
        [JsonProperty("QaFallMiddleware")]
        public string QaFallMiddlewareConfig { get; set; }
        
        [JsonProperty("FileUpload")]
        public string FileUpload { get; set; }
        
        [JsonProperty("CompositesObjectUrl")]
        public string CompositesObjectUrl { get; set; }
        
        [JsonProperty("QaFallCompositesObjectUrl")]
        public string QaFallCompositesObjectUrl { get; set; }
        
        [JsonProperty("ClientId")] 
        public string ClientId { get; set; }
        
        [JsonProperty("QaFallClientId")] 
        public string QaFallClientId { get; set; }
        
        [JsonProperty("QaFallClientSecret")] 
        public string QaFallClientSecret { get; set; }
        
        [JsonProperty("ClientSecret")] 
        public string ClientSecret { get; set; }
    }
}
