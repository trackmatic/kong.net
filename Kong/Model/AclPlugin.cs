using Newtonsoft.Json;

namespace Kong.Model
{
    public class AclPlugin : Plugin
    {
        [JsonProperty("config")]
        public AclPluginConfig Config { get; set; }
    }
}
