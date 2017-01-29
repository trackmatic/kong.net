using System.Collections.Generic;
using Kong.Serialization;

namespace Kong.Model
{
    /// <summary>
    /// Add Key Authentication (also referred to as an API key) to your APIs. Consumers then add their key either in a querystring parameter or a header to authenticate their requests.
    /// </summary>
    [Plugin("key-auth")]
    public class KeyAuthPlugin : PluginConfiguration
    {
        /// <summary>
        /// Describes an array of comma separated parameter names where the plugin will look for a key. The client must send the authentication key in one of those key names, and the plugin will try to read the credential from a header or the querystring parameter with the same name.
        /// </summary>
        public string[] KeyNames { get; set; }

        /// <summary>
        /// An optional boolean value telling the plugin to hide the credential to the upstream API server. It will be removed by Kong before proxying the request.
        /// </summary>
        public bool HideCredentials { get; set; }

        public KeyAuthCredentials Credentials(string consumerId)
        {
            var requestFactory = RequestFactory.Root.Create("/consumers/{consumer_id}/key-auth", new Dictionary<string, string>
            {
                {"consumer_id", consumerId}
            });
            return new KeyAuthCredentials(requestFactory);
        }
    }
}
