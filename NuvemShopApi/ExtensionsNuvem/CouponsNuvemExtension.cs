using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace NuvemShopApi.ExtensionsNuvem
{
    public static class CouponsNuvemExtension
    {
        private const string BaseResourceCoupom = "/coupons";

        public static T GetCoupom<T>(this ClientNuvemShop apiClient, long id)
        {
            return apiClient.GetData<T>($"{BaseResourceCoupom}/{id}/");
        }
        
        public static T GetCoupons<T>(this ClientNuvemShop apiClient, params Tuple<string, string>[] urlParams)
        {
            var builder = new StringBuilder();

            foreach (var p in urlParams)
            {
                builder.Append($"{p.Item1}={p.Item2}&");
            }

            return apiClient.GetData<T>($"{BaseResourceCoupom}?fields={builder}");
        }


        public static T CreateCoupons<T>(this ClientNuvemShop apiClient, object model)
        {
            var parameter = new Parameter
            {
                Name = "application/json",
                Type = ParameterType.RequestBody,
                Value = JsonConvert.SerializeObject(model),
                ContentType = "application/json"
            };
            return apiClient.PostData<T>($"{BaseResourceCoupom}", parameter);
        }

        public static T UpdateCoupons<T>(this ClientNuvemShop apiClient, long id, object model)
        {
            var parameter = new Parameter
            {
                Name = "application/json",
                Type = ParameterType.RequestBody,
                Value = JsonConvert.SerializeObject(model),
                ContentType = "application/json"
            };
            return apiClient.PutData<T>($"{BaseResourceCoupom}/{id}",parameter);
        }

        public static T DeleteCoupom<T>(this ClientNuvemShop apiClient, long id)
        {
            return apiClient.DeleteData<T>($"{BaseResourceCoupom}/{id}/");
        }
    }
}
