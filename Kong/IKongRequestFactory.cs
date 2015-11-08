using Newtonsoft.Json;

namespace Kong
{
    public interface IKongRequestFactory
    {
        void Configure(JsonSerializerSettings settings);
    }
}
