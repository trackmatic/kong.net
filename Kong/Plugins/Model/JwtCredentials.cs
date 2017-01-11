namespace Kong.Plugins.Model
{
    public class JwtCredentials
    {
        public string Id { get; set; }

        public string ConsumerId { get; set; }

        public long CreatedAt { get; set; }

        public string Key { get; set; }

        public string Secret { get; set; }
    }
}
