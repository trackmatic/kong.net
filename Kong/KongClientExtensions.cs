using System.Threading.Tasks;
using Kong.Model;
using Slumber;
using Slumber.Http;

namespace Kong
{
    public static class KongClientExtensions
    {
        public static ApiRequestFactory Apis(this IKongClient client)
        {
            return new ApiRequestFactory(client);
        }

        public static ConsumerRequestFactory Consumers(this IKongClient client)
        {
            return new ConsumerRequestFactory(client);
        }

        public static async Task<Status> Status(this IKongClient client)
        {
            var result = await client.ExecuteAsync(new HttpRequest<Status>("/status", HttpMethods.Get));
            return result.Data;
        }

        public static async Task<About> About(this IKongClient client)
        {
            var result = await client.ExecuteAsync(new HttpRequest<About>("/", HttpMethods.Get));
            return result.Data;
        }
    }
}
