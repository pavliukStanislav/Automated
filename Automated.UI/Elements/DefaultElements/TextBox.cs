using System;

namespace Automated.UI.Elements.DefaultElements
{
    public class TextBox : BaseElement
    {
        public string Text
        {
            get
            {
                return wait.ForElementVisible(xpath).Text;
            }
            set
            {
                wait.ForElementVisible(xpath).SendKeys(value);
            }
        }

        public string Value
        {
            get
            {
                return wait.ForElementVisible(xpath).GetAttribute("value");
            }
            set
            {
                SetElementValue(value);
            }
        }

        public TextBox(string xpath, Browser browser) : base(xpath, browser)
        {
        }

        public bool IsTextEqualTo(string expectedText, TimeSpan timeToWait = default)
        {
            return wait.ForElementHasText(xpath, expectedText, timeToWait);
        }
    }
}
