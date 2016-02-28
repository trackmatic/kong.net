using System.Collections.Generic;
using System.Threading.Tasks;
using Kong.Model;

namespace Kong
{
    public class ConsumerRequestFactory : RequestFactory<Consumer>
    {
        public ConsumerRequestFactory(IKongClient client) : base(client, "consumers")
        {

        }

        public Task<IKongCollection<Consumer>> List(string username = null, string customId = null)
        {
            return List(new Dictionary<string, object>
            {
                {"username", username},
                {"custom_id", customId}
            });
        }

        public override async Task<IKongCollection<Consumer>> List(IDictionary<string, object> parameters)
        {
            var response = await ExecuteAsync(CreateGet<KongCollection<Consumer>>(parameters));
            return response;
        }

        public override Task<Consumer> Get(string id)
        {
            return ExecuteAsync(CreateGet<Consumer>(id, new Dictionary<string, object>()));
        }

        public override Task Delete(string id)
        {
            return ExecuteAsync(CreateDelete(id));
        }

        public override Task<Consumer> Post(Consumer data)
        {
            return ExecuteAsync(CreatePost<Consumer>(data));
        }

        public override Task<Consumer> Put(Consumer data)
        {
            return ExecuteAsync(CreatePut<Consumer>(data));
        }

        public override Task<Consumer> Patch(Consumer data)
        {
            return ExecuteAsync(CreatePatch<Consumer>(data.Id, data));
        }
    }
}
