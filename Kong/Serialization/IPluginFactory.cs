using System;
using Kong.Model;
using Newtonsoft.Json.Linq;

namespace Kong.Serialization
{
    public interface IPluginFactory
    {
        Plugin Create(JObject bag);

        void Register(string name, Type type);
    }
}
