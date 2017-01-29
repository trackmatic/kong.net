using System.Collections.Generic;
using Kong.Serialization;

namespace Kong.Model
{
    /// <summary>
    /// Add Basic Authentication to your APIs, with username and password protection. The plugin will check for valid credentials in the Proxy-Authorization and Authorization header (in this order).
    /// </summary>
    [Plugin("basic-auth")]
    public class BasicAuthPlugin : PluginConfiguration
    {
        /// <summary>
        /// An optional boolean value telling the plugin to hide the credential to the upstream API server. It will be removed by Kong before proxying the request
        /// </summary>
        public bool HideCredentials { get; set; }

        public BasicAuthCredentials Credentials(string consumerId)
        {
            var requestFactory = RequestFactory.Root.Create("/consumers/{consumer_id}/basic-auth", new Dictionary<string, string>
            {
                {"consumer_id", consumerId}
            });
            return new BasicAuthCredentials(requestFactory);
        }
    }
}
