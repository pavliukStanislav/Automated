using Automated.Configurations;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Automated.API.Tests.Steps.Examples
{
    [Binding]
    public class WorkWithConfigurationSteps
    {
        [Given(@"Assert user email from json is equal to '([^']*)'")]
        public void GivenAssertUserEmailFromJsonIsEqualTo(string expectedEmail)
        {
            Credentials.Data.User.Email.Should().BeEquivalentTo(expectedEmail);
        }

        [When(@"Assert user email from command line is equal to '([^']*)'")]
        public void WhenAssertUserEmailFromCommandLineIsEqualTo(string expectedEmail)
        {
            Credentials.Data.User.Email.Should().BeEquivalentTo(expectedEmail);
        }
    }
}
