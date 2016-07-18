using System.Threading.Tasks;
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

        protected async Task<TResponse> ExecuteAsync<TResponse>(IRequest<TResponse> request)
        {
            var response = await _client.ExecuteAsync(request);
            if (response.HasError)
            {
                throw response.Exception;
            }
            return response.Data;
        }
    }
}
