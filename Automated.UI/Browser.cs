using Automated.UI.Helpers;
using Automated.UI.Helpers.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog;
using System;
using System.Reflection;

namespace Automated.UI
{
    public class Browser
    {
        public IWebDriver Driver { get; set; }

        public Js Js { get; set; }

        public string BrowserName { get; private set; }

        private BrowserType browserType;

        internal ILogger logger;

        public Browser(BrowserType browserType, string browserName, ILogger logger)
        {
            this.browserType = browserType;
            this.BrowserName = browserName;
            this.logger = logger;

            switch (browserType)
            {
                case BrowserType.Chrome:
                    var options = new ChromeOptions();
                    options.AddArgument("headless");

                    logger.Information(LogMessageMasks.Operation, browserName, "CREATING BROWSER INSCANCE", nameof(BrowserType.Chrome));

                    Driver = new ChromeDriver(options);
                    break;

                default:
                    throw new NotImplementedException();
            }

            Js = new Js(Driver);
        }

        public void GoToUrl(string url) 
        {
            logger.Information(LogMessageMasks.Operation, BrowserName, MethodBase.GetCurrentMethod().Name, url);
            Driver.Navigate().GoToUrl(url);
        }

        public void Quit()
        {
            logger.Information(LogMessageMasks.Operation, BrowserName, "CLOSING BROWSER INSCANCE", nameof(BrowserType.Chrome));
            logger.Information("=======================================");

            Driver.Quit();
            Driver.Dispose();
        }

        public void SaveScreenShot(string filePath)
        {
            logger.Information(LogMessageMasks.Operation, BrowserName, "CREATING SCREENSHOT", filePath);

            ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile(filePath);
        }

        public Browser Clone(string browserName)
        {
            return new Browser(browserType, browserName, logger);
        }
    }
}
