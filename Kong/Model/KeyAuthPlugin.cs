using Kong.Serialization;

namespace Kong.Model
{
    [Plugin("key-auth")]
    public class KeyAuthPlugin : PluginConfiguration
    {
        public string KeyNames { get; set; }

        public bool HideCredentials { get; set; }
    }
}
