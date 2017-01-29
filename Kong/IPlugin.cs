using System.Threading.Tasks;
using Kong.Model;

namespace Kong
{
    public interface IPlugin
    {
        string Id { get; }
        string Name { get; }
        string ApiId { get; set; }
        bool Enabled { get; set; }
        T Configure<T>() where T : IPluginConfiguration;
        Task Delete();
        Task<IPlugin> Save();
    }
}