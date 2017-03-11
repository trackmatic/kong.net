using System.Threading.Tasks;

namespace Kong
{
    public interface IApi
    {

        string Id { get; set; }

        string Name { get; set; }

        string UpstreamUrl { get; set; }

        bool PreserveHost { get; set; }

        long CreatedAt { get; set; }

        bool? StripUri { get; set; }

        int? Retries { get; set; }

        int? UpstreamConnectTimeout { get; set; }

        int? UpstreamReadTimeout { get; set; }

        int? UpstreamSendTimeout { get; set; }

        string[] Hosts { get; set; }

        bool? HttpsOnly { get; set; }

        bool? HttpIfTerminated { get; set; }

        string[] Uris { get; set; }

        string[] Methods { get; set; }

        Task Delete();
        Task<IApi> Save();
        IPlugins Plugins { get; }
    }
}
