using System;
using System.Diagnostics;
using Automation.Core.Selenium.ComponentHelper;
using TechTalk.SpecFlow;

namespace UIAutomation.Integration.Tests.Hooks
{
    [Binding]
    public class StepHook
    {
        private readonly Stopwatch stopwatch = new Stopwatch();
        private static ScenarioContext _scenarioContext;
        private string step;

        public StepHook(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeStep]
        public void BeforeStep(ScenarioContext scenarioContext)
        {
            step = $"{scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString()} {scenarioContext.StepContext.StepInfo.Text}";
            LogHelper.Info(" " + step);
            stopwatch.Restart();
        }

        [AfterStep]
        public void AfterStep()
        {
            stopwatch.Stop();
            var message = $"{" " + step} ({stopwatch.ElapsedMilliseconds / 1000.0:0.0}s)";
            if(stopwatch.ElapsedMilliseconds > 30000)
            {
                LogHelper.Warn(message);
            }
            else
            {
                LogHelper.Info(message);
            }
        }
    }
}
