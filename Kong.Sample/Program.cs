using System;
using Kong.Model;
using Kong.Plugins;
using Slumber.Logging;

namespace Kong.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new KongClient("http://kongserver:8001", config => config.UseConsoleLogger());

            var status = client.Status();

            var about = client.About();

            var consumers = client.Consumers();

            var results = consumers.List(customId: "1234");

            var schema = client.Schema().Get("cors");

            

            Console.WriteLine("Done");

            Console.ReadLine();
        }
    }
}
