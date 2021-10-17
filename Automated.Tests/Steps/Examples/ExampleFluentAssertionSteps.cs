using FluentAssertions;
using FluentAssertions.Execution;
using TechTalk.SpecFlow;

namespace Automated.Tests.Steps.Examples
{
    [Binding]
    public class ExampleFluentAssertionSteps
    {
        [Given(@"Step with and in assertion")]
        public void GivenStepWithInAssertion()
        {
            "somestring".Should().Contain("string").And.Contain("some");
        }

        [Given(@"Assertion scope step")]
        public void WhenCustomAssertionStep()
        {
            using (new AssertionScope())
            {
                5.Should().Be(10, "5 should not be 10");
                "Actual".Should().Be("Expected");
            }
        }

        [Given(@"Occurrense contraint step")]
        public void ThenOccurrenseContraintStep()
        {
            "is a is a".Should().Contain("is a", MoreThan.Once());
        }
    }
}
