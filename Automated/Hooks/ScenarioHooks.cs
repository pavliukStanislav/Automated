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
        private readonly IObjectContainer objectContainer;
        private ScenarioContext scenarioContext;

        public ScenarioHooks(IObjectContainer oc, ScenarioContext sc)
        {
            objectContainer = oc;
            scenarioContext = sc;
        }

        //todo use DI in elements and framework
        [BeforeScenario(Order = 0)]
        public void BeforeScenario()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
            
            var webDriver = new ChromeDriver();
            objectContainer.RegisterInstanceAs<IWebDriver>(webDriver);

            //example of getting scenario data
            Console.WriteLine("Scenario title: " + scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario(Order = 0)]
        public void AfterScenario()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);

            //example error handling
            if (scenarioContext.TestError != null)
            {
                var error = scenarioContext.TestError;

                Console.WriteLine("An error acured: " + error.Message);
            }

            var driver = objectContainer.Resolve<IWebDriver>();
            driver.Quit();
            driver.Dispose();
        }
    }
}
