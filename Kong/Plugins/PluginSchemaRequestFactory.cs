using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kong.Model;

namespace Kong.Plugins
{
    internal class PluginSchemaRequestFactory : RequestFactory<dynamic>, IPluginSchemaRequestFactory
    {
        public PluginSchemaRequestFactory(IKongClient client) : base(client, "plugins/schema/{name}")
        {
        }

        public override Task<IKongCollection<dynamic>> List(IDictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public override async Task<dynamic> Get(string id)
        {
            var response = await ExecuteAsync(CreateGet<dynamic>(new Dictionary<string, object>
            {
                {"name", id}
            }));
            return response;
        }

        public override Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public override Task<dynamic> Post(dynamic data)
        {
            throw new NotImplementedException();
        }

        public override Task<dynamic> Put(dynamic data)
        {
            throw new NotImplementedException();
        }

        public override Task<dynamic> Patch(dynamic data)
        {
            throw new NotImplementedException();
        }
    }
}
