using Newtonsoft.Json;

namespace Kong.Plugins.Model
{
    public class KeyAuthPlugin
    {
        [JsonProperty("config")]
        public KeyAuthPluginConfig Config { get; set; }
    }
}
