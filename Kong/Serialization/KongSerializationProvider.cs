using System;
using Newtonsoft.Json;
using Slumber;

namespace Kong.Serialization
{
    public class KongSerializationProvider : ISerializationProvider
    {
        private readonly KongSerializerFactory _factory;

        public KongSerializationProvider(JsonSerializerSettings settings, ILogger log)
        {
            _factory = new KongSerializerFactory(settings, log);
        }

        public ISerializer CreateSerializer(IRequest request)
        {
            return _factory.CreateSerializer(request);
        }

        public IDeserializer CreateDeserializer(IResponse response)
        {
            return _factory.CreateDeserializer();
        }

        public void Register(ISerializationFactory factory)
        {
            throw new NotSupportedException();
        }
    }
}
