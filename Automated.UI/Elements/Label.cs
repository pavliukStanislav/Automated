using Automated.UI.Elements.Interfaces;
using System;

namespace Automated.UI.Elements.DefaultElements
{
    public class Label : BaseElement, ILabel
    {
        public string Text
        {
            get
            {
                return wait.ForElementVisible(xpath).Text;
            }
        }

        public Label(string xpath, Browser browser) : base(xpath, browser)
        {
        }

        public bool IsTextEqualTo(string expectedText, TimeSpan timeToWait = default)
        {
            return wait.ForElementHasText(xpath, expectedText, timeToWait);
        }
    }
}
