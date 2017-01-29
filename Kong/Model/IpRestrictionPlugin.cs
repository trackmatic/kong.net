using Kong.Serialization;

namespace Kong.Model
{
    [Plugin("ip-restriction")]
    public class IpRestrictionPlugin : PluginConfiguration
    {
        /// <summary>
        /// Comma separated list of IPs or CIDR ranges to whitelist. At least one between config.whitelist or config.blacklist must be specified.
        /// </summary>
        public string[] Whitelist { get; set; }

        /// <summary>
        /// Comma separated list of IPs or CIDR ranges to whitelist. At least one between config.whitelist or config.blacklist must be specified.
        /// </summary>

        public string[] Blacklist { get; set; }
    }
}
