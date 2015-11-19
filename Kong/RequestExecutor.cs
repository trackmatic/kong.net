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
            var response = _client.Execute(request);
            if (response.HasError)
            {
                throw response.Exception;
            }
            return response.Data;
        }
    }
}
