using System.Collections.Generic;
using System.Threading.Tasks;
using Kong.Slumber;

namespace Kong.Model
{
    public class Consumers : IConsumers
    {
        private readonly IRequestFactory _requestFactory;

        public Consumers(IRequestFactory requestFactory)
        {
            _requestFactory = requestFactory;
        }

        public  async Task<ResourceCollection<IConsumer>> List(string id = null,
            string customId = null,
            string username = null,
            int size = 100,
            int? offset = null)
        {
            var parameters = new Dictionary<string, object>
            {
                {"id", id },
                {"custom_id", customId },
                {"username", username },
                {"size", size },
                {"offset", offset }
            };
            var response = await _requestFactory.List<ResourceCollection<Consumer>>(parameters).ConfigureAwait(false);
            return MapToInterface(response);
        }

        public async Task<IConsumer> Create(ConsumerData data)
        {
            var response = await _requestFactory.Post<Consumer>(data).ConfigureAwait(false);
            var requestFactory = _requestFactory.Create("/{id}", new Dictionary<string, string> { { "id", response.Id } });
            response.Configure(requestFactory);
            return response;
        }

        public async Task<IConsumer> Get(string id)
        {
            var requestFactory = _requestFactory.Create("/{id}", new Dictionary<string, string> { { "id", id } });
            var response = await requestFactory.Get<Consumer>().ConfigureAwait(false);
            response.Configure(requestFactory);
            return response;
        }

        private ResourceCollection<IConsumer> MapToInterface(ResourceCollection<Consumer> response)
        {
            var result = new ResourceCollection<IConsumer> { Total = response.Total };
            foreach (var api in response.Data)
            {
                result.Data.Add(Configure(api));
            }
            return result;
        }

        private Consumer Configure(Consumer consumer)
        {
            var requestFactory = _requestFactory.Create("/{id}", new Dictionary<string, string> { { "id", consumer.Id } });
            consumer.Configure(requestFactory);
            return consumer;
        }
    }
}
