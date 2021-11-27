using Automated.UI.Elements.Interfaces;

namespace Automated.UI.Elements.DefaultElements
{
    public class Link : BaseElement, ILink
    {
        public Link(string xpath, Browser browser) : base(xpath, browser)
        {
        }
    }
}
