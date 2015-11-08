using System.Collections.Generic;
using Kong.Model;
using Slumber;

namespace Kong
{
    public class Plugins : ResourceBase<Plugin>
    {
        public Plugins(ISlumberClient client, Api api) : base(client, $"apis/{api.Id}/plugins")
        {
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
    }
}
