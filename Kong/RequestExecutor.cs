using Slumber;

namespace Kong
{
    public class RequestExecutor
    {
        private readonly IKongClient _client;

        protected RequestExecutor(IKongClient client)
        {
            _client = client;
        }

        protected TResponse Execute<TResponse>(IRestRequest<TResponse> request)
        {
            return _client.Execute(request).Data;
        }
    }
}
