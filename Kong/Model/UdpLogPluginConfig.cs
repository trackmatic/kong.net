using Newtonsoft.Json;

namespace Kong.Model
{
    public class UdpLogPluginConfig
    {
        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("port")]
        public long Port { get; set; }

        [JsonProperty("timeout")]
        public long Timeout { get; set; }
    }
}
