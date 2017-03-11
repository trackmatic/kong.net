using System;
using System.Threading.Tasks;
using Kong.Slumber;

namespace Kong.Model
{
    public class Api : IApi
    {
        private IRequestFactory _requestFactory;

        public string Id { get; set; }

        public string Name { get; set; }

        public string UpstreamUrl { get; set; }

        public bool PreserveHost { get; set; }

        public long CreatedAt { get; set; }

        public bool? StripUri { get; set; }

        public int? Retries { get; set; }

        public int? UpstreamConnectTimeout { get; set; }

        public int? UpstreamReadTimeout { get; set; }

        public int? UpstreamSendTimeout { get; set; }

        public string[] Hosts { get; set; }

        public bool? HttpsOnly { get; set; }

        public bool? HttpIfTerminated { get; set; }

        public string[] Uris { get; set; }

        public string[] Methods { get; set; }

        public Task Delete()
        {
            return _requestFactory.Delete();
        }

        public async Task<IApi> Save()
        {
            var data = new ApiUpdate
            {
                Id = Id,
                Name = Name,
                PreserveHost = PreserveHost,
                Hosts = Hosts,
                HttpIfTerminated = HttpIfTerminated,
                HttpsOnly = HttpsOnly,
                Methods = Methods,
                Retries = Retries,
                StripUri = StripUri,
                UpstreamConnectTimeout = UpstreamConnectTimeout,
                UpstreamSendTimeout = UpstreamSendTimeout,
                Uris = Uris,
                UpstreamUrl = UpstreamUrl,
                CreatedAt  = CreatedAt
            };
            var response = await _requestFactory.Parent.Put<Api>(data);
            response.Configure(_requestFactory);
            return response;
        }

        public IPlugins Plugins => new Plugins(_requestFactory.Create("/plugins"));

        internal void Configure(IRequestFactory requestFactory)
        {
            _requestFactory = requestFactory;
        }

        private class ApiUpdate : ApiData
        {
            public string Id { get; set; }
            public long CreatedAt { get; set; }
        }
    }
}
