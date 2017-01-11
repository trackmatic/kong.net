using Newtonsoft.Json;
using Slumber;
using Slumber.Json;

namespace Kong.Serialization
{
    public class KongSerializerFactory : ISerializationFactory
    {
        private readonly JsonSerializerSettings _settings;
        private readonly ILogger _logger;

        public KongSerializerFactory(JsonSerializerSettings settings, ILogger logger)
        {
            _settings = settings;
            _logger = logger;
        }

        public void Register(JsonConverter converter)
        {
            _settings.Converters.Add(converter);
        }

        public IDeserializer CreateDeserializer()
        {
            return new DynamicJsonDeserializer(_settings);
        }

        public ISerializer CreateSerializer(IRequest request)
        {
            return new DynamicJsonSerializer(_settings, _logger);
        }

        public bool AppliesTo(string contentType)
        {
            return contentType == "application/json";
        }
    }
}