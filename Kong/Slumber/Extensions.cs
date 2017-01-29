using System.Collections.Generic;
using Slumber.Http;

namespace Kong.Slumber
{
    internal static class Extensions
    {
        public static HttpRequestBuilder<T> Headers<T>(this HttpRequestBuilder<T> builder, IDictionary<string, string> headers)
        {
            if (headers == null)
            {
                return builder;
            }

            foreach (var header in headers)
            {
                builder.Header(header.Key, header.Value);
            }

            return builder;
        }

        public static HttpRequestBuilder<T> QueryParameters<T>(this HttpRequestBuilder<T> builder, IDictionary<string, object> parameters, bool ignoreEmptyValues = false)
        {
            if (parameters == null)
            {
                return builder;
            }

            foreach (var parameter in parameters)
            {
                builder = builder.QueryParameter(parameter.Key, parameter.Value, ignoreEmptyValues);
            }

            return builder;
        }

        public static HttpRequestBuilder<T> QueryParameters<T>(this HttpRequestBuilder<T> builder, IDictionary<string, string> parameters, bool ignoreEmptyValues = false)
        {
            if (parameters == null)
            {
                return builder;
            }

            foreach (var parameter in parameters)
            {
                builder = builder.QueryParameter(parameter.Key, parameter.Value, ignoreEmptyValues);
            }

            return builder;
        }
    }
}
