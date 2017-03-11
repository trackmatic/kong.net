using System;
using Kong.Exceptions;
using Kong.Model;

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
            var factory = new KongClientFactory("http://localhost:8001");

            var client = factory.Create();
            
            var apis = await client.Apis.List();

            var api = await client.Apis.Get("api-v2-account-auth");

            await api.Plugins.Put(new PluginData
            {
                Config = new CorsPlugin
                {
                    Credentials = true,
                    ExposedHeaders = new [] {"Authorization"}
                }
            });


        }
    }
}
