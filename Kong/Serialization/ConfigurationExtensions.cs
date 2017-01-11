using Newtonsoft.Json;
using Slumber;

namespace Kong.Serialization
{
    public static class ConfigurationExtensions
    {
        public static ISlumberConfiguration UseKongSerialization(this ISlumberConfiguration configuration, JsonSerializerSettings settings)
        {
            configuration.Serialization = new KongSerializationProvider(settings, configuration.Log); 
            return configuration;
        }
    }
}
