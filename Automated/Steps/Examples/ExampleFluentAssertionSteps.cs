using Automated.Data.Examples;
using FluentAssertions;
using FluentAssertions.Execution;
using TechTalk.SpecFlow;

namespace Automated.Steps.Examples
{
    [Binding]
    public class ExampleFluentAssertionSteps
    {
        [Given(@"step with and in assertion")]
        public void GivenStepWithInAssertion()
        {
            "somestring".Should().Contain("string").And.Contain("some");
        }

        [Given(@"assertion scope")]
        public void WhenCustomAssertion()
        {
            using (new AssertionScope())
            {
                5.Should().Be(10, "5 should not be 10");
                "Actual".Should().Be("Expected");
            }
        }

        [Given(@"Occurrense contraint")]
        public void ThenOccurrenseContraint()
        {
            "is a is a".Should().Contain("is a", MoreThan.Once());
        }

    }
}
