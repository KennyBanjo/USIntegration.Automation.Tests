using Automation.Core.Selenium.APIHandler;

namespace Automation.Core.Selenium.ApiHandler.JsonAccounts.CurrentReleaseJsonAccounts.EquifaxAccounts
{
    public class MultiIndividualToLoan
    {
	    /// <summary>
	    /// Link (EQUUK) WALLY SALWAY, EQUUK_SHELLI-ANN ANGELA RISBY and (EQUUK) URSULA CAVE to loan 
	    /// </summary>
        public static string AccountsToLink = $@"{{
	""records"": [
		{{
			""attributes"": {{
				""type"": ""LLC_BI__Legal_Entities__c"",
				""referenceId"": ""ref1""
			}},
			""LLC_BI__Loan__c"": ""{CurrentReleaseDataloader.LoanId[0]}"",
			""LLC_BI__Account__c"": ""{CurrentReleaseDataloader.Id[2]}"",
            ""LLC_BI__Borrower_Type__c"": ""Borrower""
		}},
        {{
			""attributes"": {{
				""type"": ""LLC_BI__Legal_Entities__c"",
				""referenceId"": ""ref2""
			}},
			""LLC_BI__Loan__c"": ""{CurrentReleaseDataloader.LoanId[0]}"",
            ""LLC_BI__Account__c"": ""{CurrentReleaseDataloader.Id[3]}"",
            ""LLC_BI__Borrower_Type__c"": ""Borrower""
		}}
	]
}}";
    }
}