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
                Config = new Oauth2Plugin
                {
                    HideCredentials = false,
                    AcceptHttpIfAlreadyTerminated = true,
                    EnableAuthorizationCode = true,
                    EnableClientCredentials = true,
                    EnableImplicitGrant = true,
                    EnablePasswordGrant = true,
                    MandatoryScope = false,
                    Scopes = new [] { "user" },
                    TokenExpiration = 60000
                }
            });*/
            

            var plugin = await api.Plugins.Get("2870ae9d-501d-4639-a32d-476fb0d845f4");

            //await plugin.Delete();

            var configuration = plugin.Configure<Oauth2Plugin>();

            //await configuration.Credentials(consumers.Data[0].Id).Create("bla", "blabla", Guid.NewGuid().ToString(), "http://redirect.com");

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
