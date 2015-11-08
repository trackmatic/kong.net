using Kong.Model;
using Newtonsoft.Json;

namespace Kong.Plugins.Model
{
    public class RequestSizeLimitingPlugin : Plugin
    {
        [JsonProperty("consumer_id")]
        public string ConsumerId { get; set; }

        [JsonProperty("config")]
        public RequestSizeLimitingPluginConfig Config { get; set; }
    }
}
