using Newtonsoft.Json;

namespace Kong.Model
{
    public class Consumer
    {
        [JsonProperty("consumer_id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }
}
