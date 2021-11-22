using Automated.Configurations.DTOs;
using Microsoft.Extensions.Configuration;

namespace Automated.Configurations.Binders
{
    internal static class CredentialsConfiguration
    {
        public static UserData UserData { get; } = Configure();

        private static readonly IConfigurationRoot Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("credentials.json", true)
                .AddEnvironmentVariables()
                .Build();

        private static UserData Configure()
        {
            UserData data = new();

            Configuration.Bind("userdata", data);

            return data;
        }
    }
}