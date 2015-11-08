using Newtonsoft.Json;

namespace Kong.Plugins.Model
{
    public class SslPluginConfig
    {
        [JsonProperty("cert")]
        public string Cert { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("only_https")]
        public bool OnlyHttps { get; set; }
    }
}
