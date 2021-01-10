using Automated.OtherTools;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automated.Steps
{
    [Binding]
    public sealed class ExampleStepDefinitions
    {
        //unique for all scenarios. You can defind any object here and it will be unique for each scenario
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;
        private readonly ExampleContext _exampleContext;

        public ExampleStepDefinitions(
            ScenarioContext scenarioContext,
            ExampleContext exampleContext,
            FeatureContext featureContext)
        {
            _scenarioContext = scenarioContext;
            _exampleContext = exampleContext;
            _featureContext = featureContext;
        }

        [Given(@"Simple step"), Scope(Tag = "exampleTag", Scenario = "Example", Feature = "ExampleFeature")]
        public void GivenSimpleStep()
        {
            //example of setting data in ScenarioContext
            _scenarioContext["exampleData"] = 4;

            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        [Then(@"Simple step with parameter (.*)")]
        public void ThenSimpleStepWithParameter(int p0)
        {
            //example of getting ScenarioContextData
            Console.WriteLine("Data from context: " + _scenarioContext.Get<int>("exampleData"));

            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        [Given(@"Async step")]
        public async Task GivenAsyncStep()
        {
            await (new ClassHelper()).GetTask();
        }

        [When(@"Table step")]
        public void WhenTableStep(Table table)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);

            foreach (var item in table.Header)
            {
                Console.WriteLine(item);
            }

            foreach (var item in table.Rows)
            {
                Console.WriteLine("Keys:");
                Console.WriteLine(item.Keys.Aggregate((i, j) => i + " " + j));
                Console.WriteLine("values:");
                Console.WriteLine(item.Values.Aggregate((i, j) => i + " " + j));
            }
        }

        //example after exact scenario
        [AfterScenario("Example")]
        public void AfterScenario()
        {
            Console.WriteLine($"After exact {_scenarioContext.ScenarioInfo.Title} scenario");
        }

        [Then(@"Some step with argument transformation in (.*) days")]
        public void ThenSomeStepWithArgumentTransformationInDays(int p0)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
