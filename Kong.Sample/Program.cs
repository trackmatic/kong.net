using System;

namespace Kong.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new KongClient("http://kongserver:8001");

            var apis = client.Apis().List();

            Console.WriteLine("Done");

            Console.ReadLine();
        }
    }
}
