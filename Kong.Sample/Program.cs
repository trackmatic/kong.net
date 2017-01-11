using System;
using System.Collections.Generic;
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

            api.UpstreamUrl = "http://rest02.trackmatic.co.za";

            await apis.Put(api);

            /*((CorsPlugin) cors).Config.ExposedHeaders = new List<string> { "Authorization" };


            ((CorsPlugin) cors).Config.Methods = new List<string>
            {
                "GET",
                "HEAD",
                "PUT",
                "PATCH",
                "POST",
                "DELETE"
            };
            ((CorsPlugin) cors).Config.Headers = null;
            ((CorsPlugin) cors).Config.PreflightContinue = true;
            await plugins.Put(cors);*/

        }
    }
}
