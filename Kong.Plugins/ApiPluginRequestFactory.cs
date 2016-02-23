using System.Collections.Generic;
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

        public IKongCollection<Plugin> List(string name = null, string consumerId = null, int size = 100, int offset = 0)
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

        public T Get<T>(string id) where T : Plugin
        {
            return (T) Get(id);
        }

        public override IKongCollection<Plugin> List(IDictionary<string, object> parameters)
        {
            return Execute(CreateGet<KongCollection<Plugin>>(parameters));
        }

        public override Plugin Get(string id)
        {
            return Execute(CreateGet<Plugin>(id, new Dictionary<string, object>
            {
                {"apiId", _api.Id}
            }));
        }

        public override void Delete(string id)
        {
            Execute(CreateDelete(id, new Dictionary<string, object>
            {
                {"apiId", _api.Id}
            }));
        }

        public override Plugin Post(Plugin data)
        {
            return Execute(CreatePost<Plugin>(data, new Dictionary<string, object>
            {
                {"apiId", _api.Id}
            }));
        }

        public override Plugin Put(Plugin data)
        {
            return Execute(CreatePut<Plugin>(data, new Dictionary<string, object>
            {
                {"apiId", _api.Id}
            }));
        }

        public override Plugin Patch(Plugin data)
        {
            return Execute(CreatePatch<Plugin>(data.Id, data, new Dictionary<string, object>
            {
                {"apiId", _api.Id}
            }));
        }
    }
}
