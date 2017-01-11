using Kong.Model;

namespace Kong.Plugins.Model
{
    public class UdpLogPlugin : Plugin
    {
        public string ConsumerId { get; set; }

        public UdpLogPluginConfig Config { get; set; }
    }
}