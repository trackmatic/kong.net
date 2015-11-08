using System;
using Kong.Plugins;
using Kong.Plugins.Model;

namespace Kong.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new KongClient("http://kongserver:8001");

            var apis = client.Apis().List();

            foreach (var api in apis.Data)
            {
                api.PreserveHost = true;

                client.Apis().Patch(api);
                
                var plugin = new RateLimitingPlugin
                {
                    ApiId = api.Id,
                    Enabled = true,
                    Config = new RateLimitingPluginConfig
                    {
                        Second = 10
                    }
                };

                client.Plugins(api).Post(plugin);


            }


            Console.WriteLine("Done");

            Console.ReadLine();
        }
    }
}
