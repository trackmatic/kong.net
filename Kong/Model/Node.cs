namespace Kong.Model
{
    public class Node
    {
        public string Hostname { get; set; }
        public string LuaVersion { get; set; }
        public PluginStatus Plugins { get; set; }
        public string Tagline { get; set; }
        public string Version { get; set; }
        public dynamic Configuration { get; set; }
    }
}
