using System;
using System.Collections.Generic;
using System.Linq;
using Kong.Exceptions;
using Kong.Model;

namespace Kong.Serialization
{
    public static class PluginTypeHelper
    {
        private static readonly Dictionary<string, Type> Types = new Dictionary<string, Type>();
        private static readonly Dictionary<Type, string> Names = new Dictionary<Type, string>();
        private static readonly Type[] PluginTypes = typeof(Plugin).Assembly.GetTypes().Where(x => x.GetCustomAttributes(typeof(PluginAttribute), false).Any()).ToArray();

        static PluginTypeHelper()
        {
            foreach (var pluginType in PluginTypes)
            {
                var attribute = (PluginAttribute) pluginType.GetCustomAttributes(typeof(PluginAttribute), false)[0];
                Types.Add(attribute.Name, pluginType);
                Names.Add(pluginType, attribute.Name);
            }
        }

        public static Type GetType(string name)
        {
            if (!Types.ContainsKey(name))
            {
                throw new PluginNotSupportedException(name);
            }
            return Types[name];
        }

        public static string GetName<T>()
        {
            return GetName(typeof(T));
        }

        public static string GetName(Type type)
        {

            if (!Names.ContainsKey(type))
            {
                throw new PluginNotSupportedException(type.Name);
            }
            return Names[type];
        }
    }
}
