using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kong.Slumber
{
    public interface IRequestFactory
    {
        Task<T> List<T>(IDictionary<string, object> parameters);
        Task<T> Post<T>(object data, IDictionary<string, string> headers = null);
        Task<T> Post<T>(IDictionary<string, string> headers = null);
        Task<T> Get<T>(string id);
        Task<T> Get<T>();
        Task<T> Put<T>(object data);
        Task<T> Patch<T>(object data);
        Task Delete();
        IRequestFactory Create(string url);
        IRequestFactory Create(IDictionary<string, string> parameters);
        IRequestFactory Create(string url, IDictionary<string, string> parameters);
        IRequestFactory Parent { get; }
        IRequestFactory Root { get; }
        IRequestFactory Substitute(string segment, string url);
    }
}