using Automated.API.DTOs.Requests;
using Automated.API.DTOs.Responses;
using Refit;

namespace Automated.API.Services.ServiceInterfaces
{
    public interface IAdminMainService
    {
        [Post("/auth/{project}/login")]
        Task<CreatedUserResponseDto> CreateNewUserAsync(
          [Body(BodySerializationMethod.Serialized)]
          [AliasAs("project")] string project,
          CreateNewUserRequestDto requestDto,
          CancellationToken cToken = default);
    }
}
