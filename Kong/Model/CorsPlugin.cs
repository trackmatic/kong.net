using Newtonsoft.Json;

namespace Kong.Model
{
    public class CorsPlugin : Plugin
    {
        [JsonProperty("config")]
        public CorsPluginConfig Config { get; set; }
    }
}
