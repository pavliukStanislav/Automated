using System;
using TechTalk.SpecFlow;

namespace Automated.UI.Tests.Hooks.Tags.Examples
{
    [Binding]
    public class ExampleSpecflowHooks
    {
        private readonly ScenarioContext _scenarioContext;

        public ExampleSpecflowHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        //example after exact scenario
        [AfterScenario("Example")]
        public void AfterScenario()
        {
            Console.WriteLine($"After exact {_scenarioContext.ScenarioInfo.Title} scenario");
        }
    }
}
