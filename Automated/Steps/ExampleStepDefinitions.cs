using Automated.Data.Contracts;
using Automated.OtherTools;
using BoDi;
using OpenQA.Selenium;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automated.Steps
{
    [Binding]
    public sealed class ExampleStepDefinitions
    {
        private readonly IObjectContainer objectContainer;
        //unique for all scenarios. You can defind any object here and it will be unique for each scenario
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;
        private readonly ExampleContext _exampleContext;

        public ExampleStepDefinitions(
            ScenarioContext scenarioContext,
            ExampleContext exampleContext,
            FeatureContext featureContext,
            IObjectContainer oc)
        {
            _scenarioContext = scenarioContext;
            _exampleContext = exampleContext;
            _featureContext = featureContext;
            objectContainer = oc;
        }

        [Given(@"Simple step"), Scope(Tag = "exampleTag", Scenario = "Example", Feature = "ExampleFeature")]
        public void GivenSimpleStep()
        {
            //example of setting data in ScenarioContext
            _scenarioContext["exampleData"] = 4;

            Console.WriteLine(MethodBase.GetCurrentMethod().Name);

            var driver = objectContainer.Resolve<IWebDriver>();

            driver.Url = "https://www.google.com/";

            var element = driver.FindElement(By.XPath("//*[@id='hplogo']"));

            element.Click();

            Thread.Sleep(5000);
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

        //example type transformation
        [Then(@"Some step with argument transformation (.*)")]
        public void ThenSomeStepWithArgumentTransformationInDays(DateTime dt)
        {
            Console.WriteLine("Date time transformation");
            Console.WriteLine(dt);
        }

        //example file transformation
        [When(@"Some step with (.*) transformation")]
        public void WhenSomeStepWithXlsxFileTransformation(IWorkbook workbook)
        {
            var asd = workbook;
        }

        //example table transformation
        [When(@"Table step with transformation")]
        public void WhenTableStepWithTransformation(IEnumerable<ExampleTableItem> exampleTableItems)
        {
            var someData = exampleTableItems;
        }

        [When(@"some step with (.*) from example")]
        [Given(@"some step with (.*) from example")]
        public void GivenSomeStepWithFromExample(string p0)
        {
            Console.WriteLine(p0);
        }

    }
}
