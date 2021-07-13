using Newtonsoft.Json;

namespace API.PowerBI.Models
{

    public class AccessToken
    {
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("scope")]
        public string Scope { get; set; }
        [JsonProperty("expires_in")]
        public int ExpiriesIn { get; set; }
        [JsonProperty("access_token")]
        public string Token { get; set; }
    }
}
