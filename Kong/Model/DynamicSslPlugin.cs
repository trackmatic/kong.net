using Kong.Serialization;

namespace Kong.Model
{
    [Plugin("ssl")]
    public class DynamicSslPlugin : PluginConfiguration
    {
        /// <summary>
        /// Upload the data of the certificate to use. Note that is the the actual data of the key (not the path), so it should be sent in multipart/form-data upload request.
        /// </summary>
        public string Cert { get; set; }

        /// <summary>
        /// Upload the data of the certificate key to use. Note that is the the actual data of the key (not the path), so it should be sent in multipart/form-data upload request.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Specify if the service should only be available through an https protocol.
        /// </summary>
        public bool OnlyHttps { get; set; }

        /// <summary>
        /// If config.only_https is true, accepts HTTPs requests that have already been terminated by a proxy or load balancer and the x-forwarded-proto: https header has been added to the request. Only enable this option if the Kong server cannot be publicly accessed and the only entry-point is such proxy or load balancer.
        /// </summary>
        public bool AcceptHttpIfAlreadyTerminated { get; set; }
    }
}
