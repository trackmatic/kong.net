using System.Collections.Generic;
using System.Threading.Tasks;
using Kong.Slumber;

namespace Kong.Model
{
    public class KeyCredentials
    {
        private readonly IRequestFactory _requestFactory;

        public KeyCredentials(IRequestFactory requestFactory)
        {
            _requestFactory = requestFactory;
        }

        public Task<ResourceCollection<KeyCredential>> List()
        {
            return _requestFactory.List<ResourceCollection<KeyCredential>>(new Dictionary<string, object>());
        }

        public Task<KeyCredential> Create(string key)
        {
            return _requestFactory.Post<KeyCredential>(new
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
