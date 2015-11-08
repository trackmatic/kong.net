using Newtonsoft.Json;

namespace Kong.Plugins.Model
{
    public class RequestTransformerPlugin : Plugin
    {
        [JsonProperty("consumer_id")]
        public string ConsumerId { get; set; }

        [JsonProperty("config")]
        public RequestSizeLimitingPluginConfig Config { get; set; }
    }
}
