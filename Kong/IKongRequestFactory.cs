using System.Collections.Generic;
using Kong.Model;

namespace Kong
{
    public interface IKongRequestFactory<T>
    {
        IKongCollection<T> List(IDictionary<string, object> parameters);

        T Get(string id);

        void Delete(string id);

        T Post(T data);

        T Patch(T data);
    }
}
