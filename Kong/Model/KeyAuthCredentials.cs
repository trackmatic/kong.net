using System.Collections.Generic;
using System.Threading.Tasks;
using Kong.Slumber;

namespace Kong.Model
{
    public class KeyAuthCredentials
    {
        private readonly IRequestFactory _requestFactory;

        public KeyAuthCredentials(IRequestFactory requestFactory)
        {
            _requestFactory = requestFactory;
        }

        public Task<ResourceCollection<KeyAuthCredential>> List()
        {
            return _requestFactory.List<ResourceCollection<KeyAuthCredential>>(new Dictionary<string, object>());
        }

        public Task<KeyAuthCredential> Create(string key)
        {
            return _requestFactory.Post<KeyAuthCredential>(new
            {
                key
            });
        }

        public Task Delete(string id)
        {
            return _requestFactory.Create("/{credential_id}", new Dictionary<string, string> { { "credential_id", id } }).Delete();
        }
    }
}
