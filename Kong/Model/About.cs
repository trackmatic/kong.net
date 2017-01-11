namespace Kong.Model
{
    public class About
    {
        public string Version { get; set; }

        public string LuaVersion { get; set; }

        public string Tagline { get; set; }

        public string Hostname { get; set; }

        public AboutPlugins Plugins { get; set; }
    }
}
