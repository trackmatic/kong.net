using System.Threading.Tasks;
using Slumber;

namespace Kong
{
    public interface IKongClient
    {
        Task<IRestResponse<T>> ExecuteAsync<T>(IRestRequest<T> request);
    }
}
