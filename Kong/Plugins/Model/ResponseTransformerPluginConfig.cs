using Newtonsoft.Json;

namespace Kong.Plugins.Model
{
    public class ResponseTransformerPluginConfig
    {
        public string AddHeaders { get; set; }

        public string AddJson { get; set; }

        public string RemoveHeaders { get; set; }

        public string RemoveJson { get; set; }
    }
}
