using System.Collections.Generic;

namespace Kong.Model
{
    public class AboutPlugins
    {
        public List<string> EnabledInCluster { get; set; }

        public List<string> AvailableOnServer { get; set; }
    }
}
