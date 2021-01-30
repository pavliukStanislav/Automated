using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Automated.Hooks
{
    [Binding]
    public class ScenarioHooks
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public ScenarioHooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
        }

        //todo use DI in elements and framework
        [BeforeScenario(Order = 0)]
        public void BeforeScenario()
        {
            //Console.WriteLine(MethodBase.GetCurrentMethod().Name);

            //todo rework it
            //var options = new ChromeOptions();
            //options.AddArgument("headless");

            //var webDriver = new ChromeDriver(options);
            //_objectContainer.RegisterInstanceAs<IWebDriver>(webDriver);

            ////example of getting scenario data
            //Console.WriteLine("Scenario title: " + _scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario(Order = 0)]
        public void AfterScenario()
        {
            //Console.WriteLine(MethodBase.GetCurrentMethod().Name);

            //todo need to be reworked
            ////example error handling
            //if (_scenarioContext.TestError != null)
            //{
            //    var error = _scenarioContext.TestError;

            //    Console.WriteLine("An error acured: " + error.Message);
            //}

            //var driver = _objectContainer.Resolve<IWebDriver>();
            //driver.Quit();
            //driver.Dispose();
        }
    }
}
