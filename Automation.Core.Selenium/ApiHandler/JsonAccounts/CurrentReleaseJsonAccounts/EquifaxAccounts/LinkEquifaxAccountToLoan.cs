using Automation.Core.Selenium.APIHandler;

namespace Automation.Core.Selenium.ApiHandler.JsonAccounts.CurrentReleaseJsonAccounts.EquifaxAccounts
{
    public static class LinkAccountToLoan
    {
	    public static readonly string AccountToLink = $@"{{
	""records"": [
		{{
			""attributes"": {{
				""type"": ""LLC_BI__Legal_Entities__c"",
				""referenceId"": ""ref1""
			}},
			""LLC_BI__Loan__c"": ""{CurrentReleaseDataloader.LoanId[0]}"",
			""LLC_BI__Account__c"": ""{CurrentReleaseDataloader.Id[0]}"",
            ""LLC_BI__Borrower_Type__c"": ""Borrower""
		}} 
	]
}}";
    }
}