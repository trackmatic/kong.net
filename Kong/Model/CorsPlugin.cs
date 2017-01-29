using Kong.Serialization;

namespace Kong.Model
{
    [Plugin("cors")]
    public class CorsPlugin : PluginConfiguration
    {
        /// <summary>
        /// Flag to determine whether the Access-Control-Allow-Credentials header should be sent with true as the value.
        /// </summary>
        public bool Credentials { get; set; }

        /// <summary>
        /// A boolean value that instructs the plugin to proxy the OPTIONS preflight request to the upstream API.
        /// </summary>
        public bool PreflightContinue { get; set; }

        /// <summary>
        /// Value for the Access-Control-Allow-Origin header, expects a String.
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// Value for the Access-Control-Allow-Methods header, expects a comma delimited string (e.g. GET,POST).
        /// </summary>
        public string[] Methods { get; set; }

        /// <summary>
        /// Value for the Access-Control-Allow-Headers header, expects a comma delimited string (e.g. Origin, Authorization).
        /// </summary>
        public string[] Headers { get; set; }

        /// <summary>
        /// Value for the Access-Control-Expose-Headers header, expects a comma delimited string (e.g. Origin, Authorization). If not specified, no custom headers are exposed.
        /// </summary>
        public string[] ExposedHeaders { get; set; }

        /// <summary>
        /// Indicated how long the results of the preflight request can be cached, in seconds.
        /// </summary>
        public long MaxAge { get; set; }
    }
}
