using Newtonsoft.Json;

namespace Automated.API.DTOs.Requests
{
    public class LoginRequestDto
    {        
        [JsonProperty("user_name")]
        public string? UserName { get; set; }

        [JsonProperty("password")]
        public string? Password { get; set; }        
    }
}
