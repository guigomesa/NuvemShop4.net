using System;
using RestSharp;

namespace NuvemShopApi
{
    public class ApiNuvemShopException : Exception
    {
        public ApiNuvemShopException(IRestRequest request, IRestResponse response, string message,
            Exception innerException) : base(message, innerException)
        {
            Response = response;
            Request = request;
        }

        public IRestResponse Response { get; set; }
        public IRestRequest Request { get; set; }
    }
}