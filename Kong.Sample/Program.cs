using System;
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

            var node = await client.Node();

            var consumers = await client.Consumers.List();

            var apis = await client.Apis.List();
        }
    }
}
