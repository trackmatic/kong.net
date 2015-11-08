using Newtonsoft.Json;

namespace Kong.Model
{
    public class CorsPluginConfig
    {
        [JsonProperty("credentials")]
        public bool Credentials { get; set; }

        [JsonProperty("preflight_continue")]
        public bool PreflightContinue { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("methods")]
        public string Methods { get; set; }

        [JsonProperty("headers")]
        public string Headers { get; set; }

        [JsonProperty("exposed_headers")]
        public string ExposedHeaders { get; set; }

        [JsonProperty("max_age")]
        public long MaxAge { get; set; }
    }
}
