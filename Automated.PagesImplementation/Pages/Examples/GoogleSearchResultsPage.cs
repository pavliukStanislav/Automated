using Automated.PagesImplementation.CustomElements.Examples;
using Automated.UI;
using Automated.UI.Elements.DefaultElements;

namespace Automated.PagesImplementation.Pages.Examples
{
    public class GoogleSearchResultsPage : BasePage
    {
        public TextBox TextBoxSearch => new TextBox("//input[@title='Search']");
        public Button ButtonSearch => new Button("//button[@type='submit']");

        public GoogleSearchResult GoogleSearchResult(int index) => new GoogleSearchResult("//div[@class='g']", index);
    }
}
