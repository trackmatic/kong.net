using Newtonsoft.Json;

namespace Kong.Plugins.Model
{
    public class BasicAuthPlugin : Plugin
    {
        [JsonProperty("config")]
        public BasicAuthPluginConfig Config { get; set; }
    }
}
