using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace NuvemShopApi
{
    public class ApiNuvemShopException : Exception
    {
        public ApiNuvemShopException(IRestRequest request, IRestResponse response, string message,
            Exception innerException):base(message,innerException)
        {
            Response = response;
            Request = request;
        }

        public IRestResponse Response { get; set; }
        public IRestRequest Request { get; set; }
    }
}
