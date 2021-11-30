using Automated.API.DTOs.Requests;
using Automated.API.DTOs.Responses;
using Automated.API.Services.ServiceInterfaces;
using Automated.Configurations;
using Refit;
using Serilog;

namespace Automated.API.Services
{
    public class AuthorizationService : BaseService
    {
        private readonly IAuthorizationService _service;

        public AuthorizationService(HttpClient httpClient, ILogger logger)
      : base(logger, token: null)
        {
            ServiceName = GetType().Name;

            Logger.Information($"CREATING {ServiceName} [{httpClient.BaseAddress?.AbsoluteUri}]");

            _service = RestService.For<IAuthorizationService>(httpClient);
        }

        public TokenResponseDto GetAdminToken(string? email = default, string? password = default)
        {
            var loginDto = new LoginRequestDto
            {
                UserName = email ?? Credentials.Data.Admin?.Email,
                Password = password ?? Credentials.Data.Admin?.Password
            };

            Logger.Information($"GET ADMIN TOKEN ({ServiceName}): [user_name = {loginDto.UserName}]");

            var token = ApiResponse(_service.GetAuthTokenAsync(loginDto));

            token.AccessToken = "Bearer " + token.AccessToken;

            return token;
        }

        public TokenResponseDto GetUserToken(string? email = default, string? password = default)
        {
            var loginDto = new LoginRequestDto
            {
                UserName = email ?? Credentials.Data.User?.Email,
                Password = password ?? Credentials.Data.User?.Password
            };

            Logger.Information($"GET USER TOKEN ({ServiceName}): [user_name = {loginDto.UserName}]");

            var token = ApiResponse(_service.GetAuthTokenAsync(loginDto));

            token.AccessToken = "Bearer " + token.AccessToken;

            return token;
        }
    }
}
