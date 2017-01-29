using Kong.Serialization;

namespace Kong.Model
{
    [Plugin("response-transformer")]
    public class ResponseTransformerPlugin : PluginConfiguration
    {
        public string AddHeaders { get; set; }

        public string AddJson { get; set; }

        public string RemoveHeaders { get; set; }

        public string RemoveJson { get; set; }
    }
}
