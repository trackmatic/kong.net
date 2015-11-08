using Kong.Model;
using Kong.Plugins.Model;

namespace Kong.Plugins
{
    public interface IPluginRequestFactory : IKongRequestFactory<Plugin>
    {
        IKongCollection<Plugin> List(string name = null, string consumerId = null, int size = 100, int offset = 0);

        T Get<T>(string id) where T : Plugin;
    }
}
