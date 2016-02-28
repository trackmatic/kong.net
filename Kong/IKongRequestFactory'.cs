using System.Collections.Generic;
using System.Threading.Tasks;
using Kong.Model;

namespace Kong
{
    public interface IKongRequestFactory<T> : IKongRequestFactory
    {
        Task<IKongCollection<T>> List(IDictionary<string, object> parameters);

        Task<T> Get(string id);

        Task Delete(string id);

        Task<T> Post(T data);

        Task<T> Patch(T data);
    }
}
