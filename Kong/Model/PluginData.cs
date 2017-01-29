using System.Text.RegularExpressions;
using Kong.Serialization;

namespace Kong.Model
{
    public class PluginData
    {
        /// <summary>
        /// The name of the Plugin that's going to be added. Currently the Plugin must be installed in every Kong instance separately.
        /// </summary>
        public string Name => PluginTypeHelper.GetName(Config.GetType());

        /// <summary>
        /// The unique identifier of the consumer that overrides the existing settings for this specific consumer on incoming requests.
        /// </summary>
        public string ConsumerId { get; set; }

        /// <summary>
        /// The configuration properties for the Plugin which can be found on the plugins documentation page in the Plugin Gallery.
        /// </summary>
        public IPluginConfiguration Config { get; set; }
    }
}
;