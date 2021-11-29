using Automated.Configurations.Entities;

namespace Automated.Configurations
{
    public static class Urls
    {
        private const string BaseUrl = "https://asd.com";

        private const string TestEnv = "/test";

        private const string StagingEnv = "/staging";

        private const string ProdEnd = "";

        private const string LoginPage = "/login";

        private const string HomePage = "";

        private const string SomePage = "/somePage";

        public static readonly EnvironmentUrls Test = new EnvironmentUrls(BaseUrl + TestEnv, LoginPage, HomePage, SomePage);

        public static readonly EnvironmentUrls Staging = new EnvironmentUrls(BaseUrl + StagingEnv, LoginPage, HomePage, SomePage);

        public static readonly EnvironmentUrls Prod = new EnvironmentUrls(BaseUrl + ProdEnd, LoginPage, HomePage, SomePage);
    }
}
