using Newtonsoft.Json;

namespace Kong.Plugins.Model
{
    public class ResponseTransformerPluginConfig
    {
        [JsonProperty("add.headers")]
        public string AddHeaders { get; set; }

        [JsonProperty("add.json")]
        public string AddJson { get; set; }

        [JsonProperty("remove.headers")]
        public string RemoveHeaders { get; set; }

        [JsonProperty("remove.json")]
        public string RemoveJson { get; set; }
    }
}
