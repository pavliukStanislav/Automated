using System;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Automated.Tests.Hooks
{
    [Binding]
    public class FeatureHooks
    {
        private readonly FeatureContext _feaureContext;

        public FeatureHooks(FeatureContext featureContext)
        {
            _feaureContext = featureContext;
        }

        [BeforeFeature(Order = 0)]
        public static void BeforeFeature()
        {
            //Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        [AfterFeature(Order = 0)]
        public static void AfterFeature()
        {
            //Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }
    }
}
