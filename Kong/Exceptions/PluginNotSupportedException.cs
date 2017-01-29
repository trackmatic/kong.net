using System;

namespace Kong.Exceptions
{
    public class PluginNotSupportedException : Exception
    {
        public PluginNotSupportedException(string name) : base($"Plugin {name} is not currently supported")
        {
            
        }
    }
}
