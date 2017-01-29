namespace Kong.Model
{
    public class SslPlugin : PluginConfiguration
    {
        public string Cert { get; set; }

        public string Key { get; set; }

        public bool OnlyHttps { get; set; }
    }
}
