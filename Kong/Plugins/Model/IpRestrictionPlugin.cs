using Kong.Model;

namespace Kong.Plugins.Model
{
    public class IpRestrictionPlugin : Plugin
    {
        public string ConsumerId { get; set; }

        public IpRestrictionPluginconfig Config { get; set; }
    }
}
