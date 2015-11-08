using Kong.Model;
using Newtonsoft.Json;

namespace Kong.Plugins.Model
{
    public class SslPlugin : Plugin
    {
        [JsonProperty("config")]
        public SslPluginConfig Config { get; set; }
    }
}
