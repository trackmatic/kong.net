using System.Threading.Tasks;
using Kong.Model;

namespace Kong
{
    public interface IApis
    {
        Task<ResourceCollection<IApi>> List(string id = null,
            string name = null,
            string requestHost = null,
            string requestPath = null,
            string upstreamUrl = null,
            int size = 100,
            int? offset = null);
        Task<IApi> Create(ApiData data);
        Task<IApi> Get(string id);
    }
}
