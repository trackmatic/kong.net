using System.Collections.Generic;
using System.Threading.Tasks;
using Kong.Slumber;

namespace Kong.Model
{
    public class Plugins : IPlugins
    {
        private readonly IRequestFactory _requestFactory;

        internal Plugins(IRequestFactory requestFactory)
        {
            _requestFactory = requestFactory;
        }

        public async Task<IPlugin> Create(PluginData data)
        {
            var response = await _requestFactory.Post<Plugin>(data).ConfigureAwait(false);
            var requestFactory = _requestFactory.Create("/{plugin_id}", new Dictionary<string, string> { { "plugin_id", response.Id } });
            response.Configure(requestFactory);
            return response;
        }

        public async Task<IPlugin> Get(string id)
        {
            var requestFactory = _requestFactory.Create("/{plugin_id}", new Dictionary<string, string> { { "plugin_id", id } });
            var response = await requestFactory.Get<Plugin>().ConfigureAwait(false);
            response.Configure(requestFactory);
            return response;
        }

        public async Task<dynamic> Schema(string id)
        {
            var requestFactory = _requestFactory.Parent.Parent.Parent.Create("/plugins/schema/{plugin_id}", new Dictionary<string, string> {{"plugin_id", id}});
            var response = await requestFactory.Get<dynamic>().ConfigureAwait(false);
            return response;
        }

        public async Task<ResourceCollection<IPlugin>> List(string id = null,
            string name = null,
            string apiId = null,
            string consumerId = null,
            int size = 100,
            int? offset = 0)
        {
            var parameters = new Dictionary<string, object>
            {
                {"id", id },
                {"name", name },
                {"api_id", apiId },
                {"consumer_id", consumerId },
                {"size", size },
                {"offset", offset },
            };
            var response = await _requestFactory.List<ResourceCollection<Plugin>>(parameters).ConfigureAwait(false);
            return MapToInterface(response);
        }

        private ResourceCollection<IPlugin> MapToInterface(ResourceCollection<Plugin> response)
        {
            var result = new ResourceCollection<IPlugin> { Total = response.Total };
            foreach (var api in response.Data)
            {
                result.Data.Add(Configure(api));
            }
            return result;
        }

        private Plugin Configure(Plugin plugin)
        {
            var requestFactory = _requestFactory.Create("/{plugin_id}", new Dictionary<string, string> { { "plugin_id", plugin.Id } });
            plugin.Configure(requestFactory);
            return plugin;
        }
    }
}
