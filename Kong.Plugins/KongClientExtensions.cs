using Kong.Model;

namespace Kong.Plugins
{
    public static class KongClientExtensions
    {
        public static PluginRequestFactory Plugins(this IKongClient client)
        {
            return (client.Get<PluginRequestFactory>() ?? new PluginRequestFactory(client));
        }

        public static IPluginRequestFactory Plugins(this IKongClient client, Api api)
        {
            return client.Plugins().For(api);
        }
    }
}
