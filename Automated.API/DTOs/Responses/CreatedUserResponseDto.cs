using Newtonsoft.Json;

namespace Automated.API.DTOs.Responses
{
    public class CreatedUserResponseDto
    {
        [JsonProperty("created")]
        public bool Created { get; set; }
    }
}
