using Kong.Serialization;

namespace Kong.Model
{
    [Plugin("ip-restriction")]
    public class IpRestrictionPluginconfig
    {
        public string Whitelist { get; set; }

        public string Blacklist { get; set; }
    }
}
