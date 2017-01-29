using System.Collections.Generic;
using Kong.Serialization;

namespace Kong.Model
{
    [Plugin("hmac-auth")]
    public class HmacAuthPlugin : PluginConfiguration
    {
        public bool HideCredentials { get; set; }
        public int ClockSkew { get; set; }

        public HmacAuthCredentials Credentials(string consumerId)
        {
            var requestFactory = RequestFactory.Root.Create("/consumers/{consumer_id}/hmac-auth", new Dictionary<string, string>
            {
                {"consumer_id", consumerId}
            });
            return new HmacAuthCredentials(requestFactory);
        }
    }
}
