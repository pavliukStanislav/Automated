using Automated.Data.Examples.Contracts;
using Automated.OtherTools.Examples;
using BoDi;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Automated.Steps
{
    [Binding]
    public sealed class ExampleSpecflowSteps
    {
        private readonly IObjectContainer _objectContainer;
        //unique for all scenarios. You can defind any object here and it will be unique for each scenario
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;
        private readonly ExampleContext _exampleContext;

        public ExampleSpecflowSteps(
            ScenarioContext scenarioContext,
            ExampleContext exampleContext,
            FeatureContext featureContext,
            IObjectContainer objectContainer)
        {
            _scenarioContext = scenarioContext;
            _exampleContext = exampleContext;
            _featureContext = featureContext;
            _objectContainer = objectContainer;
        }

        [Given(@"Simple scoped step"), Scope(Tag = "exampleTag", Scenario = "Tag scoping example", Feature = "Example specflow")]
        public void GivenSimpleScopedStep()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);

            //var driver = objectContainer.Resolve<IWebDriver>();
            //driver.Url = "https://www.google.com/"; 
            //var element = driver.FindElement(By.XPath("//*[@id='hplogo']"));
            //element.Click();
        }

        [Given(@"Simple step")]
        public void GivenSimpleStep()
        {
            Console.WriteLine("Simple step");

            //example of setting data in ScenarioContext
            _scenarioContext["exampleData"] = 4;
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
            await GetTask();
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
            Console.WriteLine("Some step with xlsx file transformation");
        }

        //example table transformation
        [When(@"Table step with transformation")]
        public void WhenTableStepWithTransformation(IEnumerable<ExampleTableItem> exampleTableItems)
        {
            Console.WriteLine("Some step with xlsx file transformation");
        }

        [Given(@"simple given for report")]
        public void GivenSimpleGivenForReport()
        {
            Console.WriteLine("simple given for report");
        }

        [When(@"simple when foe report")]
        public void WhenSimpleWhenFoeReport()
        {
            Console.WriteLine("simple when for report");
        }
         
        [Then(@"simple then for report")]
        public void ThenSimpleThenForReport()
        {
            Console.WriteLine("simple then for report");
            //exsmple failed step
            (true).Should().BeFalse();
        }

        [Given(@"Create instance from table")]
        public void GivenCreateInstanceFromTable(Table table)
        {
            var instance = table.CreateInstance<ExampleTableItem>();
            Console.WriteLine("This is output");
            Console.WriteLine(instance.First);
        }

        [When(@"Create another instanse from tabe")]
        public void WhenCreateAnotherInstanseFromTabe(Table table)
        {
            var inst = table.CreateInstance<ExampleTableItem>();

            Console.WriteLine("This is out:");
            Console.WriteLine(inst.First);
        }

        [When(@"Compare instance")]
        public void WhenCompareInstance(Table table)
        {
            var perfect = new ExampleTableItem()
            {
                First = "First perfect",
                Second = "Second perfect"
            };

            table.CompareToInstance<ExampleTableItem>(perfect);
        }

        private async Task GetTask()
        {
        }
    }
}
