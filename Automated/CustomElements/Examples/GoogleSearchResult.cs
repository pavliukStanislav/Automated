using Automation.Selenium.Elements;
using Automation.Selenium.Elements.DefaultElements;

namespace Automated.CustomElements.Examples
{
    public class GoogleSearchResult : BaseElement
    {
        private int Index { get; set; }
        public GoogleSearchResult(string xpath, int index) : base(xpath)
        {
            Index = index;
        }

        //class can be changed by google
        public Link LinkResult => new Link($"({xpath}//div[@class='yuRUbf']/a)[{Index}]");
    }
}
