using System.Threading.Tasks;

namespace Kong.Plugins
{
    public interface IPluginSchemaRequestFactory
    {
        Task<dynamic> Get(string name);
    }
}
