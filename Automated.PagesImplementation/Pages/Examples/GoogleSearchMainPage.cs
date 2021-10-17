using Automated.UI;
using Automated.UI.Elements.DefaultElements;

namespace Automated.PagesImplementation.Pages.Examples
{
    public class GoogleSearchMainPage : BasePage
    {
        public GoogleSearchMainPage(Browser browser) : base(browser) { }

        public TextBox TextBoxSearch => new TextBox("//input[@type='text']", Browser);
        public Button ButtonSearch => new Button("//div[@jsname]//input[@name='btnK']", Browser);
    }
}