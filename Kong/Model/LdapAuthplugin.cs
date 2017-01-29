using Kong.Serialization;

namespace Kong.Model
{
    /// <summary>
    /// Add LDAP Bind Authentication to your APIs, with username and password protection. The plugin will check for valid credentials in the Proxy-Authorization and Authorization header (in this order).
    /// </summary>
    [Plugin("ldap-auth")]
    public class LdapAuthPlugin : PluginConfiguration
    {
        /// <summary>
        /// An optional boolean value telling the plugin to hide the credential to the upstream API server. It will be removed by Kong before proxying the request.
        /// </summary>
        public bool HideCredentials { get; set; }

        /// <summary>
        /// Host on which the LDAP server is running.
        /// </summary>
        public string LdapHost { get; set; }

        /// <summary>
        /// TCP port where the LDAP server is listening.
        /// </summary>
        public int LdapPort { get; set; }

        /// <summary>
        /// Set it to true to issue StartTLS (Transport Layer Security) extended operation over ldap connection.
        /// </summary>
        public bool StartTls { get; set; }

        /// <summary>
        /// Base DN as the starting point for the search.
        /// </summary>
        public string BaseDn { get; set; }

        /// <summary>
        /// Set it to true to authenticate LDAP server. The server certificate will be verified according to the CA certificates specified by the lua_ssl_trusted_certificate directive.
        /// </summary>
        public bool VerifyLdapHost { get; set; }

        /// <summary>
        /// Attribute to be used to search the user.
        /// </summary>
        public string Attribute { get; set; }

        /// <summary>
        /// Cache expiry time in seconds.
        /// </summary>
        public int CacheTtl { get; set; }

        /// <summary>
        /// An optional timeout in milliseconds when waiting for connection with LDAP server.
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// An optional value in milliseconds that defines for how long an idle connection to LDAP server will live before being closed.
        /// </summary>
        public int Keepalive { get; set; }
    }
}
