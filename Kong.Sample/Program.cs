using System;
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

            var apis = client.Apis().List(requestPath: "/api/v1/refresh");

            

            Console.WriteLine("Done");

            Console.ReadLine();
        }
    }
}
