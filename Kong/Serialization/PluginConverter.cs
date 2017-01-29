using System;
using Kong.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Kong.Serialization
{
    public class PluginConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var bag = serializer.Deserialize<JObject>(reader);

            var plugin = new Plugin
            {
                ApiId = Get<string>(bag, "api_id"),
                ConsumerId = Get<string>(bag, "consumer_id"),
                CreatedAt = Get<long>(bag, "created_at"),
                Enabled = Get<bool>(bag, "enabled"),
                Id = Get<string>(bag, "id"),
                Name = Get<string>(bag, "name"),
                Config = CreateConfiguration(Get<string>(bag, "name"), bag, serializer)
            };

            return plugin;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Plugin);
        }

        private T Get<T>(JObject bag, string property)
        {
            JToken value;
            if (bag.TryGetValue(property, out value))
            {
                return value.Value<T>();
            }
            return default(T);
        }


        private static IPluginConfiguration CreateConfiguration(string name, JObject bag, JsonSerializer serializer)
        {
            return (IPluginConfiguration)bag["config"].ToObject(PluginTypeHelper.GetType(name), serializer);
        }
    }
}