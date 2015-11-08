using System.Collections.Generic;
using Kong.Model;

namespace Kong
{
    public class ConsumerRequestFactory : RequestFactory<Consumer>
    {
        public ConsumerRequestFactory(IKongClient client) : base(client, "consumers")
        {
            client.Register(this);
        }

        public IKongCollection<Consumer> List(string username = null)
        {
            return List(new Dictionary<string, object>
            {
                {"username", username}
            });
        }

        public override IKongCollection<Consumer> List(IDictionary<string, object> parameters)
        {
            return Execute(CreateGet<KongCollection<Consumer>>(parameters));
        }

        public override Consumer Get(string id)
        {
            return Execute(CreateGet<Consumer>(id, new Dictionary<string, object>()));
        }

        public override void Delete(string id)
        {
            Execute(CreateDelete(id));
        }

        public override Consumer Post(Consumer data)
        {
            return Execute(CreatePost<Consumer>(data));
        }

        public override Consumer Patch(Consumer data)
        {
            return Execute(CreatePatch<Consumer>(data.Id, data));
        }

        public override string Id => GetType().Name;
    }
}
