using Newtonsoft.Json;

namespace Automated.API.DTOs.Responses
{
    public class TokenResponseDto
    {
        [JsonProperty("access_token")]
        public string? AccessToken { get; set; }
    }
}
