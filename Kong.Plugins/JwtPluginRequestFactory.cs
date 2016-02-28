using System.Threading.Tasks;
using Kong.Model;
using Kong.Plugins.Model;
using Slumber;
using Slumber.Http;

namespace Kong.Plugins
{
    public class JwtPluginRequestFactory : RequestExecutor
    {
        private readonly Consumer _consumer;

        public JwtPluginRequestFactory(IKongClient client, Consumer consumer) : base(client)
        {
            _consumer = consumer;
        }

        public async Task<IKongCollection<JwtCredentials>> List()
        {
            var request = new HttpRestRequest<KongCollection<JwtCredentials>>("/consumers/{consumerId}/jwt", HttpMethods.Get);
            request.AddQueryParameter("consumerId", _consumer.Id);
            var response = await ExecuteAsync(request);
            return response;
        }

        public Task Patch(JwtCredentials credentials)
        {
            var request = new HttpRestRequest<KongCollection<JwtCredentials>>("/consumers/{consumerId}/jwt/{credentialId}", HttpMethods.Patch)
            {
                Data = credentials
            };
            request.AddQueryParameter("consumerId", _consumer.Id);
            request.AddQueryParameter("credentialId", credentials.Id);
            return ExecuteAsync(request);
        }

        public Task Delete(JwtCredentials credentials)
        {
            var request = new HttpRestRequest<dynamic>("/consumers/{consumerId}/jwt/{credentialId}", HttpMethods.Delete);
            request.AddQueryParameter("consumerId", _consumer.Id);
            request.AddQueryParameter("credentialId", credentials.Id);
            return ExecuteAsync(request);
        }

        public Task<JwtCredentials> Post()
        {
            return CreateCredentials(null);
        }

        public Task<JwtCredentials> Post(string key, string secret, string userId)
        {
            var data = new
            {
                key,
                secret
            };
            return CreateCredentials(data);
        }

        private Task<JwtCredentials> CreateCredentials(object data)
        {
            var request = new HttpRestRequest<JwtCredentials>("/consumers/{consumerId}/jwt", HttpMethods.Post)
            {
                Data = data
            };
            request.AddQueryParameter("consumerId", _consumer.Id);
            return ExecuteAsync(request);
        }
    }
}
