using Newtonsoft.Json;

namespace Kong.Plugins.Model
{
    public class JwtCredentials
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("consumer_id")]
        public string ConsumerId { get; set; }

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("secret")]
        public string Secret { get; set; }
    }
}
