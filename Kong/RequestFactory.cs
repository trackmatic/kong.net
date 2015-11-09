using System.Collections.Generic;
using Kong.Model;
using Newtonsoft.Json;
using Slumber;
using Slumber.Http;

namespace Kong
{
    public abstract class RequestFactory<T> : IKongRequestFactory<T>
    {
        private readonly string _name;

        private readonly IKongClient _client;

        protected RequestFactory(IKongClient client, string name)
        {
            _client = client;
            _name = name;
        }

        public abstract IKongCollection<T> List(IDictionary<string, object> parameters);

        public abstract T Get(string id);

        public abstract void Delete(string id);

        public abstract T Patch(T data);

        public abstract string Id { get; }

        public abstract T Post(T data);

        public abstract T Put(T data);

        protected TResponse Execute<TResponse>(IRestRequest<TResponse> request)
        {
            return _client.Execute(request).Data;
        }
        
        protected IRestRequest<IRestResponse> CreateDelete(string id, IDictionary<string, object> parameters = null)
        {
            return CreateRequest<IRestResponse>(HttpMethods.Delete, id, null, parameters);
        }
        
        protected IRestRequest<TResponse> CreatePatch<TResponse>(string id, object data, IDictionary<string, object> parameters = null)
        {
            return CreateRequest<TResponse>(HttpMethods.Patch, id, data, parameters);
        }

        protected IRestRequest<TResponse> CreatePost<TResponse>(object data, IDictionary<string, object> parameters = null)
        {
            return CreateRequest<TResponse>(HttpMethods.Post, null, data, parameters);
        }

        protected IRestRequest<TResponse> CreatePut<TResponse>(object data, IDictionary<string, object> parameters = null)
        {
            return CreateRequest<TResponse>(HttpMethods.Put, null, data, parameters);
        }

        protected IRestRequest<TResponse> CreateGet<TResponse>(IDictionary<string, object> parameters)
        {
            return CreateGet<TResponse>(null, parameters);
        }

        protected IRestRequest<TResponse> CreateGet<TResponse>(string id, IDictionary<string, object> parameters = null)
        {
            return CreateRequest<TResponse>(HttpMethods.Get, id, null, parameters);
        }

        protected IRestRequest<TResponse> CreateRequest<TResponse>(string method, string resource, object data, IDictionary<string, object> parameters)
        {
            var request = new HttpRestRequest<TResponse>($"/{_name}/{{resource}}", method);
            request.AddQueryParameter("resource", resource);
            foreach (var parameter in parameters ?? new Dictionary<string, object>())
            {
                request.AddQueryParameter(parameter.Key, parameter.Value, true);
            }
            request.Data = data;
            return request;
        }

        public virtual void Configure(JsonSerializerSettings settings)
        {
            
        }
    }
}
