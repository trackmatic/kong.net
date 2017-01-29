using System.Collections.Generic;
using Kong.Serialization;

namespace Kong.Model
{
    /// <summary>
    /// Restrict access to an API by whitelisting or blacklisting consumers using arbitrary ACL group names. This plugin requires an authentication plugin to have been already enabled on the API.
    /// </summary>
    [Plugin("acl")]
    public class AclPlugin : PluginConfiguration
    {
        /// <summary>
        /// Comma separated list of arbitrary group names that are allowed to consume the API. At least one between config.whitelist or config.blacklist must be specified.
        /// </summary>
        public string[] Whitelist { get; set; }

        /// <summary>
        /// Comma separated list of arbitrary group names that are not allowed to consume the API. At least one between config.whitelist or config.blacklist must be specified.
        /// </summary>
        public string[] Blacklist { get; set; }


        public AclPluginGroups Credentials(string consumerId)
        {
            var requestFactory = RequestFactory.Root.Create("/consumers/{consumer_id}/acls", new Dictionary<string, string>
            {
                {"consumer_id", consumerId}
            });
            return new AclPluginGroups(requestFactory);
        }
    }
}
