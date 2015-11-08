using System.Collections.Generic;
using Kong.Model;

namespace Kong
{
    public class ApiRequestFactory : RequestFactory<Api>
    {
        public ApiRequestFactory(IKongClient client) : base(client, "apis")
        {
            client.Register(this);
        }

        public IKongCollection<Api> List(string name = null, string requestHost = null, string requestPath = null, string upstreamUrl = null, int size = 100, int offset = 0)
        {
            return List(new Dictionary<string, object>
            {
                { "name", name  },
                { "request_host", requestHost  },
                { "request_path", requestPath  },
                { "upstream_url", upstreamUrl  },
                { "size", size  },
                { "offset", offset }
            });
        }

        public override IKongCollection<Api> List(IDictionary<string, object> parameters)
        {
            return Execute(CreateGet<KongCollection<Api>>(parameters));
        }

        public override Api Get(string id)
        {
            return Execute(CreateGet<Api>(id, new Dictionary<string, object>()));
        }

        public override void Delete(string id)
        {
            Execute(CreateDelete(id));
        }

        public override Api Patch(Api data)
        {
            return Execute(CreatePatch<Api>(data.Id, data));
        }

        public override string Id => GetType().Name;

        public override Api Post(Api data)
        {
            return Execute(CreatePost<Api>(data));
        }
    }
}
