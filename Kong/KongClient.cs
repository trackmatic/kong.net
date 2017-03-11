using System.Threading.Tasks;
using Kong.Model;
using Kong.Slumber;

namespace Kong
{
    public class KongClient : IKongClient
    {
        private readonly IRequestFactory _requestFactory;

        internal KongClient(IRequestFactory requestfactory)
        {
            _requestFactory = requestfactory;
        }

        public async Task<Node> Node()
        {
            var requestFactory = _requestFactory.Create("/");
            var response = await requestFactory.Get<Node>().ConfigureAwait(false);
            return response;
        }

        public async Task<Status> Status()
        {
            var requestFactory = _requestFactory.Create("/status");
            var response = await requestFactory.Get<Status>().ConfigureAwait(false);
            return response;
        }

        public async Task<ICluster> Cluster()
        {
            var requestFactory = _requestFactory.Create("/cluster");
            var response = await requestFactory.Get<Cluster>().ConfigureAwait(false);
            response.Configure(requestFactory);
            return response;
        }

        public IApis Apis => new Apis(_requestFactory.Create("/apis"));

        public IConsumers Consumers => new Consumers(_requestFactory.Create("/consumers"));

        public IRequestFactory RequestFactory => _requestFactory;
    }
}
