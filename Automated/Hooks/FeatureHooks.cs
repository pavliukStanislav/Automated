using System;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Automated.Hooks
{
    [Binding]
    public class FeatureHooks
    {
        private readonly FeatureContext _feaureContext;

        public FeatureHooks(FeatureContext fc)
        {
            _feaureContext = fc;
        }

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
