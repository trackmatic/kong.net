using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kong.Model
{
    public class AboutPlugins
    {
        [JsonProperty("enabled_in_cluster")]
        public List<string> EnabledInCluster { get; set; }

        [JsonProperty("available_on_server")]
        public List<string> AvailableOnServer { get; set; }
    }
}
