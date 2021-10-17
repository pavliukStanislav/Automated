using System;

namespace Automated.UI.Elements.DefaultElements
{
    public class Label : BaseElement
    {
        public string Text 
        {
            get {
                return Wait.ForElementVisible(xpath).Text;
            }            
        }

        public Label(string xpath) : base(xpath)
        {
        }

        public bool IsTextEqualTo(string expectedText, TimeSpan timeToWait = default)
        {
            return Wait.ForElementHaveText(xpath, expectedText, timeToWait);
        }
    }
}
