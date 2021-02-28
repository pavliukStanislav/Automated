using Automation.Selenium.Helpers.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Automation.Selenium
{
    public class Browser
    {
        private static BrowserType BrowserType = BrowserType.Chrome;

        internal static IWebDriver Driver;


        static Browser()
        {
            switch (BrowserType)
            {
                case BrowserType.Chrome:
                    var options = new ChromeOptions();
                    Driver = new ChromeDriver(options);
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        public static void GoToUrl(string url) 
        {
            Driver.Navigate().GoToUrl(url);
        }

        public static void Quit()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
