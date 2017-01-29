using Kong.Serialization;

namespace Kong.Model
{
    /// <summary>
    /// Block incoming requests whose body is greater than a specific size in megabytes.
    /// </summary>
    [Plugin("request-size-limiting")]
    public class RequestSizeLimitingPlugin : PluginConfiguration
    {
        /// <summary>
        /// Allowed request payload size in megabytes, default is 128 (128000000 Bytes)
        /// </summary>
        public long AllowedPayloadSize { get; set; }
    }
}
