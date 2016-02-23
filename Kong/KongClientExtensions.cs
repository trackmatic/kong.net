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

        public static Status Status(this IKongClient client)
        {
            return client.Execute(new HttpRestRequest<Status>("/status", HttpMethods.Get)).Data;
        }

        public static About About(this IKongClient client)
        {
            return client.Execute(new HttpRestRequest<About>("/", HttpMethods.Get)).Data;
        }
    }
}
