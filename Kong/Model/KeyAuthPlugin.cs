using System.Collections.Generic;
using Kong.Serialization;

namespace Kong.Model
{
    [Plugin("key-auth")]
    public class KeyAuthPlugin : PluginConfiguration
    {
        public string[] KeyNames { get; set; }

        public bool HideCredentials { get; set; }

        public KeyAuthCredentials Credentials(string consumerId)
        {
            var requestFactory = RequestFactory.Root.Create("/consumers/{consumer_id}/key-auth", new Dictionary<string, string>
            {
                {"consumer_id", consumerId}
            });
            return new KeyAuthCredentials(requestFactory);
        }
    }
}
