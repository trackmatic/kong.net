using Slumber;

namespace Kong
{
    public interface IKongClient
    {
        void Register(IKongRequestFactory factory);

        T Get<T>() where T : IKongRequestFactory;

        IRestResponse<T> Execute<T>(IRestRequest<T> request);
    }
}
