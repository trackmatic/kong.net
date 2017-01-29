using System;
using Kong.Serialization;

namespace Kong.Exceptions
{
    public class PluginConfigurationException : Exception
    {
        public PluginConfigurationException(string name, Type type)
            : base($"Did you mean Configure<{PluginTypeHelper.GetType(name).Name}>(). You tried to cast {type.Name} to {PluginTypeHelper.GetType(name).Name} which is not possible.")
        {
            
        }
    }
}
