using System;
using System.Text.RegularExpressions;

namespace Kong.Model
{
    public class Plugin
    {
        public Plugin()
        {
            Name = GetNameFromType(GetType());
        }

        public Plugin(string name)
        {
            Name = name;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string ApiId { get; set; }

        public bool Enabled { get; set; }
        
        public static string GetNameFromType(Type type)
        {
            return Regex.Replace(type.Name, "(\\B[A-Z])", "-$1").Replace("-Plugin", string.Empty).ToLower();
        }
    }
}
