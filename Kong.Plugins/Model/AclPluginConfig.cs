using Newtonsoft.Json;

namespace Kong.Plugins.Model
{
    public class AclPluginConfig
    {
        [JsonProperty("whitelist")]
        public string Whitelist { get; set; }

        [JsonProperty("blacklist")]
        public string Blacklist { get; set; }
    }
}
