using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

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

        [JsonProperty("total")]
        public int Total { get; set; }
        
        [JsonProperty("data")]
        public List<T> Data { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }
    }
}
