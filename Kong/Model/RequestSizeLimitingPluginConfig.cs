using Newtonsoft.Json;

namespace Kong.Model
{
    public class RequestSizeLimitingPluginConfig
    {
        [JsonProperty("allowed_payload_size")]
        public long AllowedPayloadSize { get; set; }
    }
}
