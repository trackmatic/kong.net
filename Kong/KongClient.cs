using System;
using System.Collections.Generic;
using Kong.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slumber;
using Slumber.Http;

namespace Kong
{
    public class KongClient : IKongClient
    {
        private readonly JsonSerializerSettings _settings;

        private readonly Dictionary<Type, IKongRequestFactory> _factories;

        private readonly ISlumberClient _slumber;
        
        public KongClient(string baseUri) : this(baseUri, c => { })
        {
        }

        public KongClient(string baseUri, Action<ISlumberConfiguration> configure)
        {

            _factories = new Dictionary<Type, IKongRequestFactory>();
            _settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            };
            _settings.Converters.Add(new IsoDateTimeConverter());
            _slumber = new SlumberClient(baseUri, c =>
            {
                c.UseKongSerialization(_settings).UseHttp(http => http.UseJsonAsDefaultContentType());
                configure(c);
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
