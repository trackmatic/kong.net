namespace Kong.Plugins.Model
{
    public class SslPluginConfig
    {
        public string Cert { get; set; }

        public string Key { get; set; }

        public bool OnlyHttps { get; set; }
    }
}
