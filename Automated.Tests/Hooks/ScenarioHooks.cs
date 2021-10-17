using Automated.UI;
using TechTalk.SpecFlow;

namespace Automated.Tests.Hooks
{
    [Binding]
    public class ScenarioHooks
    {
        public ScenarioHooks()
        {
        }

        [BeforeScenario(Order = 0)]
        public void BeforeScenario()
        {
            
        }

        [Scope(Tag = "uiTest")]
        [AfterScenario(Order = int.MaxValue)]
        public void AfterScenario()
        {
            Browser.Quit();
        }
    }
}
