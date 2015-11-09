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

            Console.WriteLine("Done");

            Console.ReadLine();
        }
    }
}
