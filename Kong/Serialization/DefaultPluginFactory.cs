using System;
using System.Collections.Generic;
using Kong.Model;
using Newtonsoft.Json.Linq;

namespace Kong.Serialization
{
    public class DefaultPluginFactory : IPluginFactory
    {
        private readonly Dictionary<string, Type> _factories;

        public DefaultPluginFactory()
        {
            _factories = new Dictionary<string, Type>();
        }

        public void Register(string name, Type type)
        {
            _factories.Add(name, type);
        }

        public Plugin Create(JObject bag)
        {
            var name = bag["name"].ToString();
            if (!_factories.ContainsKey(name))
            {
                return bag.ToObject<Plugin>();
            }
            return (Plugin)bag.ToObject(_factories[name]);
        }
    }
}
