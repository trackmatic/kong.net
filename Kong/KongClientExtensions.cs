namespace Kong
{
    public static class KongClientExtensions
    {
        public static ApiResource Apis(this IKongClient client)
        {
            return client.Get<ApiResource>() ?? new ApiResource(client);
        }

        public static ConsumerResource Consumers(this IKongClient client)
        {
            return client.Get<ConsumerResource>() ?? new ConsumerResource(client);
        }
    }
}
