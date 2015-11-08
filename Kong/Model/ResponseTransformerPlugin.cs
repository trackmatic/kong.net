using Newtonsoft.Json;

namespace Kong.Model
{
    public class ResponseTransformerPlugin : Plugin
    {
        [JsonProperty("consumer_id")]
        public string ConsumerId { get; set; }

        [JsonProperty("config")]
        public ResponseTransformerPluginConfig Config { get; set; }
    }
}
