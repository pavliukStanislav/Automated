using Automated.API.DTOs.Requests;
using Automated.API.DTOs.Responses;
using Automated.API.Services.ServiceInterfaces;
using Refit;
using Serilog;
using System.Reflection;

namespace Automated.API.Services
{
    public class AdminMainService : BaseService
    {
        private readonly IAdminMainService _service;

        public AdminMainService(HttpClient httpClient, ILogger logger, string token) : base(logger, token)
        {
            ServiceName = GetType().Name;

            Logger.Information($"CREATING {ServiceName} [{httpClient.BaseAddress?.AbsoluteUri}]");

            _service = RestService.For<IAdminMainService>(httpClient);
        }

        public CreatedUserResponseDto CreateNewUser(string project, string name, string password, string address)
        {
            Logger.Information($"REQUEST {ServiceName}: {MethodBase.GetCurrentMethod()?.Name}");

            var loginDto = new CreateNewUserRequestDto
            {
                UserName = name,
                Password = password,
                Address = address
            };

            return ApiResponse(_service.CreateNewUserAsync(project ,loginDto));
        }
    }
}