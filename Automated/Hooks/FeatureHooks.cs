using System;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Automated.Hooks
{
    [Binding]
    public class FeatureHooks
    {
        [BeforeFeature(Order = 0)]
        public static void BeforeFeature()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        [AfterFeature(Order = 0)]
        public static void AfterFeature()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }
    }
}
