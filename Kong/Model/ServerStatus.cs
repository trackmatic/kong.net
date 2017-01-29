namespace Kong.Model
{
    public class ServerStatus
    {
        public int ConnectionsHandled { get; set; }
        public int ConnectionsReading { get; set; }
        public int ConnectionsActive { get; set; }
        public int ConnectionsWaiting { get; set; }
        public int ConnectionsWriting { get; set; }
        public long TotalRequests { get; set; }
        public long ConnectionsAccepted { get; set; }
    }
}
