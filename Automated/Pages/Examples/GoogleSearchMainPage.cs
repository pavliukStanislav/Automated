using Automation.Selenium;
using Automation.Selenium.Elements.DefaultElements;

namespace Automated.Pages.Examples
{
    public class GoogleSearchMainPage : BasePage
    {
        public TextBox TextBoxSearch => new TextBox("//input[@type='text']");
        public Button ButtonSearch => new Button("//div[@jsname]//input[@name='btnK']");
    }
}
