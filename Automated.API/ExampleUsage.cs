using Automated.API.HttpClients;
using Automated.Configurations;
using Serilog;

namespace Automated.API
{
    internal class ExampleUsage
    {
        internal void ApiExample()
        {
            var logger = new LoggerConfiguration()
               .CreateLogger();

            var admin = new AdminHttpClient(EnvironmentVariables.GetUrls(), logger, Credentials.Data.Admin?.Email, Credentials.Data.Admin?.Password);

            var result = admin.AdminMainService.CreateNewUser("someProject", "userName", "password", "address");
        }
    }
}
