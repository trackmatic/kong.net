using Kong.Model;
using Newtonsoft.Json;

namespace Kong.Plugins.Model
{
    public class TcpLogPlugin : Plugin
    {
        [JsonProperty("consumer_id")]
        public string ConsumerId { get; set; }

        [JsonProperty("config")]
        public TcpLogPluginConfig Config { get; set; }
    }
}
