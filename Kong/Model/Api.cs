using System.Threading.Tasks;
using Kong.Slumber;

namespace Kong.Model
{
    public class Api : IApi
    {
        private IRequestFactory _requestFactory;

        public string Id { get; set; }
        public string Name { get; set; }
        public string RequestHost { get; set; }
        public string UpstreamUrl { get; set; }
        public bool PreserveHost { get; set; }
        public long CreatedAt { get; set; }
        public bool? StripRequestPath { get; set; }
        public string RequestPath { get; set; }

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
                RequestHost = RequestHost,
                RequestPath = RequestPath,
                StripRequestPath = StripRequestPath,
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
