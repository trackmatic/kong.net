using System.Collections.Generic;
using System.Threading.Tasks;
using Kong.Model;

namespace Kong.Plugins
{
    public class PluginRequestFactory : RequestFactory<Plugin>
    {
        public PluginRequestFactory(IKongClient client) : base(client, "plugins")
        {
        }

        public Task<IKongCollection<Plugin>> List(string name = null, string consumerId = null, int size = 100, int offset = 0)
        {
            return List(new Dictionary<string, object>
            {
                {"name", name},
                {"consumer_id", consumerId},
                {"size", size},
                {"offset", offset}
            });
        }

        public override async Task<IKongCollection<Plugin>> List(IDictionary<string, object> parameters)
        {
            var response = await ExecuteAsync(CreateGet<KongCollection<Plugin>>(parameters));
            return response;
        }
        public async Task<T> Get<T>(string id) where T : Plugin
        {
            var response = await Get(id);
            return (T)response;
        }

        public override Task<Plugin> Get(string id)
        {
            return ExecuteAsync(CreateGet<Plugin>(id));
        }

        public override Task Delete(string id)
        {
            return ExecuteAsync(CreateDelete(id));
        }

        public override Task<Plugin> Post(Plugin data)
        {
            return ExecuteAsync(CreatePost<Plugin>(data));
        }

        public override Task<Plugin> Put(Plugin data)
        {
            return ExecuteAsync(CreatePut<Plugin>(data));
        }

        public override Task<Plugin> Patch(Plugin data)
        {
            return ExecuteAsync(CreatePatch<Plugin>(data.Id, data));
        }
    }
}
