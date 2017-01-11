namespace Kong.Model
{
    public class Api
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string RequestHost { get; set; }

        public string UpstreamUrl { get; set; }

        public bool PreserveHost { get; set; }

        public long CreatedAt { get; set; }

        public bool? StripRequestPath { get; set; }

        public string RequestPath { get; set; }

        public bool? Enabled { get; set; }
    }
}
