namespace Automation.Core.Selenium.APIHandler.Token
{
    public class TokenResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }

        public string getCredential()
        {
            return $"{token_type} {access_token}";
        }
    }
}