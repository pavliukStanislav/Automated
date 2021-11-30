using Automated.API.Services;
using Automated.Configurations.Entities;
using Refit;
using Serilog;

namespace Automated.API.HttpClients
{
    public class AdminHttpClient : BaseHttpClient
    {
        public AdminMainService AdminMainService { get; init; }

        public AdminHttpClient(EnvironmentUrls environmentUrls, ILogger logger, string? email, string? password) : base(environmentUrls, logger)
        {
            Email = email;
            Password = password;

            logger.Information($"CREATING {GetType().Name}: email: {email}");

            Token = AuthorizationService.GetAdminToken(email, password);

            AdminMainService = new AdminMainService(RestService.CreateHttpClient(environmentUrls.HomePage, Settings), Logger, Token.AccessToken ?? string.Empty);
        }
    }
}
