using Automated.UI;
using Automated.UI.Elements;
using Automated.UI.Elements.DefaultElements;
using Automated.UI.Elements.Interfaces;

namespace Automated.UI.PagesImplementation.CustomElements.Examples
{
    public class GoogleSearchResult : BaseElement
    {
        private int Index { get; set; }
        public GoogleSearchResult(string xpath, int index, Browser browser) : base(xpath, browser)
        {
            Index = index;
        }

        //class can be changed by google
        public ILink LinkResult => new Link($"({xpath}//div[@class='yuRUbf']/a)[{Index}]", browser);
    }
}
