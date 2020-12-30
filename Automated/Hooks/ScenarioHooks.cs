using System;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Automated.Hooks
{
    [Binding]
    public class ScenarioHooks
    {
        [BeforeScenario(Order = 0)]
        public void BeforeScenario()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        [AfterScenario(Order = 0)]
        public void AfterScenario()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }
    }
}
