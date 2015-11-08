using System.Collections.Generic;
using System.Linq;
using Kong.Model;
using Kong.Plugins.Model;
using Kong.Plugins.Serialization;
using Newtonsoft.Json;

namespace Kong.Plugins
{
    public class PluginResource : ResourceBase<Plugin>
    {
        public PluginResource(IKongClient client, Api api) : base(client, $"apis/{api.Id}/plugins")
        {
            client.Register(this);
        }

        public IKongCollection<Plugin> List(string name = null, string consumerId = null, int size = 100, int offset = 0)
        {
            return List(new Dictionary<string, object>
            {
                { "name", name  },
                { "consumer_id", consumerId  },
                { "size", size  },
                { "offset", offset }
            });
        }

        public override IKongCollection<Plugin> List(IDictionary<string, object> parameters)
        {
            return Execute(CreateGet<KongCollection<Plugin>>(parameters));
        }

        public override Plugin Get(string id)
        {
            return Execute(CreateGet<Plugin>(id, new Dictionary<string, object>()));
        }

        public override void Delete(string id)
        {
            Execute(CreateDelete(id));
        }

        public override Plugin Post(Plugin data)
        {
            return Execute(CreatePost<Plugin>(data));
        }

        public override Plugin Patch(Plugin data)
        {
            return Execute(CreatePatch<Plugin>(data.Id, data));
        }

        public override void Configure(JsonSerializerSettings settings)
        {
            var types = GetType().Assembly.GetTypes().Where(x => x.BaseType == typeof(Plugin));
            var factory = new DefaultPluginFactory();
            foreach (var type in types)
            {
                factory.Register(Plugin.GetNameFromType(type), type);
            }
            var converter = new PluginConverter(factory);
            settings.Converters.Add(converter);
        }
    }
}
