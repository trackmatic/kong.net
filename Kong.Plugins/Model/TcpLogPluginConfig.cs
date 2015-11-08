using Newtonsoft.Json;

namespace Kong.Plugins.Model
{
    public class TcpLogPluginConfig
    {
        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("port")]
        public long Port { get; set; }

        [JsonProperty("timeout")]
        public long Timeout { get; set; }

        [JsonProperty("keepalive")]
        public long KeepAlive { get; set; }
    }
}
