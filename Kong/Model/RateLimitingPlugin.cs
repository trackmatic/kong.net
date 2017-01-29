using Kong.Serialization;

namespace Kong.Model
{
    [Plugin("rate-limiting")]
    public class RateLimitingPlugin : PluginConfiguration
    {
        public long? Second { get; set; }

        public long? Minute { get; set; }

        public long? Hour { get; set; }

        public long? Day { get; set; }

        public long? Month { get; set; }

        public long? Year { get; set; }
    }
}
