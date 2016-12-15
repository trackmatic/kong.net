using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kong.Plugins.Model
{
    public class CorsPluginConfig
    {
        public CorsPluginConfig()
        {

        }

        [JsonProperty("credentials")]
        public bool Credentials { get; set; }

        [JsonProperty("preflight_continue")]
        public bool PreflightContinue { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("methods")]
        public object Methods { get; set; }

        [JsonProperty("headers")]
        public object Headers { get; set; }

        [JsonProperty("exposed_headers")]
        public object ExposedHeaders { get; set; }

        [JsonProperty("max_age")]
        public long MaxAge { get; set; }
    }
}
