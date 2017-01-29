using System.Threading.Tasks;
using Kong.Model;

namespace Kong
{
    public interface IPlugins
    {
        Task<ResourceCollection<IPlugin>> List(string id = null,
            string name = null,
            string apiId = null,
            string consumerId = null,
            int size = 100,
            int? offset = 0);
        Task<IPlugin> Create(PluginData data);
        Task<IPlugin> Get(string id);
        Task<dynamic> Schema(string id);
    }
}
