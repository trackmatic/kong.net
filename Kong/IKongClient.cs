using System.Threading.Tasks;
using Slumber;

namespace Kong
{
    public interface IKongClient
    {
        Task<IResponse<T>> ExecuteAsync<T>(IRequest<T> request);
    }
}
