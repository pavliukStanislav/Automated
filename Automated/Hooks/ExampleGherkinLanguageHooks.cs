using System;
using TechTalk.SpecFlow;

namespace Automated.Hooks
{
    [Binding]
    public class ExampleGherkinLanguageHooks
    {
        [BeforeScenario("someTag")]
        public void SomeTag()
        {
            Console.WriteLine("someTag action");
        }
    }
}
