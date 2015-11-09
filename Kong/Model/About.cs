using Newtonsoft.Json;

namespace Kong.Model
{
    public class About
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("lua_version")]
        public string LuaVersion { get; set; }

        [JsonProperty("tagline")]
        public string Tagline { get; set; }

        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        [JsonProperty("plugins")]
        public AboutPlugins Plugins { get; set; }
    }
}
