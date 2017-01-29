using System.Collections.Generic;
using System.Threading.Tasks;
using Kong.Model;

namespace Kong
{
    public interface ICluster
    {
        /// <summary>
        /// Forcibly remove a node from the cluster.
        /// </summary>
        /// <returns></returns>
        Task Delete(ClusterNode node);

        int Total { get; }
        List<ClusterNode> Data { get; }
    }
}
