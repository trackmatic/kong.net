using Newtonsoft.Json;

namespace Kong.Model
{
    public class Status
    {
        [JsonProperty("connections_handled")]
        public int ConnectionsHandled { get; set; }

        [JsonProperty("connections_reading")]
        public int ConnectionsReading { get; set; }

        [JsonProperty("connections_active")]
        public int ConnectionsActive { get; set; }

        [JsonProperty("connections_waiting")]
        public int ConnectionsWaiting { get; set; }

        [JsonProperty("connections_writing")]
        public int ConnectionsWriting { get; set; }

        [JsonProperty("total_requests")]
        public long TotalRuests { get; set; }

        [JsonProperty("connections_accepted")]
        public long ConnectionsAccepted { get; set; }
    }
}
