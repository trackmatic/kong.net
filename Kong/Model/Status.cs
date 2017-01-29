using Kong.Model;

namespace Kong.About
{
    public class Status
    {
        public ServerStatus Server { get; set; }
        public DatabaseStatus Database { get; set; }
    }
}
