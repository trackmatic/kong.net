using Kong.Model;
using Newtonsoft.Json;

namespace Kong.Plugins.Model
{
    public class JwtPlugin : Plugin
    {
        [JsonProperty("config")]
        public JwtPluginConfig Config { get; set; }
    }
}
