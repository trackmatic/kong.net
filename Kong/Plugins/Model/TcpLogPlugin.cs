using Kong.Model;

namespace Kong.Plugins.Model
{
    public class TcpLogPlugin : Plugin
    {
        public string ConsumerId { get; set; }

        public TcpLogPluginConfig Config { get; set; }
    }
}
