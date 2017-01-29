using System.Threading.Tasks;
using Kong.About;
using Kong.Model;

namespace Kong
{
    /// <summary>
    /// Entry point to the kong server.
    /// </summary>
    public interface IKongClient
    {
        /// <summary>
        /// Retrieve generic details about a node.
        /// </summary>
        /// <returns></returns>
        Task<Node> Node();

        /// <summary>
        /// Retrieve usage information about a node, with some basic information about the connections being processed by the underlying nginx process, and the number of entities stored in the datastore collections (including plugin's collections).
        /// If you want to monitor the Kong process, since Kong is built on top of nginx, every existing nginx monitoring tool or agent can be used.
        /// </summary>
        /// <returns></returns>
        Task<Status> Status();

        /// <summary>
        /// You can see the Kong cluster members, and forcibly remove a node from the cluster, using the following endpoints. For more information read the clustering documentation. You can also execute these operations using the CLI.
        /// </summary>
        /// <returns></returns>
        Task<ICluster> Cluster();

        /// <summary>
        /// The API object describes an API that's being exposed by Kong. Kong needs to know how to retrieve the API when a consumer is calling it from the Proxy port. Each API object must specify a request host, a request path or both. Kong will proxy all requests to the API to the specified upstream URL.
        /// </summary>
        IApis Apis { get; }

        /// <summary>
        /// The Consumer object represents a consumer - or a user - of an API. You can either rely on Kong as the primary datastore, or you can map the consumer list with your database to keep consistency between Kong and your existing primary datastore.
        /// </summary>
        IConsumers Consumers { get; }
    }
}
