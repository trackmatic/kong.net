namespace Kong.Model
{
    public class ApiData
    {
        public string Name { get; set; }
        public string RequestHost { get; set; }
        public string RequestPath { get; set; }
        public bool? StripRequestPath { get; set; }
        public bool PreserveHost { get; set; }
        public string UpstreamUrl { get; set; }
    }
}
