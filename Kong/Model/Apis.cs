using System.Collections.Generic;
using System.Threading.Tasks;
using Kong.Slumber;

namespace Kong.Model
{
    public class Apis : IApis
    {
        private readonly IRequestFactory _requestFactory;

        public Apis(IRequestFactory requestFactory)
        {
            _requestFactory = requestFactory;
        }

        public async Task<ResourceCollection<IApi>> List(string id = null, 
            string name = null, 
            string requestHost = null, 
            string requestPath = null, 
            string upstreamUrl = null, 
            int size = 100, 
            int? offset = null)
        {
            var parameters = new Dictionary<string, object>
            {
                {"id", id},
                {"name", name},
                {"request_host", requestHost},
                {"request_path", requestPath},
                {"upstream_url", upstreamUrl},
                {"size", size},
                {"offset", offset}
            };
            var response = await _requestFactory.List<ResourceCollection<Api>>(parameters).ConfigureAwait(false);
            return MapToInterface(response);
        }

        public async Task<IApi> Create(ApiData data)
        {
            var response = await _requestFactory.Post<Api>(data).ConfigureAwait(false);
            var requestFactory = _requestFactory.Create("/{id}", new Dictionary<string, string> {{"id", response.Id}});
            response.Configure(requestFactory);
            return response;
        }

        public async Task<IApi> Get(string id)
        {
            var requestFactory = _requestFactory.Create("/{id}", new Dictionary<string, string> { { "id", id } });
            var response = await requestFactory.Get<Api>().ConfigureAwait(false);
            response.Configure(requestFactory);
            return response;
        }

        private ResourceCollection<IApi> MapToInterface(ResourceCollection<Api> response)
        {
            var result = new ResourceCollection<IApi> { Total = response.Total };
            foreach (var api in response.Data)
            {
                result.Data.Add(Configure(api));
            }
            return result;
        }

        private Api Configure(Api api)
        {
            var requestFactory = _requestFactory.Create("/{id}", new Dictionary<string, string> { { "id", api.Id } });
            api.Configure(requestFactory);
            return api;
        }
    }
}
