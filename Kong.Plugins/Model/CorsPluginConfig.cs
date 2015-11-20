using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kong.Plugins.Model
{
    public class CorsPluginConfig
    {
        public CorsPluginConfig()
        {
            Methods = new List<string>();
            Headers = new Dictionary<string, string>();
            ExposedHeaders = new Dictionary<string, string>();
        }

        [JsonProperty("credentials")]
        public bool Credentials { get; set; }

        [JsonProperty("preflight_continue")]
        public bool PreflightContinue { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("methods")]
        public List<string> Methods { get; set; }

        [JsonProperty("headers")]
        public Dictionary<string, string> Headers { get; set; }

        [JsonProperty("exposed_headers")]
        public Dictionary<string, string> ExposedHeaders { get; set; }

        [JsonProperty("max_age")]
        public long MaxAge { get; set; }
    }
}
