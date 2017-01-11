using System.Threading.Tasks;
using Kong.Model;

namespace Kong.Plugins
{
    public interface IPluginRequestFactory : IKongRequestFactory<Plugin>
    {
        Task<IKongCollection<Plugin>> List(string name = null, string consumerId = null, int size = 100, int offset = 0);

        Task<T> Get<T>(string id) where T : Plugin;
    }
}
