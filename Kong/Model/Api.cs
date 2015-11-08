using Newtonsoft.Json;
using Slumber;

namespace Kong.Model
{
    public class Api
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("request_host")]
        public string RequestHost { get; set; }

        [JsonProperty("upstream_url")]
        public string UpstreamUrl { get; set; }

        [JsonProperty("preserve_host")]
        public bool PreserveHost { get; set; }

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }

        [JsonProperty("strip_request_path")]
        public bool? StripRequestPath { get; set; }

        [JsonProperty("request_path")]
        public string RequestPath { get; set; }
    }
}
