 using System;
using System.Collections.Generic;
using System.Text;
 using System.Threading;
 using Automation.Core.Selenium.APIHandler;
 using Automation.Core.Selenium.Base;
 using TechTalk.SpecFlow;


 namespace IntegrationAutomation.PreviousRelease.Tests.Hooks
{
    [Binding]
    class AfterScenarioHook:BasePage
    {
        [AfterScenario(@"EQStandardDB")]
        public void DeleteEquifaxDb()
        {
            CurrentReleaseDataloader.DeleteEquifaxData();
        }
        
        [AfterScenario(@"EQMultiLoanDB")]
        [AfterScenario(@"EQMultiIndDB")]
        [AfterScenario(@"EQIndividualLoanDB")]
        [AfterScenario(@"EQBusinessLoanDB")]
        [AfterScenario(@"EQBusinessAndIndDB")]
        public void DeleteEquifaxMultiLoanAccounts()
        {
            CurrentReleaseDataloader.DeleteEquifaxData();
            CurrentReleaseDataloader.DeleteLoan();
        }
        
        [AfterScenario(@"ExpMultiLoanDB")]
        [AfterScenario(@"ExpMultiIndDB")]
        [AfterScenario(@"ExpIndividualLoanDB")]
        [AfterScenario(@"ExpBusinessLoanDB")]
        [AfterScenario(@"ExpBusinessAndIndDB")]
        public void DeleteExperianMultiLoanAccounts()
        {
            CurrentReleaseDataloader.DeleteExperianData();
            CurrentReleaseDataloader.DeleteLoan();
        }
        
       

        
    }
}
