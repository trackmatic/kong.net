using Slumber;

namespace Kong.Serialization
{
    public static class ConfigurationExtensions
    {
        public static ISlumberConfiguration UseKongSerialization(this ISlumberConfiguration configuration)
        {
            configuration.Serialization = new KongSerializerFactory();
            return configuration;
        }
    }
}
