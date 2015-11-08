using System;
using Kong.Plugins.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Kong.Plugins.Serialization
{
    public class PluginConverter : JsonConverter
    {
        private readonly IPluginFactory _factory;

        public PluginConverter(IPluginFactory factory)
        {
            _factory = factory;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var bag = serializer.Deserialize<JObject>(reader);
            var plugin = _factory.Create(bag);
            if (plugin == null)
            {
                return serializer.Deserialize<Plugin>(reader);
            }
            return plugin;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (Plugin);
        }
    }
}
