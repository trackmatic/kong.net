using Kong.Model;

namespace Kong.Plugins
{
    public static class KongClientExtensions
    {
        public static PluginRequestFactory Plugins(this IKongClient client)
        {
            return new PluginRequestFactory(client);
        }

        public static IPluginRequestFactory Plugins(this IKongClient client, Api api)
        {
            return client.Plugins().For(api);
        }

        public static IPluginSchemaRequestFactory Schema(this IKongClient client)
        {
            return new PluginSchemaRequestFactory(client);
        }

        public static BasicAuthRequestFactory BasicAuth(this IKongClient client, Consumer consumer)
        {
            return new BasicAuthRequestFactory(client, consumer);
        }

        public static JwtPluginRequestFactory JwtAuth(this IKongClient client, Consumer consumer)
        {
            return new JwtPluginRequestFactory(client, consumer);
        }
    }
}
