using Newtonsoft.Json;

namespace Kong.Plugins.Model
{
    public class KeyAuthPluginConfig
    {
        [JsonProperty("key_names")]
        public string KeyNames { get; set; }

        [JsonProperty("hide_credentials")]
        public bool HideCredentials { get; set; }
    }
}
