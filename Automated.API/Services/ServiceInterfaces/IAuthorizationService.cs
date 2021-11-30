using Automated.API.DTOs.Requests;
using Automated.API.DTOs.Responses;
using Refit;

namespace Automated.API.Services.ServiceInterfaces
{
    public interface IAuthorizationService
    {
        [Post("/auth/login")]
        Task<TokenResponseDto> GetAuthTokenAsync(
          [Body(BodySerializationMethod.Serialized)]
          LoginRequestDto authDto,
          CancellationToken cToken = default);
    }
}
