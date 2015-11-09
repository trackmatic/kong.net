using Kong.Model;
using Slumber;
using Slumber.Http;

namespace Kong.Plugins
{
    public class BasicAuthRequestFactory : RequestExecutor
    {
        private readonly Consumer _consumer;

        internal BasicAuthRequestFactory(IKongClient client, Consumer consumer) : base(client)
        {
            _consumer = consumer;
        }

        public void CreateCredential(string username, string password)
        {
            var request = new HttpRestRequest<dynamic>("/consumers/{consumerId}/basic-auth", HttpMethods.Post)
            {
                Data = new
                {
                    username,
                    password
                }
            };
            request.AddQueryParameter("consumerId", _consumer.Id);
            Execute(request);
        }
    }
}
