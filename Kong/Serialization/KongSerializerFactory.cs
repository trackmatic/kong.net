using System.Linq;
using Kong.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slmber.Json;
using Slumber;

namespace Kong.Serialization
{
    public class KongSerializerFactory : ISerializationFactory
    {
        private static readonly JsonSerializerSettings Settings;

        static KongSerializerFactory()
        {
            var factory = CreatePluginFactory();
            Settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            };
            Settings.Converters.Add(new PluginConverter(factory));
            Settings.Converters.Add(new IsoDateTimeConverter());
        }

        static IPluginFactory CreatePluginFactory()
        {
            var types = typeof(KongSerializerFactory).Assembly.GetTypes().Where(x => x.BaseType == typeof(Plugin));
            var factory = new DefaultPluginFactory();
            foreach (var type in types)
            {
                factory.Register(Plugin.GetNameFromType(type), type);
            }
            return factory;
        }

        public IDeserializer CreateDeserializer()
        {
            return new DynamicJsonDeserializer(Settings);
        }

        public ISerializer CreateSerializer()
        {
            return new DynamicJsonSerializer(Settings);
        }
    }
}