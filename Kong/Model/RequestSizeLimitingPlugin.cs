using Kong.Serialization;

namespace Kong.Model
{
    [Plugin("request-size-limiting")]
    public class RequestSizeLimitingPlugin : PluginConfiguration
    {
        public long AllowedPayloadSize { get; set; }
    }
}
