using Kong.Model;
using Slumber;
using Slumber.Http;

namespace Kong.Plugins
{
    public class KeyAuthRequestFactory : RequestExecutor
    {
        private readonly Consumer _consumer;

        internal KeyAuthRequestFactory(IKongClient client, Consumer consumer) : base(client)
        {
            _consumer = consumer;
        }

        public void CreateCredentials(string key)
        {
            var request = new HttpRestRequest<dynamic>("/consumers/{consumerId}/key-auth", HttpMethods.Post)
            {
                Data = new
                {
                    key,
                    consumer_id = _consumer.Id
                }
            };
            request.AddQueryParameter("consumerId", _consumer.Id);
            Execute(request);
        }
    }
}
