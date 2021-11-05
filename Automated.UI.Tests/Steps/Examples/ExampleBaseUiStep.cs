using TechTalk.SpecFlow;

namespace Automated.UI.Tests.Steps.Examples.Selenium
{
    [Binding]
    public class ExampleBaseUiStep
    {
        private readonly ScenarioContext ScenarioContext;

        public ExampleBaseUiStep(ScenarioContext context)
        {
            ScenarioContext = context;
        }

        public void PutToContainer<T>(T data) where T : class
        {
            ScenarioContext.ScenarioContainer.RegisterInstanceAs(data);
        }

        public bool IsInContainer<T>(T data) where T : class
        {
            return ScenarioContext.ScenarioContainer.IsRegistered<T>();
        }

        public T GetFromContainer<T>() where T : class
        {
            return ScenarioContext.ScenarioContainer.Resolve<T>();
        }
    }
}
