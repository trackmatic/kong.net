using System.Collections.Generic;
using System.Threading.Tasks;
using Kong.Slumber;

namespace Kong.Model
{
    public class JwtCredentials
    {
        private readonly IRequestFactory _requestFactory;

        public JwtCredentials(IRequestFactory requestFactory)
        {
            _requestFactory = requestFactory;
        }

        public Task<ResourceCollection<JwtCredential>> List()
        {
            return _requestFactory.List<ResourceCollection<JwtCredential>>(new Dictionary<string, object>());
        }

        public Task<JwtCredential> Create(string key, string secret, string algorithm = "HS256", string rsaPublicKey = null)
        {
            return _requestFactory.Post<JwtCredential>(new
            {
                key,
                rsa_public_key = rsaPublicKey,
                secret,
                algorithm
            });
        }

        public Task Delete(string id)
        {
            return _requestFactory.Create("/{credential_id}", new Dictionary<string, string> { { "credential_id", id } }).Delete();
        }
    }
}
