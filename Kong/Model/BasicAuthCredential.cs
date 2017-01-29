namespace Kong.Model
{
    public class BasicAuthCredential
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConsumerId { get; set; }
        public long CreatedAt { get; set; }
    }
}
