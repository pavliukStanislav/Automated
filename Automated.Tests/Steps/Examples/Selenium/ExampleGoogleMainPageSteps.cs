﻿using Automated.PagesImplementation.Pages.Examples;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Automated.Tests.Steps.Examples.Selenium
{
    [Binding]
    public class ExampleGoogleMainPageSteps : ExampleBaseUiStep
    {
        private GoogleSearchMainPage GoogleSearchMainPage => GetFromContainer<List<GoogleSearchMainPage>>().Last();

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
