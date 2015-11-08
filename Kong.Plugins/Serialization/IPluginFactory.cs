using Kong.Plugins.Model;
using Newtonsoft.Json.Linq;

namespace Kong.Plugins.Serialization
{
    public interface IPluginFactory
    {
        Plugin Create(JObject bag);
    }
}
