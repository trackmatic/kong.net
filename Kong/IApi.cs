using System.Threading.Tasks;

namespace Kong
{
    public interface IApi
    {
        string Id { get; }
        long CreatedAt { get; }
        string Name { get; set; }
        string RequestHost { get; set; }
        string UpstreamUrl { get; set; }
        bool PreserveHost { get; set; }
        bool? StripRequestPath { get; set; }
        string RequestPath { get; set; }

        Task Delete();
        Task<IApi> Save();
        IPlugins Plugins { get; }
    }
}
