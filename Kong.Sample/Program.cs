using System;
using Kong.Plugins;
using Kong.Plugins.Model;

namespace Kong.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new KongClient("http://kongserver:8001").RegisterPluginsFrom(typeof(PluginRequestFactory).Assembly);

            var apis = client.Apis();

            Console.WriteLine("Done");

            Console.ReadLine();
        }
    }
}
