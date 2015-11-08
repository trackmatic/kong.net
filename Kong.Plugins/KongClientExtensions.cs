using Kong.Model;

namespace Kong.Plugins
{
    public static class KongClientExtensions
    {
        public static PluginRequestFactory Plugins(this IKongClient client, Api api)
        {
            return client.Get<PluginRequestFactory>() ?? new PluginRequestFactory(client, api);
        }
    }
}
