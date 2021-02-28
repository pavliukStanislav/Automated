using System;

namespace Automation.Selenium.Elements
{
    public class BaseElement
    {
        protected string xpath;

        public BaseElement(string xpath)
        {
            this.xpath = xpath;
        }

        public void Click(TimeSpan timeToWait = default)
        {
           Wait.ForElementClickable(xpath, timeToWait).Click();            
        }

        public bool IsDisplayed(TimeSpan timeToWait = default) 
        {
            return Wait.ForElementVisible(xpath, timeToWait).Displayed;
        }

        public bool IsNotDisplayed(TimeSpan timeToWait = default)
        {
            return Wait.ForElementNotVisible(xpath, timeToWait);
        }

        public string GetAttribute(string attributeName, TimeSpan timeToWait = default)
        {
            return Wait.ForElementVisible(xpath, timeToWait).GetAttribute(attributeName);
        }
    }
}
