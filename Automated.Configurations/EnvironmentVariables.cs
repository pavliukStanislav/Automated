using Automated.Configurations.Entities;
using System.Reflection;

namespace Automated.Configurations
{
    /// <summary>
    /// Information about environment
    /// </summary>
    public static class EnvironmentVariables
    {
        public static readonly string? BrowserDriver = Environment.GetEnvironmentVariable("BrowserDriver");

        public static readonly string? ApplicationEnvironment = Environment.GetEnvironmentVariable("TestApp");

        public static readonly string? WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        private static Dictionary<string, EnvironmentUrls> UrlsByName { get; } =
          new Dictionary<string, EnvironmentUrls>
          {
            { "test", Urls.Test },
            { "staging", Urls.Staging },
            { "prod", Urls.Prod }
          };

        /// <summary>
        /// If you need urls from any plase in the app
        /// </summary>
        /// <param name="environmentName"></param>
        /// <returns></returns>
        public static EnvironmentUrls GetUrls(string environmentName = "test") =>
          string.IsNullOrEmpty(ApplicationEnvironment)
            ? UrlsByName[environmentName]
            : UrlsByName[ApplicationEnvironment.ToLowerInvariant()];
    }
}