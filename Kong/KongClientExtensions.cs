namespace Kong
{
    public static class KongClientExtensions
    {
        public static ApiRequestFactory Apis(this IKongClient client)
        {
            return client.Get<ApiRequestFactory>() ?? new ApiRequestFactory(client);
        }

        public static ConsumerRequestFactory Consumers(this IKongClient client)
        {
            return client.Get<ConsumerRequestFactory>() ?? new ConsumerRequestFactory(client);
        }
    }
}
