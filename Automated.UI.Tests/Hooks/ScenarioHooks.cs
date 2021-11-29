using Allure.Commons;
using Automated.Configurations;
using Automated.Configurations.Entities;
using Automated.UI.Helpers.Enums;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.IO;
using TechTalk.SpecFlow;

namespace Automated.UI.Tests.Hooks
{
    [Binding]
    public class ScenarioHooks
    {
        private readonly ScenarioContext _scenarioContext;
        private static readonly AllureLifecycle Allure = AllureLifecycle.Instance;

        private string LogsFolder => Path.Combine("logs", _scenarioContext.ScenarioInfo.Title);
        private string LogsFileName;

        public ScenarioHooks(ScenarioContext sContext)
        {
            _scenarioContext = sContext;
            LogsFileName = $"{_scenarioContext.ScenarioInfo.Title}_{Guid.NewGuid()}.log";
        }

        [BeforeScenario(Order = 0)]
        public void CreateLoggerInstance()
        {
            ILogger logger = new LoggerConfiguration().Enrich.WithProperty("Scenario", _scenarioContext.ScenarioInfo.Title)
                .WriteTo.Console(LogEventLevel.Error)
                .WriteTo.File(
                    Path.Combine(LogsFolder, LogsFileName),
                    LogEventLevel.Information, shared: true)
                .CreateLogger();

            logger.Information("===========================LOG STARTED===========================");

            PutToContainer(logger);
        }

        [BeforeScenario(Order = int.MaxValue)]
        public void CreateBrowserInstrance()
        {
            var browser = new Browser(BrowserType.Chrome, "main browser", GetFromContainer<ILogger>());

            PutToContainer(new List<Browser>() { browser });
        }


        [AfterScenario(Order = int.MinValue)]
        public void GetScreenShots()
        {
            if (_scenarioContext.TestError != null)
            {
                var browsers = GetFromContainer<List<Browser>>();

                foreach (var browser in browsers)
                {
                    var path = Path.Combine(LogsFolder, $"{browser.BrowserName} screenshot.png");
                    browser.SaveScreenShot(path);
                    Allure.AddAttachment(path);
                }
            }
        }

        [AfterScenario(Order = 0)]
        public void AddLogsToAllure()
        {
            var path = Path.Combine(LogsFolder, LogsFileName);

            GetFromContainer<ILogger>().Information("===========================LOG FINISHED===========================");

            //without copy, you will see file reading error
            File.Copy(path, Path.Combine(LogsFolder, $"Copy {LogsFileName}"));
            Allure.AddAttachment(Path.Combine(LogsFolder, $"Copy {LogsFileName}"));
        }

        [AfterScenario(Order = int.MaxValue)]
        public void QuitFromAllBrowsers()
        {
            GetFromContainer<List<Browser>>().ForEach(x => x.Quit());
        }

        private T GetFromContainer<T>() => _scenarioContext.ScenarioContainer.Resolve<T>();

        private void PutToContainer<T>(T obj) where T : class => _scenarioContext.ScenarioContainer.RegisterInstanceAs<T>(obj);
    }
}
