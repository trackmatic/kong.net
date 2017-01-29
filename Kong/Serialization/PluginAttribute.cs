using System;

namespace Kong.Serialization
{
    public class PluginAttribute : Attribute
    {
        public PluginAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
