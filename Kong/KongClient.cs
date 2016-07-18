using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Kong.Model;
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
        
        private readonly ISlumberClient _slumber;

        private readonly IPluginFactory _pluginFactory;

        public KongClient(string baseUri) : this(baseUri, new DefaultPluginFactory())
        {
            
        }

        public KongClient(string baseUri, IPluginFactory pluginFactory)
        {
            _pluginFactory = pluginFactory;
            _settings = CreateJsonSerializerSettings();
            _slumber = new SlumberClient(baseUri, c =>
            {
                c.UseKongSerialization(_settings).UseHttp(http => http.UseJsonAsDefaultContentType());
            });
        }
        
        public Task<IResponse<T>> ExecuteAsync<T>(IRequest<T> request)
        {
            return _slumber.ExecuteAsync(request);
        }

        public JsonSerializerSettings CreateJsonSerializerSettings()
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            };
            var converter = new PluginConverter(_pluginFactory);
            settings.Converters.Add(converter);
            settings.Converters.Add(new IsoDateTimeConverter());
            return settings;
        }

        public KongClient RegisterPluginsFrom(Assembly assembly)
        {
            var types = assembly.GetTypes().Where(x => x.BaseType == typeof(Plugin));
            foreach (var type in types)
            {
                _pluginFactory.Register(Plugin.GetNameFromType(type), type);
            }
            return this;
        }
    }
}
