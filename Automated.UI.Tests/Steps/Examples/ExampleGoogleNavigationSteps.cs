using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Automated.UI.Tests.Steps.Examples.Selenium
{
    [Binding]
    public class ExampleGoogleNavigationSteps : ExampleBaseUiStep
    {
        private const string GoogleMainPageUrl = "https://www.google.com.ua/";

        public ExampleGoogleNavigationSteps(ScenarioContext context) : base(context)
        {
        }

        [Given(@"User navigates to Google Search Main page")]
        [When(@"User navigates to Google Search Main page")]
        public void GivenUserNavigatesToGoogleSearchMainPage()
        {
            GetFromContainer<List<Browser>>()[0].GoToUrl(GoogleMainPageUrl);
        }

    }
}
