using Automated.PagesImplementation.Pages.Examples;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Automated.UI.Tests.Steps.Examples.Selenium
{
    [Binding]
    public class ExampleGoogleMainPageSteps : ExampleBaseUiStep
    {
        private GoogleSearchMainPage GoogleSearchMainPage => new GoogleSearchMainPage(GetFromContainer<List<Browser>>().First());

        public ExampleGoogleMainPageSteps(ScenarioContext context) : base(context)
        {
        }

        [When(@"User searchs '(.*)' on the Google Search Main page")]
        public void WhenUserSearchsOnTheGoogleSearchMainPage(string searchData)
        {
            GoogleSearchMainPage.TextBoxSearch.Text = searchData;
            GoogleSearchMainPage.ButtonSearch.Click();
        }
    }
}
