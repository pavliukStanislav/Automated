using Automated.UI;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Automated.Tests.Steps.Examples.Selenium
{
    [Binding]
    public class ExampleGoogleNavigationSteps : ExampleBaseUiStep
    {
        public ExampleGoogleNavigationSteps(ScenarioContext context) : base(context)
        {
        }

        [Given(@"User open browser and navigate to Google Search Main page")]
        public void GivenUserOpenBrowserAndNavigateToGoogleSearchMainPage()
        {
            GetFromContainer<List<Browser>>().Last().GoToUrl("https://www.google.com.ua/");
        }
    }
}
