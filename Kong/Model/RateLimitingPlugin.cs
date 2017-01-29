using Kong.Serialization;

namespace Kong.Model
{
    /// <summary>
    /// Rate limit how many HTTP requests a developer can make in a given period of seconds, minutes, hours, days, months or years. If the API has no authentication layer, the Client IP address will be used, otherwise the Consumer will be used if an authentication plugin has been configured.
    /// </summary>
    [Plugin("rate-limiting")]
    public class RateLimitingPlugin : PluginConfiguration
    {
        /// <summary>
        /// The amount of HTTP requests the developer can make per second. At least one limit must exist.
        /// </summary>
        public long? Second { get; set; }

        /// <summary>
        /// The amount of HTTP requests the developer can make per minute. At least one limit must exist.
        /// </summary>
        public long? Minute { get; set; }

        /// <summary>
        /// The amount of HTTP requests the developer can make per hour. At least one limit must exist.
        /// </summary>
        public long? Hour { get; set; }

        /// <summary>
        /// The amount of HTTP requests the developer can make per day. At least one limit must exist.
        /// </summary>
        public long? Day { get; set; }

        /// <summary>
        /// The amount of HTTP requests the developer can make per month. At least one limit must exist.
        /// </summary>
        public long? Month { get; set; }

        /// <summary>
        /// The amount of HTTP requests the developer can make per year. At least one limit must exist.
        /// </summary>
        public long? Year { get; set; }

        /// <summary>
        /// The entity that will be used when aggregating the limits: consumer, credential, ip. If the consumer or the credential cannot be determined, the system will always fallback to ip.
        /// </summary>
        public string LimitBy { get; set; }

        /// <summary>
        /// The rate-limiting policies to use for retrieving and incrementing the limits. Available values are local (counters will be stored locally in-memory on the node), cluster (counters are stored in the datastore and shared across the nodes) and redis (counters are stored on a Redis server and will be shared across the nodes).
        /// </summary>
        public string Policy { get; set; }

        /// <summary>
        /// A boolean value that determines if the requests should be proxied even if Kong has troubles connecting a third-party datastore. If true requests will be proxied anyways effectively disabling the rate-limiting function until the datastore is working again. If false then the clients will see 500 errors.
        /// </summary>
        public bool FaultTolerant { get; set; }

        /// <summary>
        /// When using the redis policy, this property specifies the address to the Redis server.
        /// </summary>
        public string RedisHost { get; set; }

        /// <summary>
        /// When using the redis policy, this property specifies the port of the Redis server. By default is 6379.
        /// </summary>
        public int RedisPort { get; set; }

        /// <summary>
        /// When using the redis policy, this property specifies the password to connect to the Redis server.
        /// </summary>
        public string RedisPassword { get; set; }

        /// <summary>
        /// When using the redis policy, this property specifies the timeout in milliseconds of any command submitted to the Redis server.
        /// </summary>
        public int RedisTimeout { get; set; }
    }
}
