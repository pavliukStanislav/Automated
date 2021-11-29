namespace Automated.Configurations.Entities
{
    public class EnvironmentUrls
    {
        public string LoginPage { get; }

        public string HomePage { get; } 

        public string SomePage { get; }

        public EnvironmentUrls(string baseUrl, string loginUrl, string homeUrl, string someUrl)
        {
            LoginPage = baseUrl + loginUrl;
            HomePage = baseUrl + homeUrl;
            SomePage = baseUrl + someUrl;
        }
    }
}
