using System.Collections.Generic;
using Kong.Serialization;

namespace Kong.Model
{
    /// <summary>
    /// Add HMAC Signature Authentication to your APIs to establish the identity of the consumer. The plugin will check for valid signature in the Proxy-Authorization and Authorization header (in this order). This plugin implementation follows the draft-cavage-http-signatures-00 draft with slightly changed signature scheme.
    /// </summary>
    [Plugin("hmac-auth")]
    public class HmacAuthPlugin : PluginConfiguration
    {
        /// <summary>
        /// An optional boolean value telling the plugin to hide the credential to the upstream API server. It will be removed by Kong before proxying the request
        /// </summary>
        public bool HideCredentials { get; set; }

        /// <summary>
        /// Clock Skew in seconds to prevent replay attacks.
        /// </summary>
        public int ClockSkew { get; set; }

        public HmacAuthCredentials Credentials(string consumerId)
        {
            var requestFactory = RequestFactory.Root.Create("/consumers/{consumer_id}/hmac-auth", new Dictionary<string, string>
            {
                {"consumer_id", consumerId}
            });
            return new HmacAuthCredentials(requestFactory);
        }
    }
}
