using System;

namespace Kong.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(int httpStatusCode, dynamic error, Exception e) : base(e.Message, e)
        {
            HttpStatusCode = httpStatusCode;
            Error = error;
        }

        public dynamic Error { get; }
        public int HttpStatusCode { get; }
    }
}
