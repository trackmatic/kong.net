using Kong.Slumber;

namespace Kong.Model
{
    public interface IPluginConfiguration
    {
        void Configure(IRequestFactory requestFactory);
    }
}