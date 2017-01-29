namespace Kong.Model
{
    public class JwtCredential
    {
        public string Id { get; set; }
        public string ConsumerId { get; set; }
        public long CreatedAt { get; set; }
        public string Key { get; set; }
        public string Secret { get; set; }
    }
}
