using Automated.PagesImplementation.Pages.Examples;
using Automated.UI;
using Automated.UI.Helpers.Enums;
using System.Collections.Generic;
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
            _scenarioContext.ScenarioContainer.RegisterInstanceAs(new List<Browser>() { new Browser(BrowserType.Chrome) });
        }

        [Scope(Tag = "uiTest")]
        [BeforeScenario(Order = 1)]
        public void AddPagesImplementation(List<Browser> browsers)
        {
            foreach (var browser in browsers)
            {
                _scenarioContext.ScenarioContainer.RegisterInstanceAs(new List<GoogleSearchMainPage>() { new GoogleSearchMainPage(browser) });
                _scenarioContext.ScenarioContainer.RegisterInstanceAs(new List<GoogleSearchResultsPage>() { new GoogleSearchResultsPage(browser) });
            }
        }

        [Scope(Tag = "uiTest")]
        [AfterScenario(Order = int.MaxValue)]
        public void QuitFromAllBrowsers()
        {
            _scenarioContext.ScenarioContainer.Resolve<List<Browser>>().ForEach(x => x.Quit());
        }
    }
}
