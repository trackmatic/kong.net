using System.Collections.Generic;
using System.Threading.Tasks;
using Kong.Model;

namespace Kong.Plugins
{
    public class ApiPluginRequestFactory : RequestFactory<Plugin>, IPluginRequestFactory
    {
        private readonly Api _api;
        
        public ApiPluginRequestFactory(IKongClient client, Api api) : base(client, "apis/{apiId}/plugins")
        {
            _api = api;
        }

        public Task<IKongCollection<Plugin>> List(string name = null, string consumerId = null, int size = 100, int offset = 0)
        {
            return List(new Dictionary<string, object>
            {
                {"name", name},
                {"consumer_id", consumerId},
                {"size", size},
                {"offset", offset},
                {"apiId", _api.Id}
            });
        }

        public async Task<T> Get<T>(string id) where T : Plugin
        {
            var response = await Get(id);
            return (T)response;
        }

        public override async Task<IKongCollection<Plugin>> List(IDictionary<string, object> parameters)
        {
            var response = await ExecuteAsync(CreateGet<KongCollection<Plugin>>(parameters));
            return response;
        }

        public override Task<Plugin> Get(string id)
        {
            return ExecuteAsync(CreateGet<Plugin>(id, new Dictionary<string, object>
            {
                {"apiId", _api.Id}
            }));
        }

        public override Task Delete(string id)
        {
            return ExecuteAsync(CreateDelete(id, new Dictionary<string, object>
            {
                {"apiId", _api.Id}
            }));
        }

        public override Task<Plugin> Post(Plugin data)
        {
            return ExecuteAsync(CreatePost<Plugin>(data, new Dictionary<string, object>
            {
                {"apiId", _api.Id}
            }));
        }

        public override Task<Plugin> Put(Plugin data)
        {
            return ExecuteAsync(CreatePut<Plugin>(data, new Dictionary<string, object>
            {
                {"apiId", _api.Id}
            }));
        }

        public override Task<Plugin> Patch(Plugin data)
        {
            return ExecuteAsync(CreatePatch<Plugin>(data.Id, data, new Dictionary<string, object>
            {
                {"apiId", _api.Id}
            }));
        }
    }
}
