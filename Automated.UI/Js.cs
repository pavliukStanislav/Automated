using Automated.UI.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace Automated.UI
{
    public class Js
    {
        private IWebDriver Driver;

        public Js(IWebDriver driver)
        {
            Driver = driver;
        }

        internal string Execute(string command)
        {
            return Driver.ExecuteJavaScript<string>(command);
        }

        internal string SetElementValue(IWebElement element, string value)
        {
            return SetAttribute(element, "value", value);
        }

        internal string SetAttribute(IWebElement element, string attribute, string value)
        {
            return Driver.ExecuteJavaScript<string>(JsExecutionsParts.SetAttribute, element, attribute, value);
        }
    }
}
