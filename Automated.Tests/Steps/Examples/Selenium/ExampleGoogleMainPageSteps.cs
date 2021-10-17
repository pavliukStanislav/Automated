using Automated.PagesImplementation.Pages.Examples;
using TechTalk.SpecFlow;

namespace Automated.Tests.Steps.Examples.Selenium
{
    [Binding]
    public class ExampleGoogleMainPageSteps : ExampleBaseUiStepSteps
    {
        private GoogleSearchMainPage GoogleSearchMainPage => new GoogleSearchMainPage();

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
