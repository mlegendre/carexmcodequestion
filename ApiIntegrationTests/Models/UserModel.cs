using Newtonsoft.Json;

namespace ApiIntegrationTests.Models
{
    public class UserModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
