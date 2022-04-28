using Automation.Core.Selenium.APIHandler;

namespace Automation.Core.Selenium.ApiHandler.JsonAccounts.CurrentReleaseJsonAccounts.EquifaxAccounts
{
    public class LinkEquifaxMultiAccountToLoan
    {
	    /// <summary>
	    /// Link (EQUUK) IMAGINATION TECHNOLOGIES LIMITED, (EQUUK) ONE FAMILY LIMITED and (EQUUK) CREATIVE TECHNOLOGIES to loan
	    /// </summary>
        public static string AccountsToLink = $@"{{
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
            ""LLC_BI__Account__c"": ""{CurrentReleaseDataloader.Id[1]}"",
            ""LLC_BI__Borrower_Type__c"": ""Borrower""
		}}
	]
}}";
    }
}