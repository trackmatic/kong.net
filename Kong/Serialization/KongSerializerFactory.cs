using Newtonsoft.Json;
using Slmber.Json;
using Slumber;

namespace Kong.Serialization
{
    public class KongSerializerFactory : ISerializationFactory
    {
        private readonly JsonSerializerSettings _settings;

        public KongSerializerFactory(JsonSerializerSettings settings)
        {
            _settings = settings;
        }

        public void Register(JsonConverter converter)
        {
            _settings.Converters.Add(converter);
        }

        public IDeserializer CreateDeserializer()
        {
            return new DynamicJsonDeserializer(_settings);
        }

        public ISerializer CreateSerializer()
        {
            return new DynamicJsonSerializer(_settings);
        }
    }
}