using System.Threading.Tasks;
using Kong.Slumber;

namespace Kong.Model
{
    public class Consumer : IConsumer
    {
        private IRequestFactory _requestFactory;
        
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string Username { get; set; }
        public long CreatedAt { get; set; }

        public Task Delete()
        {
            return _requestFactory.Delete();
        }

        public async Task<IConsumer> Save()
        {
            var data = new ConsumerUpdate
            {
                Id = Id,
                CreatedAt = CreatedAt,
                CustomId = CustomId,
                Username = Username
            };
            var response = await _requestFactory.Parent.Put<Consumer>(data);
            response.Configure(_requestFactory);
            return response;
        }

        internal void Configure(IRequestFactory requestFactory)
        {
            _requestFactory = requestFactory;
        }

        private class ConsumerUpdate : ConsumerData
        {
            public string Id { get; set; }
            public long CreatedAt { get; set; }
        }
    }
}
