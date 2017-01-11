using System.Collections.Generic;
using System.Linq;

namespace Kong.Model
{
    public class KongCollection<T> : IKongCollection<T>
    {
        public KongCollection(IEnumerable<T> data, int total, string next)
        {
            Data = data.ToList();
            Total = total;
            Next = next;
        }

        public KongCollection()
        {
            Data = new List<T>();
        }

        public int Total { get; set; }
        
        public List<T> Data { get; set; }

        public string Next { get; set; }
    }
}
