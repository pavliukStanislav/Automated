using Automated.PagesImplementation.Pages.Examples;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Automated.Tests.Steps.Examples.Selenium
{
    [Binding]
    public class ExampleGoogleSearchResultsPageSteps : ExampleBaseUiStep
    {
        private GoogleSearchResultsPage GoogleSearchResultsPage => GetFromContainer<List<GoogleSearchResultsPage>>().Last();

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
