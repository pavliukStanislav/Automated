using Automated.UI.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Serilog;
using System;
using System.Reflection;

namespace Automated.UI
{
    public class Wait
    {
        private readonly TimeSpan DefaultTimeToWait = new TimeSpan(0, 0, 10);

        private readonly IWebDriver driver;
        private readonly Browser browser;

        private readonly ILogger logger;

        public Wait(Browser browser)
        {
            this.browser = browser;
            this.driver = browser.Driver;
            this.logger = browser.logger;
        }

        internal IWebElement ForElementClickable(string xpath, TimeSpan timeToWait = default)
        {
            logger.Information(LogMessageMasks.Operation, browser.BrowserName, $"WAIT {MethodBase.GetCurrentMethod().Name}", xpath);

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

            var wait = new WebDriverWait(driver, timeToWait == default ? DefaultTimeToWait : timeToWait);
            return wait.Until(condition(By.XPath(xpath)));
        }

        internal IWebElement ForElementVisible(string xpath, TimeSpan timeToWait = default)
        {
            logger.Information(LogMessageMasks.Operation, browser.BrowserName, $"WAIT {MethodBase.GetCurrentMethod().Name}", xpath);
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

            var wait = new WebDriverWait(driver, timeToWait == default ? DefaultTimeToWait : timeToWait);
            return wait.Until(condition(By.XPath(xpath)));
        }

        internal bool ForElementNotVisible(string xpath, TimeSpan timeToWait = default)
        {
            logger.Information(LogMessageMasks.Operation, browser.BrowserName, $"WAIT {MethodBase.GetCurrentMethod().Name}", xpath);
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

            var wait = new WebDriverWait(driver, timeToWait == default ? DefaultTimeToWait : timeToWait);
            return wait.Until(condition(By.XPath(xpath)));
        }

        internal bool ForElementHasText(string xpath, string text, TimeSpan timeToWait = default)
        {
            logger.Information(LogMessageMasks.Operation, browser.BrowserName, $"WAIT {MethodBase.GetCurrentMethod().Name}", xpath);

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

            var wait = new WebDriverWait(driver, timeToWait == default ? DefaultTimeToWait : timeToWait);
            return wait.Until(condition(By.XPath(xpath)));
        }

        private IWebElement ElementIfVisible(IWebElement element)
        {
            return element.Displayed ? element : null;
        }
    }
}
