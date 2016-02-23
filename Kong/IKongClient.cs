using Slumber;

namespace Kong
{
    public interface IKongClient
    {
        IRestResponse<T> Execute<T>(IRestRequest<T> request);
    }
}
