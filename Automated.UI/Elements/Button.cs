using Automated.UI.Elements.Interfaces;

namespace Automated.UI.Elements
{
    public class Button : BaseElement, IButton
    {
        public Button(string xpath, Browser browser) : base(xpath, browser)
        {
        }
    }
}
