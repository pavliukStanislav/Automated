using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Automation.Selenium
{
    internal static class Wait
    {
        private static readonly TimeSpan DefaultTimeToWait = new TimeSpan(0, 0, 10);

        internal static IWebElement ForElementClickable(string xpath, TimeSpan timeToWait = default)
        {
            Func<IWebDriver, IWebElement> condition(By locator) 
            {
                return (driver) =>
                {
                    var element = ElementIfVisible(driver.FindElement(locator));
                    try
                    {
                        if (element != null && element.Enabled)
                        {
                            return element;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (StaleElementReferenceException)
                    {
                        return null;
                    }
                };
            }

            var wait = new WebDriverWait(Browser.Driver, timeToWait == default ? DefaultTimeToWait : timeToWait);
            return wait.Until(condition(By.XPath(xpath)));
        }

        internal static IWebElement ForElementVisible(string xpath, TimeSpan timeToWait = default)
        { 
            Func<IWebDriver, IWebElement> condition(By locator)
            {
                return (driver) =>
                {
                    try
                    {
                        return ElementIfVisible(driver.FindElement(locator));
                    }
                    catch (StaleElementReferenceException)
                    {
                        return null;
                    }
                };
            }

            var wait = new WebDriverWait(Browser.Driver, timeToWait == default ? DefaultTimeToWait : timeToWait);
            return wait.Until(condition(By.XPath(xpath)));
        }

        internal static bool ForElementNotVisible(string xpath, TimeSpan timeToWait = default)
        {
            Func<IWebDriver, bool> condition(By locator)
            {
                return (driver) =>
                {
                    try
                    {
                        return !driver.FindElement(locator).Displayed;
                    }
                    catch
                    {
                        return true;
                    }
                };
            }

            var wait = new WebDriverWait(Browser.Driver, timeToWait == default ? DefaultTimeToWait : timeToWait);
            return wait.Until(condition(By.XPath(xpath)));
        }

        internal static bool ForElementHaveText(string xpath, string text, TimeSpan timeToWait = default)
        {
            Func<IWebDriver, bool> condition(By locator)
            {
                return (driver) =>
                {
                    try
                    {
                        return ElementIfVisible(driver.FindElement(locator)).Text == text;
                    }
                    catch
                    {
                        return false;
                    }
                };
            }

            var wait = new WebDriverWait(Browser.Driver, timeToWait == default ? DefaultTimeToWait : timeToWait);
            return wait.Until(condition(By.XPath(xpath)));
        }

        private static IWebElement ElementIfVisible(IWebElement element)
        {
            return element.Displayed ? element : null;
        }
    }
}
