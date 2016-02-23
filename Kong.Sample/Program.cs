using System;
using Kong.Plugins;

namespace Kong.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new KongClient("http://10.10.0.35:8001").RegisterPluginsFrom(typeof(PluginRequestFactory).Assembly);

            var apis = client.Apis();

            Console.WriteLine("Done");

            Console.ReadLine();
        }
    }
}
