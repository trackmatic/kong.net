using Kong.Model;

namespace Kong.Plugins
{
    public static class KongClientExtensions
    {
        public static PluginResource Plugins(this IKongClient client, Api api)
        {
            return new PluginResource(client, api);
        }
    }
}
