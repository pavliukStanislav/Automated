using Automated.UI;
using Automated.UI.Elements.DefaultElements;

namespace Automated.PagesImplementation.Pages.Examples
{
    public class GoogleSearchMainPage : BasePage
    {
        public TextBox TextBoxSearch => new TextBox("//input[@type='text']");
        public Button ButtonSearch => new Button("//div[@jsname]//input[@name='btnK']");
    }
}
