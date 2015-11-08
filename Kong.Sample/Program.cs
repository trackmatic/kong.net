using System;

namespace Kong.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new KongClient("http://10.10.0.76:8001");

            var apis = client.Apis.List();

            foreach (var api in apis.Data)
            {
                api.PreserveHost = true;

                client.Apis.Patch(api);
            }

            Console.WriteLine("Done");

            Console.ReadLine();
        }
    }
}
