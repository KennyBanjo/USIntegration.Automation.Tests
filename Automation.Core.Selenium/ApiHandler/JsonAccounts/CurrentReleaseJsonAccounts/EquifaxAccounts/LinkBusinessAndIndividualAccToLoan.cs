using System.Collections.Generic;
using Automation.Core.Selenium.APIHandler;
using Automation.Core.Selenium.ComponentHelper;
using Automation.Core.Selenium.Config;
using RestSharp;

namespace Automation.Core.Selenium.ApiHandler.JsonAccounts.CurrentReleaseJsonAccounts.EquifaxAccounts
{
    public static class LinkBusinessAndIndividualAccToLoan
    {
	    private static readonly string AccountToLink = $@"{{
	""records"": [
		{{
			""attributes"": {{
				""type"": ""LLC_BI__Legal_Entities__c"",
				""referenceId"": ""ref1""
			}},
			""LLC_BI__Loan__c"": ""{CurrentReleaseDataloader.LoanId[0]}"",
			""LLC_BI__Account__c"": ""{CurrentReleaseDataloader.Id[0]}"",
            ""LLC_BI__Borrower_Type__c"": ""Borrower""
		}},
		{{
			""attributes"": {{
				""type"": ""LLC_BI__Legal_Entities__c"",
				""referenceId"": ""ref2""
			}},
			""LLC_BI__Loan__c"": ""{CurrentReleaseDataloader.LoanId[0]}"",
			""LLC_BI__Account__c"": ""{CurrentReleaseDataloader.Id[2]}"",
            ""LLC_BI__Borrower_Type__c"": ""Borrower""
		}} 
	]
}}";
        
        public static void LinkMultiAccountsToLoan()
        {
	        Dictionary<string, string> headers = new Dictionary<string, string>()
	        {
		        {"Accept", "Application/json"},
		        {"Content-Type", "Application/json"}
	        };
	        CurrentReleaseRestClientHelper restClientHelper = new CurrentReleaseRestClientHelper();
	        var response = restClientHelper.PerformPostRequest(Settings.LinkLoanUrl, headers, null,
		        DataFormat.Json, AccountToLink);
	        if (response.IsSuccessful)
	        { 
		        LogHelper.Info("Post status code =>" + response.StatusCode);
		        LogHelper.Info("Post content => " +  response.Content);
		        LogHelper.Info("Accounts Linked");
	        }
	        else
	        {
		        LogHelper.Info("Api call failed =>" + response.StatusCode);
		        LogHelper.Info("Job content  =>" + response.Content);
		        LogHelper.Error("Call not made");
	        }
        }
    }
    
}