﻿using TechTalk.SpecFlow;

namespace Automated.API.Tests.Hooks
{
    [Binding]
    public class StepHooks
    {
        [BeforeStep(Order = 0)]
        public void BeforeStep()
        {
            //Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        [AfterStep(Order = 0)]
        public void AfterStep()
        {
            //Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }
    }
}
