using System.Collections.Generic;

namespace Kong.Model
{
    public interface IKongCollection<T>
    {
        int Total { get; }

        List<T> Data { get; }

        string Next { get; }
    }
}
