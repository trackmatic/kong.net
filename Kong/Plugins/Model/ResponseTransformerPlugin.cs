using Kong.Model;

namespace Kong.Plugins.Model
{
    public class ResponseTransformerPlugin : Plugin
    {
        public string ConsumerId { get; set; }

        public ResponseTransformerPluginConfig Config { get; set; }
    }
}
