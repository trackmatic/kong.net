using System.Collections.Generic;
using System.Threading.Tasks;
using Kong.Slumber;

namespace Kong.Model
{
    public class HmacAuthCredentials
    {
        private readonly IRequestFactory _requestFactory;

        public HmacAuthCredentials(IRequestFactory requestFactory)
        {
            _requestFactory = requestFactory;
        }

        public Task<ResourceCollection<HmacAuthCredential>> List()
        {
            return _requestFactory.List<ResourceCollection<HmacAuthCredential>>(new Dictionary<string, object>());
        }

        public Task<HmacAuthCredential> Create(string username, string secret)
        {
            return _requestFactory.Post<HmacAuthCredential>(new
            {
                username,
                secret
            });
        }

        public Task Delete(string id)
        {
            return _requestFactory.Create("/{credential_id}", new Dictionary<string, string> { { "credential_id", id } }).Delete();
        }
    }
}
