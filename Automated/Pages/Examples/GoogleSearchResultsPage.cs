using Automated.CustomElements.Examples;
using Automation.Selenium;
using Automation.Selenium.Elements.DefaultElements;

namespace Automated.Pages.Examples
{
    public class GoogleSearchResultsPage : BasePage
    {
        public TextBox TextBoxSearch => new TextBox("//input[@title='Search']");
        public Button ButtonSearch => new Button("//button[@type='submit']");

        public GoogleSearchResult GoogleSearchResult(int index) => new GoogleSearchResult("//div[@class='g']", index);
    }
}
