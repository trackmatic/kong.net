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

            var node = client.Node().Result;

            var consumers = client.Consumers.List().Result;

            var apis = client.Apis.List(requestHost: "rest.api.com22").Result;


            var api = client.Apis.Get("google").Result;

            /*var newPlugin = await api.Plugins.Create(new PluginData
            {
                Config = new HmacAuthPlugin
                {
                    ClockSkew = 300,
                    HideCredentials = false
                }
            });*/

            var plugin = await api.Plugins.Get("886946bf-7e95-434d-902b-6cad22c501cc");

            var configuration = plugin.Configure<HmacAuthPlugin>();

            await configuration.Credentials(consumers.Data[0].Id).Create("bla", Guid.NewGuid().ToString());

            var credentials = await configuration.Credentials(consumers.Data[0].Id).List();

            foreach (var item in credentials.Data)
            {
                await configuration.Credentials(consumers.Data[0].Id).Delete(item.Id);
            }

            //var credential = await credentials.Create("a36c3049b36249a3c9f8891cb127243c", "e71829c351aa4242c2719cbfbe671c09");

            /*((CorsPlugin) cors).Config.ExposedHeaders = new List<string> { "Authorization" };


            ((CorsPlugin) cors).Config.Methods = new List<string>
            {
                "GET",
                "HEAD",
                "PUT",
                "PATCH",
                "POST",
                "DELETE"
            };
            ((CorsPlugin) cors).Config.Headers = null;
            ((CorsPlugin) cors).Config.PreflightContinue = true;
            await plugins.Put(cors);*/

        }
    }
}
