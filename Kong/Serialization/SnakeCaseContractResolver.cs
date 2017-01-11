using Newtonsoft.Json.Serialization;

namespace Kong.Serialization
{
    public class SnakeCaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return ToSnakeCase(propertyName);
        }

        public static string ToSnakeCase(string name)
        {
            var startUnderscores = System.Text.RegularExpressions.Regex.Match(name, @"^_+");
            return startUnderscores + System.Text.RegularExpressions.Regex.Replace(name, @"([A-Z])", "_$1").ToLower().TrimStart('_');
        }
    }
}