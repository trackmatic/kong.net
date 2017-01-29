namespace Kong.Model
{
    public class HmacAuthCredential
    {
        public string Id { get; set; }
        public string ConsumerId { get; set; }
        public long CreatedAt { get; set; }
        public string Username { get; set; }
        public string Secret { get; set; }
    }
}
