using Kong.Serialization;

namespace Kong.Model
{
    [Plugin("tcp-log")]
    public class TcpLogPlugin : PluginConfiguration
    {
        public string Host { get; set; }

        public long Port { get; set; }

        public long Timeout { get; set; }

        public long KeepAlive { get; set; }
    }
}
