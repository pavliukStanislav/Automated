using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Automated.UI.Tests.Steps.Examples.Selenium
{
    [Binding]
    public class ExampleBrowserSteps : ExampleBaseUiStep
    {
        public ExampleBrowserSteps(ScenarioContext context) : base(context)
        {
        }

        [When(@"User opens new browser with name '(.*)'")]
        public void WhenUserOpensNewBrowserWithName(string browserName)
        {
            var browser = GetFromContainer<List<Browser>>()[0].Clone(browserName);

            GetFromContainer<List<Browser>>().Add(browser);
        }

        [When(@"User makes '(.*)' browser main one")]
        public void WhenUserMakesBrowserMainOne(string browserName)
        {
            var browsers = GetFromContainer<List<Browser>>();

            if (browsers.Any(x => x.BrowserName == browserName))
            {
                var newMainBrowserIndex = browsers.FindIndex(x => x.BrowserName == browserName);

                //swap
                var tmp = browsers[0];
                browsers[0] = browsers[newMainBrowserIndex];
                browsers[newMainBrowserIndex] = tmp;
            }
            else
            {
                throw new KeyNotFoundException($"{browserName} browser is not created");
            }
        }
    }
}
