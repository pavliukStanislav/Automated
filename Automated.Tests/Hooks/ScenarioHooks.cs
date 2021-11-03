using Automated.UI;
using Automated.UI.Helpers.Enums;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.IO;
using TechTalk.SpecFlow;

namespace Automated.Tests.Hooks
{
    [Binding]
    public class ScenarioHooks
    {
        private readonly ScenarioContext _scenarioContext;

        public ScenarioHooks(ScenarioContext sContext)
        {
            _scenarioContext = sContext;
        }

        [BeforeScenario(Order = 0)]
        public void CreateLoggerInstance()
        {
            ILogger logger = new LoggerConfiguration().Enrich.WithProperty("Scenario", _scenarioContext.ScenarioInfo.Title)
                .WriteTo.Console(LogEventLevel.Error)
                .WriteTo.File(GetScenarioLogFilePath(), LogEventLevel.Information)
                .CreateLogger();

            PutToContainer(logger);
        }

        [Scope(Tag = "uiTest")]
        [BeforeScenario(Order = int.MaxValue)]
        public void CreateBrowserInstrance()
        {
            var browser = new Browser(BrowserType.Chrome, "main", GetFromContainer<ILogger>());

            PutToContainer(new List<Browser>() { browser });
        }        

        [Scope(Tag = "uiTest")]
        [AfterScenario(Order = int.MaxValue)]
        public void QuitFromAllBrowsers()
        {
            GetFromContainer<List<Browser>>().ForEach(x => x.Quit());
        }

        private string GetScenarioLogFilePath()
        {
            string fileName = $"{_scenarioContext.ScenarioInfo.Title}_{DateTime.Now.ToString("yyyyMMddhhmmss")}.log";

            return Path.Combine("logs", _scenarioContext.ScenarioInfo.Title, fileName);
        }

        private T GetFromContainer<T>() => _scenarioContext.ScenarioContainer.Resolve<T>();

        private void PutToContainer<T>(T obj) where T : class => _scenarioContext.ScenarioContainer.RegisterInstanceAs<T>(obj);
    }
}
