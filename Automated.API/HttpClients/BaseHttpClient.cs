using Automated.API.DTOs.Responses;
using Automated.API.Services;
using Automated.Configurations.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using Serilog;

namespace Automated.API.HttpClients
{
    public class BaseHttpClient
    {
        private HttpClient _authorizationHttpClient { get; }

        protected EnvironmentUrls EnvironmentUrls { get; }

        protected ILogger Logger { get; }        

        protected AuthorizationService AuthorizationService { get; }

        protected TokenResponseDto? Token { get; init; }

        protected RefitSettings Settings { get; }

        public BaseHttpClient(EnvironmentUrls environmentUrls, ILogger logger)
        {
            EnvironmentUrls = environmentUrls;
            Logger = logger;

            Settings = new RefitSettings
            {
                CollectionFormat = CollectionFormat.Multi,
                ContentSerializer = new NewtonsoftJsonContentSerializer(
                    new JsonSerializerSettings
                    {
                        ContractResolver = new DefaultContractResolver
                        {
                            NamingStrategy = new SnakeCaseNamingStrategy()
                        }
                    })
            };

            _authorizationHttpClient = RestService.CreateHttpClient(environmentUrls.LoginPage, Settings);
            AuthorizationService = new AuthorizationService(_authorizationHttpClient, Logger);
        }

        public string? Email { get; protected init; }

        public string? Password { get; protected init; }
    }
}
