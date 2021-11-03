using Automated.UI.Helpers;
using System;
using System.Reflection;

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
            this.wait = new Wait(browser, browser.logger);
        }

        public void Click(TimeSpan timeToWait = default)
        {
            var element = wait.ForElementClickable(xpath, timeToWait);

            browser.logger.Information(LogMessageMasks.Operation, browser.BrowserName, MethodBase.GetCurrentMethod().Name, xpath);
            element.Click();            
        }

        public bool IsDisplayed(TimeSpan timeToWait = default) 
        {
            var element = wait.ForElementVisible(xpath, timeToWait);

            browser.logger.Information(LogMessageMasks.Operation, browser.BrowserName, MethodBase.GetCurrentMethod().Name, xpath);
            return element.Displayed;
        }

        public bool IsNotDisplayed(TimeSpan timeToWait = default)
        {
            return wait.ForElementNotVisible(xpath, timeToWait);
        }

        public string GetAttribute(string attributeName, TimeSpan timeToWait = default)
        {
            var element = wait.ForElementVisible(xpath, timeToWait);

            browser.logger.Information(LogMessageMasks.Operation, browser.BrowserName, $"{MethodBase.GetCurrentMethod().Name} '{attributeName}'", xpath);
            return element.GetAttribute(attributeName);
        }

        public void SetElementValue(string value, TimeSpan timeToWait = default)
        {
            browser.Js.SetElementValue(wait.ForElementVisible(xpath, timeToWait), value);
        }
    }
}
