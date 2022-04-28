namespace Automation.Core.Selenium.ApiHandler.JsonAccounts.CurrentReleaseJsonAccounts.EquifaxAccounts
{
    public static class CreateLoan
    {
        public static string LoanBody = @"{
	""records"": [
		{
			""attributes"": {
				""type"": ""LLC_BI__Loan__c"",
				""referenceId"": ""ref1""
			},
			""Name"": ""BusinessLoan_TestLoan"",
			""LLC_BI__Amount__c"": ""20000"",
            ""LLC_BI__Product__c"": ""CBILS Loan"",
            ""LLC_BI__Product_Type__c"": ""Non-Real Estate""
		}
	]
}";
    }
}

