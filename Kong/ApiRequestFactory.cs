using System.Collections.Generic;
using System.Threading.Tasks;
using Kong.Model;

namespace Kong
{
    public class ApiRequestFactory : RequestFactory<Api>
    {
        public ApiRequestFactory(IKongClient client) : base(client, "apis")
        {

        }

        public Task<IKongCollection<Api>> List(string name = null, string requestHost = null, string requestPath = null, string upstreamUrl = null, int size = 100, int offset = 0)
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
        
        public override async Task<IKongCollection<Api>> List(IDictionary<string, object> parameters)
        {
            var response = await ExecuteAsync(CreateGet<KongCollection<Api>>(parameters));
            return response;
        }

        public override Task<Api> Get(string id)
        {
            return ExecuteAsync(CreateGet<Api>(id, new Dictionary<string, object>()));
        }

        public override Task Delete(string id)
        {
            return ExecuteAsync(CreateDelete(id));
        }

        public override Task<Api> Patch(Api data)
        {
            return ExecuteAsync(CreatePatch<Api>(data.Id, data));
        }

        public override Task<Api> Post(Api data)
        {
            return ExecuteAsync(CreatePost<Api>(data));
        }

        public override Task<Api> Put(Api data)
        {
            return ExecuteAsync(CreatePut<Api>(data));
        }
    }
}
