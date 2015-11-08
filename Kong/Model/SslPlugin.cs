using Newtonsoft.Json;

namespace Kong.Model
{
    public class SslPlugin : Plugin
    {
        [JsonProperty("config")]
        public SslPluginConfig Config { get; set; }
    }
}
