using Kong.Serialization;

namespace Kong.Model
{
    [Plugin("bot-detection")]
    public class BotDetectionPlugin : PluginConfiguration
    {
        /// <summary>
        /// A comma separated array of regular expressions that should be whitelisted. The regular expressions will be checked against the User-Agent header.
        /// </summary>
        public string[] Whilelist { get; set; }

        /// <summary>
        /// A comma separated array of regular expressions that should be blacklisted. The regular expressions will be checked against the User-Agent header.
        /// </summary>
        public string[] Blacklist { get; set; }
    }
}
