namespace Kong.Model
{
    public class Oauth2Application
    {
        public string Id { get; set; }
        public string ConsumerId { get; set; }
        public long CreatedAt { get; set; }
        public string Name { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string[] RedirectUri { get; set; }
    }
}
