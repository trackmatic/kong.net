using Kong.Model;
using Newtonsoft.Json;

namespace Kong.Plugins.Model
{
    public class CorsPlugin : Plugin
    {
        [JsonProperty("config")]
        public CorsPluginConfig Config { get; set; }
    }
}
