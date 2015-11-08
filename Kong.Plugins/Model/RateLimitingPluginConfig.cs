using Newtonsoft.Json;

namespace Kong.Plugins.Model
{
    public class RateLimitingPluginConfig
    {
        [JsonProperty("second")]
        public long? Second { get; set; }

        [JsonProperty("minute")]
        public long? Minute { get; set; }

        [JsonProperty("hour")]
        public long? Hour { get; set; }

        [JsonProperty("day")]
        public long? Day { get; set; }

        [JsonProperty("month")]
        public long? Month { get; set; }

        [JsonProperty("year")]
        public long? Year { get; set; }
    }
}
