namespace Kong.Plugins.Model
{
    public class TcpLogPluginConfig
    {
        public string Host { get; set; }

        public long Port { get; set; }

        public long Timeout { get; set; }

        public long KeepAlive { get; set; }
    }
}
