using Newtonsoft.Json;

namespace Kong.Model
{
    public class IpRestrictionPlugin : Plugin
    {
        [JsonProperty("consumer_id")]
        public string ConsumerId { get; set; }

        [JsonProperty("config")]
        public IpRestrictionPluginconfig Config { get; set; }
    }
}
