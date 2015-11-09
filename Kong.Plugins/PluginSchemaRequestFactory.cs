using System;
using System.Collections.Generic;
using Kong.Model;

namespace Kong.Plugins
{
    internal class PluginSchemaRequestFactory : RequestFactory<dynamic>, IPluginSchemaRequestFactory
    {
        public PluginSchemaRequestFactory(IKongClient client) : base(client, "plugins/schema/{name}")
        {
            client.Register(this);
        }

        public override IKongCollection<dynamic> List(IDictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public override dynamic Get(string id)
        {
            return Execute(CreateGet<dynamic>(new Dictionary<string, object>
            {
                {"name", id}
            }));
        }

        public override void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public override dynamic Post(dynamic data)
        {
            throw new NotImplementedException();
        }

        public override dynamic Put(dynamic data)
        {
            throw new NotImplementedException();
        }

        public override dynamic Patch(dynamic data)
        {
            throw new NotImplementedException();
        }
    }
}
