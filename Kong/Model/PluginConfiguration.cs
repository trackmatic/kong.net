using Kong.Slumber;

namespace Kong.Model
{
    public abstract class PluginConfiguration : IPluginConfiguration
    {
        private IRequestFactory _requestFactory;

        protected IRequestFactory RequestFactory => _requestFactory;
        
        public void Configure(IRequestFactory requestFactory)
        {
            _requestFactory = requestFactory;
        }
    }
}
