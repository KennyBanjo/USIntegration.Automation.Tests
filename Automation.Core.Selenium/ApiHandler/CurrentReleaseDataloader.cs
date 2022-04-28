using System.Collections.Generic;
using System.Linq;
using System.Net;
using Automation.Core.Selenium.ApiHandler.JsonAccounts.CurrentReleaseJsonAccounts.EquifaxAccounts;
using Automation.Core.Selenium.APIHandler.JsonAccounts.CurrentReleaseJsonAccounts.ExperianAccount;
using Automation.Core.Selenium.ComponentHelper;
using Automation.Core.Selenium.Config;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Automation.Core.Selenium.APIHandler
{
    public class CurrentReleaseDataloader
    {
        public static List<string> Id;
        public static List<string> LoanId;
        public static List<string> TokenId;
        
        public static void LoadEquifaxData()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                {"Accept", "Application/json"},
                {"Content-Type", "Application/json"}
            };
            CurrentReleaseRestClientHelper restClientHelper = new CurrentReleaseRestClientHelper();
            var response = restClientHelper.PerformPostRequest(Settings.ApiUrl, headers, null,
                DataFormat.Json, AddEquifaxAccounts.AccountCredentials);
            if (response.IsSuccessful)
            {
                LogHelper.Info("Post status code =>" + response.StatusCode);
                LogHelper.Info("Post content => " + response.Content);
                //logger.Info("Call successful");
                JObject jObject = JObject.Parse(response.Content);
                var list = jObject.SelectTokens("$..id").Select(t => t.Value<string>()).ToList();
                Id = list;
            }
            else
            {
                LogHelper.Info("Api call failed  " + response.StatusCode);
                LogHelper.Info("Job content  =>" +  response.Content);
                LogHelper.Error("Api call not made");
            }
        } 
        
        public static void LoadExperianData()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                {"Accept", "Application/json"},
                {"Content-Type", "Application/json"}
            };
            CurrentReleaseRestClientHelper restClientHelper = new CurrentReleaseRestClientHelper();
            var response = restClientHelper.PerformPostRequest(Settings.ApiUrl, headers, null,
                DataFormat.Json, AddExperianAccounts.experianAccounts);
            if (response.IsSuccessful)
            {
                LogHelper.Info("Post status code =>" + response.StatusCode);
                LogHelper.Info("Post content => " + response.Content);
                //logger.Info("Call successful");
                JObject jObject = JObject.Parse(response.Content);
                var list = jObject.SelectTokens("$..id").Select(t => t.Value<string>()).ToList();
                Id = list;
            }
            else
            {
                LogHelper.Info("Api call failed  " + response.StatusCode);
                LogHelper.Info("Job content  =>" +  response.Content);
                LogHelper.Error("Api call not made");
            }
        } 
        
        public static void DeleteEquifaxData()
        {
            var url = $"https://bankr-3316--data.cloudforce.com/services/data/v50.0/tooling/executeAnonymous?anonymousBody=QaUtility.deleteAccounts(new List<Id>{{'{Id[0]}','{Id[1]}','{Id[2]}','{Id[3]}'}});";
            CurrentReleaseRestClientHelper restClientHelper = new CurrentReleaseRestClientHelper();
            var response = restClientHelper.PerformGetRequest(url, null);
            if (response.IsSuccessful)
            {
                LogHelper.Info("Accounts deleted" + response.Content);
            }
            else
            {
                LogHelper.Error("Accounts not deleted" + response.Content);
            }
        }
        
         public static void DeleteExperianData()
        {
            var url = $"https://bankr-3316--data.cloudforce.com/services/data/v50.0/tooling/executeAnonymous?anonymousBody=QaUtility.deleteAccounts(new List<Id>{{'{Id[0]}','{Id[1]}','{Id[2]}'}});";
            CurrentReleaseRestClientHelper restClientHelper = new CurrentReleaseRestClientHelper();
            var response = restClientHelper.PerformGetRequest(url, null);
            if (response.IsSuccessful)
            {
                LogHelper.Info("Accounts deleted" + response.Content);
            }
            else
            {
                LogHelper.Error("Accounts not deleted" + response.Content);
            }
        }
        
        public static void DeleteLoan()
        {
            var url =
                $"https://bankr-3316--data.cloudforce.com/services/data/v50.0/composite/sobjects?ids={LoanId[0]}&allOrNone=false";
            CurrentReleaseRestClientHelper restClientHelper = new CurrentReleaseRestClientHelper();
            IRestResponse restResponse = restClientHelper.PerformDeleteRequest(url, null);
            LogHelper.Info(restResponse.Content);
        }
        
        public static void CreateLoan()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                {"Accept", "Application/json"},
                {"Content-Type", "Application/json"}
            };
            CurrentReleaseRestClientHelper restClientHelper = new CurrentReleaseRestClientHelper();
            var response = restClientHelper.PerformPostRequest(Settings.LoanUrl, headers, null,
                DataFormat.Json, ApiHandler.JsonAccounts.CurrentReleaseJsonAccounts.EquifaxAccounts.CreateLoan.LoanBody);
            if (response.IsSuccessful)
            {
                LogHelper.Info("Loan created, Post status code => " + response.StatusCode);
                LogHelper.Info("Post content => " + response.Content);
                JObject jObject = JObject.Parse(response.Content);
                var list = jObject.SelectTokens("$..id").Select(t => t.Value<string>()).ToList();
                LoanId = list;
            }
            else
            {
                LogHelper.Info("Loan not created, Api call failed =>" + response.StatusCode);
                LogHelper.Info("Job content =>" + response.Content);
                LogHelper.Error("Api call not made");
            }
        }
        
        public static void LinkLoanToAccount()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                {"Accept", "Application/json"},
                {"Content-Type", "Application/json"}
            };
            CurrentReleaseRestClientHelper restClientHelper = new CurrentReleaseRestClientHelper();
            var response = restClientHelper.PerformPostRequest(Settings.LinkLoanUrl, headers, null,
                DataFormat.Json, LinkAccountToLoan.AccountToLink);
            if (response.IsSuccessful)
            { 
                LogHelper.Info(" Account linked, Post status code =>" + response.StatusCode);
                LogHelper.Info(" Post content => " + response.Content);
            }
            else
            {
                LogHelper.Info("Account not linked, Api call failed =>" + response.StatusCode);
                LogHelper.Info("Job content  =>" + response.Content);
            }
        }
        
        public static void LinkLoanToPerson()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                {"Accept", "Application/json"},
                {"Content-Type", "Application/json"}
            };
            CurrentReleaseRestClientHelper restClientHelper = new CurrentReleaseRestClientHelper();
            var response = restClientHelper.PerformPostRequest(Settings.LinkLoanUrl, headers, null,
                DataFormat.Json, LinkPersonToLoan.Person);
            if (response.IsSuccessful)
            {
                LogHelper.Info("Post status code =>" +  response.StatusCode);
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
        
        public static void LinkMultiAccountsToLoan()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                {"Accept", "Application/json"},
                {"Content-Type", "Application/json"}
            };
            CurrentReleaseRestClientHelper restClientHelper = new CurrentReleaseRestClientHelper();
            var response = restClientHelper.PerformPostRequest(Settings.LinkLoanUrl, headers, null,
                DataFormat.Json, LinkEquifaxMultiAccountToLoan.AccountsToLink);
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
        
        public static void LinkMultiIndividualsToLoan()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                {"Accept", "Application/json"},
                {"Content-Type", "Application/json"}
            };
            CurrentReleaseRestClientHelper restClientHelper = new CurrentReleaseRestClientHelper();
            var response = restClientHelper.PerformPostRequest(Settings.LinkLoanUrl, headers, null,
                DataFormat.Json, MultiIndividualToLoan.AccountsToLink);
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