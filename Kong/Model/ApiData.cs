namespace Kong.Model
{
    public class ApiData
    {
        public string Name { get; set; }
        public bool PreserveHost { get; set; }
        public string UpstreamUrl { get; set; }
        public string[] Methods { get; set; }
        public string[] Hosts { get; set; }
        public string[] Uris { get; set; }
        public int? Retries { get; set; }
        public int? UpstreamConnectTimeout { get; set; }
        public int? UpstreamSendTimeout { get; set; }
        public bool? StripUri { get; set; }
        public bool? HttpsOnly { get; set; }
        public bool? HttpIfTerminated { get; set; }
    }
}
