using Automated.UI.Helpers.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Automated.UI
{
    public class Browser
    {
        public IWebDriver Driver { get; set; }

        public Js Js { get; set; }

        public Browser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    var options = new ChromeOptions();
                    Driver = new ChromeDriver(options);
                    break;

                default:
                    throw new NotImplementedException();
            }

            Js = new Js(Driver);
        }

        public void GoToUrl(string url) 
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void Quit()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
