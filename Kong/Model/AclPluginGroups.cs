using System.Collections.Generic;
using System.Threading.Tasks;
using Kong.Slumber;

namespace Kong.Model
{
    public class AclPluginGroups
    {
        private readonly IRequestFactory _requestFactory;

        public AclPluginGroups(IRequestFactory requestFactory)
        {
            _requestFactory = requestFactory;
        }

        public Task<ResourceCollection<AclPluginGroup>> List()
        {
            return _requestFactory.List<ResourceCollection<AclPluginGroup>>(new Dictionary<string, object>());
        }

        public Task<AclPluginGroup> Create(string group)
        {
            return _requestFactory.Post<AclPluginGroup>(new
            {
                group
            });
        }

        public Task Delete(string id)
        {
            return _requestFactory.Create("/{credential_id}", new Dictionary<string, string> { { "credential_id", id } }).Delete();
        }
    }
}
