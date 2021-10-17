using System;

namespace Automated.UI.Elements.DefaultElements
{
    public class TextBox : BaseElement
    {
        public string Text 
        {
            get {
                return Wait.ForElementVisible(xpath).Text;
            }
            set {
                Wait.ForElementVisible(xpath).SendKeys(value);
            }
        }

        public string Value 
        {
            get
            {
                return Wait.ForElementVisible(xpath).GetAttribute("value");
            }
            set
            {
                Wait.ForElementVisible(xpath).SetElementValue(value);
            }
        }

        public TextBox(string xpath) : base(xpath)
        {
        }

        public bool IsTextEqualTo(string expectedText, TimeSpan timeToWait = default)
        {
            return Wait.ForElementHaveText(xpath, expectedText, timeToWait);
        }
    }
}
