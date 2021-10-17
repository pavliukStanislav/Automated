using Automated.PagesImplementation.Pages.Examples;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Automated.Tests.Steps.Examples.Selenium
{
    [Binding]
    public class ExampleGoogleSearchResultsPageSteps : ExampleBaseUiStepSteps
    {
        private GoogleSearchResultsPage GoogleSearchResultsPage => new GoogleSearchResultsPage();

        public ExampleGoogleSearchResultsPageSteps(ScenarioContext context) : base(context)
        {
        }

        [Then(@"User checks '(.*)' presents on the Google Search Results page")]
        public void ThenUserChecksPresentsOnTheGoogleSearchResultsPage(string hrefResult)
        {
            GoogleSearchResultsPage.GoogleSearchResult(1).LinkResult.GetAttribute("href").Should().Contain(hrefResult);
        }
    }
}
