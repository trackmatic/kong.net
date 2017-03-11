using System.Collections.Generic;
using System.Threading.Tasks;
using Kong.Exceptions;
using Slumber;
using Slumber.Http;

namespace Kong.Slumber
{
    internal sealed class RequestFactory : IRequestFactory
    {
        private readonly string _baseUrl;
        private readonly IDictionary<string, string> _parameters;
        private readonly ISlumberClient _client;

        public RequestFactory(ISlumberClient client)
            : this(null, client, string.Empty, new Dictionary<string, string>())
        {
            
        }

        public RequestFactory(IRequestFactory parent, ISlumberClient client, string baseUrl, IDictionary<string, string> parameters)
        {
            Parent = parent;
            _baseUrl = baseUrl;
            _parameters = parameters;
            _client = client;
        }

        public async Task<T> List<T>(IDictionary<string, object> parameters)
        {
            var request = HttpRequestBuilder<T>
                .Get(_baseUrl)
                .QueryParameters(_parameters)
                .QueryParameters(parameters, true)
                .Build();
            var response = await Execute(request).ConfigureAwait(false);
            return GetContent(response);
        }

        public async Task<T> Post<T>(object data, IDictionary<string, string> headers = null)
        {
            var request = HttpRequestBuilder<T>.Post(_baseUrl).QueryParameters(_parameters).Content(data).Headers(headers).Build();
            var response = await Execute(request).ConfigureAwait(false);
            return GetContent(response);
        }

        public async Task<T> Post<T>(IDictionary<string, string> headers = null)
        {
            var request = HttpRequestBuilder<T>
                .Post(_baseUrl)
                .QueryParameters(_parameters)
                .Build();
            var response = await Execute(request).ConfigureAwait(false);
            return GetContent(response);
        }

        public async Task<T> Get<T>(string id)
        {
            var request = HttpRequestBuilder<T>
                .Get($"{_baseUrl}/{{id}}")
                .QueryParameters(_parameters)
                .QueryParameter("id", id)
                .Build();
            var response = await Execute(request).ConfigureAwait(false);
            return GetContent(response);
        }

        public async Task<T> Get<T>()
        {
            var request = HttpRequestBuilder<T>
                .Get($"{_baseUrl}")
                .QueryParameters(_parameters)
                .Build();
            var response = await Execute(request).ConfigureAwait(false);
            return GetContent(response);
        }

        public async Task<T> Put<T>(object data)
        {
            var request = HttpRequestBuilder<T>
                .Put($"{_baseUrl}")
                .QueryParameters(_parameters)
                .Content(data)
                .Build();
            var response = await Execute(request).ConfigureAwait(false);
            return GetContent(response);
        }

        public async Task<T> Patch<T>(object data)
        {
            var request = HttpRequestBuilder<T>
                .Patch($"{_baseUrl}")
                .QueryParameters(_parameters)
                .Content(data)
                .Build();
            var response = await Execute(request).ConfigureAwait(false);
            return GetContent(response);
        }

        public Task Delete()
        {
            var request = HttpRequestBuilder<dynamic>
                .Delete($"{_baseUrl}")
                .QueryParameters(_parameters)
                .Build();
            return Execute(request);
        }
        
        public IRequestFactory Create(string url)
        {
            return Create(url, new Dictionary<string, string>());
        }

        public IRequestFactory Create(IDictionary<string, string> parameters)
        {
            return new RequestFactory(this, _client, _baseUrl, Merge(parameters));
        }

        public IRequestFactory Create(string url, IDictionary<string, string> parameters)
        {
            return new RequestFactory(this, _client, Merge(url), Merge(parameters));
        }

        public IRequestFactory Parent { get; }

        public IRequestFactory Root
        {
            get
            {
                if (Parent == null)
                {
                    return this;
                }

                return Parent.Root;
            }
        }

        private string Merge(string url)
        {
            return string.Join(url.StartsWith("/") ? string.Empty : "/", _baseUrl, url);
        }

        private IDictionary<string, string> Merge(IDictionary<string, string> parameters)
        {
            foreach (var parameter in _parameters)
            {
                if (parameters.ContainsKey(parameter.Key))
                {
                    continue;
                }
                parameters.Add(parameter.Key, parameter.Value);
            }
            return parameters;
        }
        
        private T GetContent<T>(IResponse<T> response)
        {
            return string.IsNullOrEmpty(response.Content) ? default(T) : response.Data;
        }

        private async Task<IResponse<T>> Execute<T>(IRequest<T> request)
        {
            var response = await _client.ExecuteAsync(request).ConfigureAwait(false);
            HandleError(response);
            return response;
        }

        public void HandleError(IResponse response)
        {
            if (!response.HasError)
            {
                return;
            }
            var content = response.Exception.GetContent<dynamic>(_client.Configuration.Serialization.CreateDeserializer(response));
            throw new ApiException(content, response.Exception);
        }
    }
} 