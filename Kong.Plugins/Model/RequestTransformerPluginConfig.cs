using Newtonsoft.Json;

namespace Kong.Plugins.Model
{
    public class RequestTransformerPluginConfig
    {
        [JsonProperty("add.headers")]
        public string AddHeaders { get; set; }

        [JsonProperty("add.querystring")]
        public string AddQueryString { get; set; }

        [JsonProperty("add.form")]
        public string AddForm { get; set; }

        [JsonProperty("remove.headers")]
        public string RemoveHeaders { get; set; }

        [JsonProperty("remove.querystring")]
        public string RemoveQueryString { get; set; }

        [JsonProperty("remove.form")]
        public string RemoveForm { get; set; }
    }
}
