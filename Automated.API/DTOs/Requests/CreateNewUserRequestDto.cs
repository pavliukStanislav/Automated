using Newtonsoft.Json;

namespace Automated.API.DTOs.Requests
{
    public class CreateNewUserRequestDto
    {
        [JsonProperty("user_name")]
        public string? UserName { get; set; }

        [JsonProperty("password")]
        public string? Password { get; set; }

        [JsonProperty("address")]
        public string? Address { get; set; }
    }
}
