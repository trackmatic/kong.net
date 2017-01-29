using System.Collections.Generic;
using Kong.Serialization;

namespace Kong.Model
{
    [Plugin("basic-auth")]
    public class BasicAuthPlugin : PluginConfiguration
    {
        public bool HideCredentials { get; set; }

        public BasicAuthCredentials Credentials(string consumerId)
        {
            var requestFactory = RequestFactory.Root.Create("/consumers/{consumer_id}/basic-auth", new Dictionary<string, string>
            {
                {"consumer_id", consumerId}
            });
            return new BasicAuthCredentials(requestFactory);
        }
    }
}
