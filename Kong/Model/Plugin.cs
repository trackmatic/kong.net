using System.Threading.Tasks;
using Kong.Exceptions;
using Kong.Serialization;
using Kong.Slumber;
using Newtonsoft.Json;

namespace Kong.Model
{

    [JsonConverter(typeof(PluginConverter))]
    public class Plugin : IPlugin
    {
        private IRequestFactory _requestFactory;
        
        public string Id { get; set; }
        public string Name { get; set; }
        public string ApiId { get; set; }
        public bool Enabled { get; set; }
        public IPluginConfiguration Config { get; set; }
        public long CreatedAt { get; set; }
        public string ConsumerId { get; set; }

        public T Configure<T>() where T : IPluginConfiguration
        {
            if (PluginTypeHelper.GetName<T>() != Name)
            {
                throw new PluginConfigurationException(Name, typeof(T));
            }
            return (T) Config;
        }

        public Task Delete()
        {
            return _requestFactory.Delete();
        }

        public async Task<IPlugin> Save()
        {
            var data = new PluginUpdate
            {
                Id = Id,
                CreatedAt = CreatedAt,
                ApiId = ApiId,
                Config = Config,
                ConsumerId = ConsumerId,
                Enabled = Enabled
            };
            var response = await _requestFactory.Parent.Put<Plugin>(data);
            response.Configure(_requestFactory);
            return response;
        }

        internal void Configure(IRequestFactory requestFactory)
        {
            _requestFactory = requestFactory;
            Config.Configure(_requestFactory);
        }

        private class PluginUpdate : PluginData
        {
            public string Id { get; set; }
            public long CreatedAt { get; set; }
            public string ApiId { get; set; }
            public bool Enabled { get; set; }
        }
    }
}
