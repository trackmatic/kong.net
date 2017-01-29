using System.Collections.Generic;
using Kong.Serialization;

namespace Kong.Model
{
    /// <summary>
    /// Verify requests containing HS256 or RS256 signed JSON Web Tokens (as specified in RFC 7519). Each of your Consumers will have JWT credentials (public and secret keys) which must be used to sign their JWTs. A token can then be passed through the Authorization header or in the request's URI and Kong will either proxy the request to your upstream services if the token's signature is verified, or discard the request if not. Kong can also perform verifications on some of the registered claims of RFC 7519 (exp and nbf).
    /// </summary>
    [Plugin("jwt")]
    public class JwtAuthPlugin : PluginConfiguration
    {
        /// <summary>
        /// Default jwt. A list of querystring parameters that Kong will inspect to retrieve potential JWTs.
        /// </summary>
        public string[] UriParamNames { get; set; }

        /// <summary>
        /// Default none. A list of registered claims (according to RFC 7519) that Kong can verify as well. Accepted values: exp, nbf.
        /// </summary>
        public string[] ClaimsToVerify { get; set; }

        /// <summary>
        /// Default iss. The name of the claim in which the key identifying the secret must be passed.
        /// </summary>
        public string KeyClaimName { get; set; }

        /// <summary>
        /// Default false. If true, the plugin assumes the credential's secret to be base64 encoded. You will need to create a base64 encoded secret for your consumer, and sign your JWT with the original secret.
        /// </summary>
        public bool SecretIsBase64 { get; set; }

        public JwtAuthCredentials Credentials(string consumerId)
        {
            var requestFactory = RequestFactory.Root.Create("/consumers/{consumer_id}/jwt", new Dictionary<string, string>
            {
                {"consumer_id", consumerId}
            });
            return new JwtAuthCredentials(requestFactory);
        }
    }
}
