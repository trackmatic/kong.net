using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Kong.Model
{
    public class Plugin
    {
        public Plugin()
        {
            Name = GetNameFromType(GetType());
        }

        public Plugin(string name)
        {
            Name = name;
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("api_id")]
        public string ApiId { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
        
        public static string GetNameFromType(Type type)
        {
            return Regex.Replace(type.Name, "(\\B[A-Z])", "-$1").Replace("-Plugin", string.Empty).ToLower();
        }
    }
}
