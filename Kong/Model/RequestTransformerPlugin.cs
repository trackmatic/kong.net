using Kong.Serialization;

namespace Kong.Model
{
    [Plugin("request-transformer")]
    public class RequestTransformerPlugin : PluginConfiguration
    {
        public string AddHeaders { get; set; }

        public string AddQueryString { get; set; }

        public string AddForm { get; set; }

        public string RemoveHeaders { get; set; }

        public string RemoveQueryString { get; set; }

        public string RemoveForm { get; set; }
    }
}
