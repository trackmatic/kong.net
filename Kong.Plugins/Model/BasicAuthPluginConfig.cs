using Newtonsoft.Json;

namespace Kong.Plugins.Model
{
    public class BasicAuthPluginConfig
    {
        [JsonProperty("hide_credentials")]
        public bool HideCredentials { get; set; }
    }
}
