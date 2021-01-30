using System;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Automated.Hooks
{
    [Binding]
    public class ScenarioBlockHooks
    {
        [BeforeScenarioBlock(Order = 0)]
        public void BeforeScenarioBlock()
        {
            //Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        [AfterScenarioBlock(Order = 0)]
        public void AfterScenarioBlock()
        {
            //Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }
    }
}
