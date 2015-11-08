using Kong.Model;
using Newtonsoft.Json;

namespace Kong.Plugins.Model
{
    public class AclPlugin : Plugin
    {
        [JsonProperty("config")]
        public AclPluginConfig Config { get; set; }
    }
}
