using Kong.Serialization;

namespace Kong.Model
{
    [Plugin("acl")]
    public class AclPlugin : PluginConfiguration
    {
        public string Whitelist { get; set; }

        public string Blacklist { get; set; }
    }
}
