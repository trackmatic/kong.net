using System.Collections.Generic;
using System.Threading.Tasks;
using Kong.Slumber;

namespace Kong.Model
{
    public class JwtAuthCredentials
    {
        private readonly IRequestFactory _requestFactory;

        public JwtAuthCredentials(IRequestFactory requestFactory)
        {
            _requestFactory = requestFactory;
        }

        public Task<ResourceCollection<JwtAuthCredential>> List()
        {
            return _requestFactory.List<ResourceCollection<JwtAuthCredential>>(new Dictionary<string, object>());
        }

        public Task<JwtAuthCredential> Create(string key, string secret, string algorithm = "HS256", string rsaPublicKey = null)
        {
            return _requestFactory.Post<JwtAuthCredential>(new
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
