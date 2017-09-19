using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NuvemShopApi.JsonModels;
using RestSharp;

namespace NuvemShopApi
{
    public class ClientNuvemShop
    {
        private const string UserAgentBase = "{0} using NuvemShop4.net {1}";

        public string UserAgent { get; set; }
        public string Email { get; set; }
        public ICredentialsNuvemShop Credentials { get; private set; }

        public const string ResourceUrlAuthorize = "apps/authorize/token";
        public const string ResourceDomainAuthorize = "https://www.tiendanube.com";

        public int LimitRequests { get; private set; }
        public int LimitRemaining { get; private set; }
        public int LimitReset { get; private set; }
        

        public ClientNuvemShop(string email, string userAgent, ICredentialsNuvemShop credentials)
        {
            Email = email;
            UserAgent = userAgent;
            Credentials = credentials;
        }

        /// <summary>
        /// Generate Access Token
        /// </summary>
        /// <param name="code"></param>
        public void AuthorizeApi(string code)
        {
            RestClient client = new RestClient(ResourceDomainAuthorize);

            RestRequest request = new RestRequest(ResourceUrlAuthorize, Method.POST);

            request.AddParameter("Authorization", $"Bearer {Credentials.AppSecret}", ParameterType.HttpHeader);
            request.AddParameter("client_id", Credentials.AppId);
            request.AddParameter("grant_type", "authorization_code");
            request.AddParameter("client_secret", $"{Credentials.AppSecret}");
            request.AddParameter("User-Agent", string.Format(UserAgentBase,UserAgent,Email));
            request.AddParameter("code", code);
            var response = client.Execute(request);
            
            var retorno = JsonConvert.DeserializeObject<AuthorizationJson>(response.Content);
            
            Credentials.AccessToken = retorno.AccessToken;
        }

        public T RunRequest<T>(string resource, Method method,params Parameter[] anotherParameters)
        {
            IRestResponse response = null;
            IRestRequest request = null;

            try
            {
                request = new RestRequest(resource, method);

                request.Parameters.Clear();

                foreach (var p in anotherParameters)
                {
                    request.AddParameter(p);
                }

                //add required Parameters in request
                request = AddRequiredParameters(request);

                response = BuildClientRest().Execute(request);

                UpdateLimitRequests(response);

                if (!(response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created ||
                    response.StatusCode == HttpStatusCode.Accepted))
                {
                    throw new Exception("Error in request see inner exception");
                }

                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            catch (Exception e)
            {
                UpdateLimitRequests(response);
                throw new ApiNuvemShopException(request,response, "An error occurred while attempting the request",e);
            }
        }
        public T GetData<T>(string resource, params Parameter[] anotherParameters) => RunRequest<T>(resource, Method.GET,anotherParameters);
        public T PutData<T>(string resource, params Parameter[] anotherParameters) => RunRequest<T>(resource, Method.PUT, anotherParameters);
        public T PostData<T>(string resource, params Parameter[] anotherParameters) => RunRequest<T>(resource, Method.POST, anotherParameters);
        public T HeadData<T>(string resource, params Parameter[] anotherParameters) => RunRequest<T>(resource, Method.HEAD, anotherParameters);
        public T DeleteData<T>(string resource, params Parameter[] anotherParameters) => RunRequest<T>(resource, Method.DELETE, anotherParameters);


        private void UpdateLimitRequests(IRestResponse response)
        {
            LimitRequests = int.Parse(response.Headers.FirstOrDefault(r => r.Name.Equals("X-Rate-Limit-Limit"))?.Value.ToString()?? "-1");
            LimitRemaining = int.Parse(response.Headers.FirstOrDefault(r => r.Name.Equals("X-Rate-Limit-Remaining"))?.Value.ToString()?? "-1");
            LimitReset = int.Parse(response.Headers.FirstOrDefault(r => r.Name.Equals("X-Rate-Limit-Reset"))?.Value.ToString()?? "-1");
        }


        /// <summary>
        /// Add all required paramether if not exists
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private IRestRequest AddRequiredParameters(IRestRequest request)
        {
            if (!request.Parameters.Any(p => p.Name.Equals("Authentication")))
            {
                request.AddParameter("Authentication", $"bearer {Credentials.AccessToken}", ParameterType.HttpHeader);
            }
            if (!request.Parameters.Any(p => p.Name.Equals("Content-Type")))
            {
                request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            }
            if (!request.Parameters.Any(p => p.Name.Equals("User-Agent")))
            {
                request.AddParameter("User-Agent", string.Format(UserAgentBase, UserAgent, Email), ParameterType.HttpHeader);
            }

            return request;
        }

        private IRestClient BuildClientRest()
        {
            return new RestClient($"https://api.tiendanube.com/v1/{Credentials.AppId}");
        }
    }
}
