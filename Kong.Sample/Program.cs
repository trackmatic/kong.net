using System;
using Kong.Plugins;
using Kong.Plugins.Model;
using Slumber.Logging;

namespace Kong.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new KongClient("http://kongserver:8001", config => config.UseConsoleLogger());

            var consumer = client.Consumers().Get("Ross");

            var basicAuth = client.BasicAuth(consumer);

            basicAuth.CreateCredential("ross", "secret");

            Console.WriteLine("Done");

            Console.ReadLine();
        }
    }
}
