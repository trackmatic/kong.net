using Newtonsoft.Json;

namespace Kong.Plugins.Model
{
    public class JwtPluginConfig
    {
        /// <summary>
        /// Default jwt. A list of querystring parameters that Kong will inspect to retrieve potential JWTs.
        /// </summary>
        [JsonProperty("uri_param_names")]
        public string[] UriParamNames { get; set; }

        /// <summary>
        /// Default none. A list of registered claims (according to RFC 7519) that Kong can verify as well. Accepted values: exp, nbf.
        /// </summary>
        [JsonProperty("claims_to_verify")]
        public string[] ClaimsToVerify { get; set; }

        /// <summary>
        /// Default iss. The name of the claim in which the key identifying the secret must be passed.
        /// </summary>
        [JsonProperty("key_claim_name")]
        public string KeyClaimName { get; set; }

        /// <summary>
        /// Default false. If true, the plugin assumes the credential's secret to be base64 encoded. You will need to create a base64 encoded secret for your consumer, and sign your JWT with the original secret.
        /// </summary>
        [JsonProperty("secret_is_base64")]
        public string SecretIsBase64 { get; set; }
    }
}
