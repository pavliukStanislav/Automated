using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace Automated.UI
{
    internal static class Js
    {
        internal static string Execute(string command)
        {
            return Browser.Driver.ExecuteJavaScript<string>(command);
        }

        internal static string SetElementValue(this IWebElement element, string value)
        {
            return SetAttribute(element, "value", value);
        }

        internal static string SetAttribute(IWebElement element, string attribute, string value)
        {
            return Browser.Driver.ExecuteJavaScript<string>("arguments[0].setAttribute(arguments[1], arguments[2])", element, attribute, value);
        }
    }
}
