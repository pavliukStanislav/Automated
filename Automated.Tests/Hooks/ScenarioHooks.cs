using Automated.PagesImplementation.Pages.Examples;
using Automated.UI;
using Automated.UI.Helpers.Enums;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Automated.Tests.Hooks
{
    [Binding]
    public class ScenarioHooks
    {
        private readonly ScenarioContext _scenarioContext;

        public ScenarioHooks(ScenarioContext sContext)
        {
            _scenarioContext = sContext;
        }

        [Scope(Tag = "uiTest")]
        [BeforeScenario(Order = 0)]
        public void CreateBrowserInstrance()
        {
            var browser = new Browser(BrowserType.Chrome, "main");

            _scenarioContext.ScenarioContainer.RegisterInstanceAs(new List<Browser>() { browser });
        }

        [Scope(Tag = "uiTest")]
        [AfterScenario(Order = int.MaxValue)]
        public void QuitFromAllBrowsers()
        {
            _scenarioContext.ScenarioContainer.Resolve<List<Browser>>().ForEach(x => x.Quit());
        }
    }
}
