using System;

namespace Automated.UI.Elements
{
    public class BaseElement
    {
        protected string xpath;
        protected Wait wait;
        protected Browser browser;

        public BaseElement(string xpath, Browser browser)
        {
            this.xpath = xpath;
            this.browser = browser;
            this.wait = new Wait(browser.Driver);
        }

        public void Click(TimeSpan timeToWait = default)
        {
            wait.ForElementClickable(xpath, timeToWait).Click();            
        }

        public bool IsDisplayed(TimeSpan timeToWait = default) 
        {
            return wait.ForElementVisible(xpath, timeToWait).Displayed;
        }

        public bool IsNotDisplayed(TimeSpan timeToWait = default)
        {
            return wait.ForElementNotVisible(xpath, timeToWait);
        }

        public string GetAttribute(string attributeName, TimeSpan timeToWait = default)
        {
            return wait.ForElementVisible(xpath, timeToWait).GetAttribute(attributeName);
        }

        public void SetElementValue(string value, TimeSpan timeToWait = default)
        {
            browser.Js.SetElementValue(wait.ForElementVisible(xpath, timeToWait), value);
        }
    }
}
