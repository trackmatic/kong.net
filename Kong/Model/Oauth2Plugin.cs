using System.Collections.Generic;
using Kong.Serialization;

namespace Kong.Model
{
    /// <summary>
    /// Add an OAuth 2.0 authentication layer with the Authorization Code Grant, Client Credentials, Implicit Grant or Resource Owner Password Credentials Grant flow. This plugin requires the SSL Plugin with the only_https parameter set to true to be already installed on the API, failing to do so will result in a security weakness.
    /// </summary>
    [Plugin("oauth2")]
    public class Oauth2Plugin : PluginConfiguration
    {
        /// <summary>
        /// Describes an array of comma separated scope names that will be available to the end user
        /// </summary>
        public string[] Scopes { get; set; }

        /// <summary>
        /// An optional boolean value telling the plugin to require at least one scope to be authorized by the end user
        /// </summary>
        public bool MandatoryScope { get; set; }

        /// <summary>
        /// An optional integer value telling the plugin how long should a token last, after which the client will need to refresh the token. Set to 0 to disable the expiration.
        /// </summary>
        public int TokenExpiration { get; set; }

        /// <summary>
        /// An optional boolean value to enable the three-legged Authorization Code flow (RFC 6742 Section 4.1)
        /// </summary>
        public bool EnableAuthorizationCode { get; set; }

        /// <summary>
        /// An optional boolean value to enable the Client Credentials Grant flow (RFC 6742 Section 4.4)
        /// </summary>
        public bool EnableClientCredentials { get; set; }

        /// <summary>
        /// 	An optional boolean value to enable the Implicit Grant flow which allows to provision a token as a result of the authorization process (RFC 6742 Section 4.2)
        /// </summary>
        public bool EnableImplicitGrant { get; set; }

        /// <summary>
        /// An optional boolean value to enable the Resource Owner Password Credentials Grant flow (RFC 6742 Section 4.3)
        /// </summary>
        public bool EnablePasswordGrant { get; set; }

        /// <summary>
        /// An optional boolean value telling the plugin to hide the credential to the upstream API server. It will be removed by Kong before proxying the request
        /// </summary>
        public bool HideCredentials { get; set; }

        /// <summary>
        /// Accepts HTTPs requests that have already been terminated by a proxy or load balancer and the x-forwarded-proto: https header has been added to the request. Only enable this option if the Kong server cannot be publicly accessed and the only entry-point is such proxy or load balancer.
        /// </summary>
        public bool AcceptHttpIfAlreadyTerminated { get; set; }

        public Oauth2Applications Credentials(string consumerId)
        {
            var requestFactory = RequestFactory.Root.Create("/consumers/{consumer_id}/oauth2", new Dictionary<string, string>
            {
                {"consumer_id", consumerId}
            });
            return new Oauth2Applications(requestFactory);
        }
    }
}
