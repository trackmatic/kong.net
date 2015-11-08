using Newtonsoft.Json;

namespace Kong.Model
{
    public class RateLimitingPlugin : Plugin
    {
        [JsonProperty("consumer_id")]
        public string ConsumerId { get; set; }

        [JsonProperty("config")]
        public RateLimitingPluginConfig Config { get; set; }
    }
}
