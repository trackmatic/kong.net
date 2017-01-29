using System.Threading.Tasks;
using Kong.Model;

namespace Kong
{
    /// <summary>
    /// The Consumer object represents a consumer - or a user - of an API. You can either rely on Kong as the primary datastore, or you can map the consumer list with your database to keep consistency between Kong and your existing primary datastore.
    /// </summary>
    public interface IConsumers
    {
        Task<ResourceCollection<IConsumer>> List(string id = null, 
            string customId = null, 
            string username = null, 
            int size = 100, 
            int? offset = null);

        /// <summary>
        /// Create a new consumer
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<IConsumer> Create(ConsumerData data);
        
        Task<IConsumer> Get(string id);
    }
}
