using TechTalk.SpecFlow;

namespace Automated.UI.Tests.Hooks
{
    [Binding]
    public class TestRunHooks
    {
        //todo load configuration here
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            //Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }
    }
}
