using Newtonsoft.Json;

namespace Kong.Plugins.Model
{
    public class KeyAuthPluginConfig
    {
        public string KeyNames { get; set; }

        public bool HideCredentials { get; set; }
    }
}
