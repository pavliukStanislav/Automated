using Automated.Configurations.DTOs;
using Microsoft.Extensions.Configuration;

namespace Automated.Configurations.Binders
{
    /// <summary>
    /// Binding of credential JSON file configuration
    /// </summary>
    internal static class CredentialsConfiguration
    {
        public static UserData UserData { get; } = Configure();

        private static UserData Configure()
        {
            IConfigurationRoot Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("credentials.json", true)
                .AddEnvironmentVariables()
                .Build();

            UserData data = new();

            Configuration.Bind("userdata", data);

            return data;
        }
    }
}