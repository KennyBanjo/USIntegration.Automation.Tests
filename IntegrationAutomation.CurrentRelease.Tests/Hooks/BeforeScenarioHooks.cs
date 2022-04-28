using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Automation.Core.Selenium.APIHandler;
using Automation.Core.Selenium.ApiHandler.JsonAccounts.CurrentReleaseJsonAccounts.EquifaxAccounts;
using Automation.Core.Selenium.Base;
using TechTalk.SpecFlow;

namespace IntegrationAutomation.PreviousRelease.Tests.Hooks
{
    [Binding]
    public class BeforeScenarioHooks:BasePage
    {
        [BeforeScenario(@"EQStandardDB")]
        public void EquifaxStandardDb()
        {
            CurrentReleaseDataloader.LoadEquifaxData();
        }
        
        [BeforeScenario(@"EXStandardDB")]
        public void ExperianStandardDb()
        {
            CurrentReleaseDataloader.LoadEquifaxData();
        }
  
        [BeforeScenario(@"EQBusinessLoanDB")]
        public void SetEquifaxAccountLoanDb()
        {
            CurrentReleaseDataloader.CreateLoan();
            CurrentReleaseDataloader.LoadEquifaxData();
            CurrentReleaseDataloader.LinkLoanToAccount();
        }

        [BeforeScenario(@"EQIndividualLoanDB")]
        public void SetPersonLoanDb()
        {
            CurrentReleaseDataloader.CreateLoan();
            CurrentReleaseDataloader.LoadEquifaxData();
            CurrentReleaseDataloader.LinkLoanToPerson();
        }
        
        [BeforeScenario(@"EQMultiLoanDB")]
        public void SetEquifaxMultiLoanDb()
        {
            CurrentReleaseDataloader.CreateLoan();
            CurrentReleaseDataloader.LoadEquifaxData();
            CurrentReleaseDataloader.LinkMultiAccountsToLoan();
        }
        
        [BeforeScenario(@"EQMultiIndDB")]
        public void SetEquifaxMultiIndLoanDb()
        {
            CurrentReleaseDataloader.CreateLoan();
            CurrentReleaseDataloader.LoadEquifaxData();
            CurrentReleaseDataloader.LinkMultiIndividualsToLoan();
        }
        
        [BeforeScenario(@"EQBusinessAndIndDB")]
        public void SetEquifaxBusinessAndIndLoanDb()
        {
            CurrentReleaseDataloader.CreateLoan();
            CurrentReleaseDataloader.LoadEquifaxData();
            LinkBusinessAndIndividualAccToLoan.LinkMultiAccountsToLoan();
        }
    }
}
