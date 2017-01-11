using Kong.Model;

namespace Kong.Plugins.Model
{
    public class RateLimitingPlugin : Plugin
    {
        public string ConsumerId { get; set; }

        public RateLimitingPluginConfig Config { get; set; }
    }
}
