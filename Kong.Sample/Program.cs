using System;
using Kong.Plugins;

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

                var plugins = client.Plugins(api).List();
            }


            Console.WriteLine("Done");

            Console.ReadLine();
        }
    }
}
