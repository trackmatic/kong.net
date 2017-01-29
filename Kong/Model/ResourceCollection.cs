using System.Collections.Generic;

namespace Kong.Model
{
    public class ResourceCollection<T>
    {
        public ResourceCollection()
        {
            Data = new List<T>();
        }

        public List<T> Data { get; set; }
        public int Total { get; set; }
    }
}
