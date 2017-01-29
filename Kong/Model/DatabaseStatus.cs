namespace Kong.Model
{
    public class DatabaseStatus
    {
        public int Oauth2Credentials { get; set; }
        public int JwtSecrets { get; set; }
        public int ResponseRatelimitingMetrics { get; set; }
        public int KeyauthCredentials { get; set; }
        public int Oauth2AauthorizationCodes { get; set; }
        public int Acls { get; set; }
        public int Apis { get; set; }
        public int BasicauthCredentials { get; set; }
        public int Consumers { get; set; }
        public int RatelimitingMetrics { get; set; }
        public int Oauth2Tokens { get; set; }
        public int Nodes { get; set; }
        public int HmacauthCredentials { get; set; }
        public int Plugins { get; set; }

    }
}
