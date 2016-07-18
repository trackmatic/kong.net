using System;
using System.Threading.Tasks;
using Kong.Model;
using Kong.Plugins;
using Kong.Plugins.Model;

namespace Kong.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();

            Console.WriteLine("Done");

            Console.ReadLine();
        }

        private static async void Run()
        {

            var client = new KongClient("http://10.10.0.35:8001").RegisterPluginsFrom(typeof(PluginRequestFactory).Assembly);

            var apis = client.Apis();

            var api = await apis.Get("api-v1-vaya");

            api.UpstreamUrl = "http://rest01.trackmatic.co.za";

            await apis.Patch(api);
        }
    }
}
