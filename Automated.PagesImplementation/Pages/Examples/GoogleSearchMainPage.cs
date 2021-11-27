using Automated.UI;
using Automated.UI.Elements;
using Automated.UI.Elements.DefaultElements;
using Automated.UI.Elements.Interfaces;

namespace Automated.PagesImplementation.Pages.Examples
{
    public class GoogleSearchMainPage : BasePage
    {
        public GoogleSearchMainPage(Browser browser) : base(browser) { }

        public ITextBox TextBoxSearch => new TextBox("//input[@type='text']", Browser);
        public IButton ButtonSearch => new Button("//div[@jsname]//input[@name='btnK']", Browser);
    }
}