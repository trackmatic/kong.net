using Kong.Serialization;
using Slumber;
using Slumber.Http;
using Slumber.Logging;

namespace Kong
{
    public class KongClient : IKongClient
    {
        public KongClient(string baseUri)
        {
            var slumber = new SlumberClient(baseUri, confgure =>
            {
                confgure.UseKongSerialization().UseHttp(http => http.ApplicationJson()).UseConsoleLogger();
            });
            Apis = new Apis(slumber);
            Consumers = new Consumers(slumber);
        }

        public Apis Apis { get; }

        public Consumers Consumers { get; }
    }
}
