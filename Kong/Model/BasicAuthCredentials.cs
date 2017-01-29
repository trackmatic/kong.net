using System.Collections.Generic;
using System.Threading.Tasks;
using Kong.Slumber;

namespace Kong.Model
{
    public class BasicAuthCredentials
    {
        private readonly IRequestFactory _requestFactory;

        public BasicAuthCredentials(IRequestFactory requestFactory)
        {
            _requestFactory = requestFactory;
        }

        public Task<ResourceCollection<BasicAuthCredential>> List()
        {
            return _requestFactory.List<ResourceCollection<BasicAuthCredential>>(new Dictionary<string, object>());
        }

        public Task<BasicAuthCredential> Create(string username, string password)
        {
            return _requestFactory.Post<BasicAuthCredential>(new
            {
                username,
                password
            });
        }

        public Task Delete(string id)
        {
            return _requestFactory.Create("/{credential_id}", new Dictionary<string, string>{{"credential_id", id}}).Delete();
        }
    }
}
