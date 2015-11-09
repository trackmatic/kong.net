using System;
using Kong.Model;
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


            var consumer = consumers.Get("Ross");

            consumer.CustomId = "1234";

            consumers.Patch(consumer);

            

            Console.WriteLine("Done");

            Console.ReadLine();
        }
    }
}
