using System;

namespace Automated.UI.Elements.DefaultElements
{
    public class Label : BaseElement
    {
        public string Text 
        {
            get {
                return wait.ForElementVisible(xpath).Text;
            }            
        }

        public Label(string xpath, Browser browser) : base(xpath, browser)
        {
        }

        public bool IsTextEqualTo(string expectedText, TimeSpan timeToWait = default)
        {
            return wait.ForElementHaveText(xpath, expectedText, timeToWait);
        }
    }
}
