using System;

namespace Kong.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(dynamic error, Exception e) : base(e.Message, e)
        {
            Error = error;
        }

        public dynamic Error { get; set; }
    }
}
