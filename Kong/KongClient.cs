using System;
using System.Collections.Generic;
using Kong.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slumber;
using Slumber.Http;
using Slumber.Logging;

namespace Kong
{
    public class KongClient : IKongClient
    {
        private readonly JsonSerializerSettings _settings;

        private readonly Dictionary<Type, IKongRequestFactory> _factories;

        private readonly ISlumberClient _slumber;
        
        public KongClient(string baseUri)
        {
            _factories = new Dictionary<Type, IKongRequestFactory>();
            _settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            };
            _settings.Converters.Add(new IsoDateTimeConverter());
            _slumber = new SlumberClient(baseUri, confgure =>
            {
                confgure.UseKongSerialization(_settings).UseHttp(http => http.ApplicationJson()).UseConsoleLogger();
            });
        }
        
        public void Register(IKongRequestFactory factory)
        {
            if (_factories.ContainsKey(factory.GetType()))
            {
                return;
            }
            _factories.Add(factory.GetType(), factory);
            factory.Configure(_settings);
        }

        public T Get<T>() where T : IKongRequestFactory
        {
            var key = typeof (T);
            if (!_factories.ContainsKey(key))
            {
                return default(T);
            }
            return (T)_factories[key];
        }

        public IRestResponse<T> Execute<T>(IRestRequest<T> request)
        {
            return _slumber.Execute(request);
        }
    }
}
