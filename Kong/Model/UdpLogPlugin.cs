using Kong.Serialization;

namespace Kong.Model
{
    [Plugin("udp-log")]
    public class UdpLogPlugin : PluginConfiguration
    {
        public string Host { get; set; }

        public long Port { get; set; }

        public long Timeout { get; set; }
    }
}
