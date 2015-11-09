using Newtonsoft.Json;

namespace Kong.Model
{
    public class Consumer
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("custom_id")]
        public string CustomId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }
    }
}
