using Automated.PagesImplementation.CustomElements.Examples;
using Automated.UI;
using Automated.UI.Elements;
using Automated.UI.Elements.DefaultElements;
using Automated.UI.Elements.Interfaces;

namespace Automated.PagesImplementation.Pages.Examples
{
    public class GoogleSearchResultsPage : BasePage
    {
        public GoogleSearchResultsPage(Browser browser) : base(browser)
        {
        }

        public ITextBox TextBoxSearch => new TextBox("//input[@title='Search']", Browser);
        public IButton ButtonSearch => new Button("//button[@type='submit']", Browser);

        public GoogleSearchResult GoogleSearchResult(int index) => new GoogleSearchResult("//div[@class='g']", index, Browser);
    }
}
