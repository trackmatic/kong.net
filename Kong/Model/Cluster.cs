using System.Collections.Generic;
using System.Threading.Tasks;
using Kong.Slumber;

namespace Kong.Model
{
    public class Cluster : ResourceCollection<ClusterNode>, ICluster
    {
        private IRequestFactory _requestFactory;

        public Task Delete(ClusterNode node)
        {
            var requestFactory = _requestFactory.Create(new Dictionary<string, string> {{"name", node.Name}});
            return requestFactory.Delete();
        }

        internal void Configure(IRequestFactory requestFactory)
        {
            _requestFactory = requestFactory;
        }
    }
}
