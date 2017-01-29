using System.Collections.Generic;
using System.Threading.Tasks;
using Kong.Slumber;

namespace Kong.Model
{
    public class Oauth2Applications
    {
        private readonly IRequestFactory _requestFactory;

        public Oauth2Applications(IRequestFactory requestFactory)
        {
            _requestFactory = requestFactory;
        }

        public Task<ResourceCollection<Oauth2Application>> List()
        {
            return _requestFactory.List<ResourceCollection<Oauth2Application>>(new Dictionary<string, object>());
        }

        public Task<Oauth2Application> Create(string name, string clientId, string clientSecret, string redirectUri)
        {
            return _requestFactory.Post<Oauth2Application>(new
            {
                name,
                client_id = clientId,
                client_secret = clientSecret,
                redirect_uri = redirectUri
            });
        }

        public Task Delete(string id)
        {
            return _requestFactory.Create("/{credential_id}", new Dictionary<string, string> { { "credential_id", id } }).Delete();
        }
    }
}
