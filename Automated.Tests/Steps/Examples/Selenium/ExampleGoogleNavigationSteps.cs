using Automated.UI;
using TechTalk.SpecFlow;

namespace Automated.Tests.Steps.Examples.Selenium
{
    [Binding]
    public class ExampleGoogleNavigationSteps : ExampleBaseUiStepSteps
    {
        public ExampleGoogleNavigationSteps(ScenarioContext context) : base(context)
        {
        }

        [Given(@"User open browser and navigate to Google Search Main page")]
        public void GivenUserOpenBrowserAndNavigateToGoogleSearchMainPage()
        {
            Browser.GoToUrl("https://www.google.com.ua/");
        }
    }
}
