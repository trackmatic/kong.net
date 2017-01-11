using Kong.Model;

namespace Kong.Plugins.Model
{
    public class RequestTransformerPlugin : Plugin
    {
        public string ConsumerId { get; set; }

        public RequestSizeLimitingPluginConfig Config { get; set; }
    }
}
