using System;
using System.Text;
using Newtonsoft.Json;
using RestSharp;

namespace NuvemShopApi.ExtensionsNuvem
{
    public static class CouponsNuvemExtension
    {
        public const string BaseResourceCoupom = "/coupons";

        /// <summary>
        ///     Get cupons
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T GetCoupom<T>(this ClientNuvemShop apiClient, long id)
        {
            return apiClient.GetData<T>($"{BaseResourceCoupom}/{id}/");
        }

        /// <summary>
        ///     Get an specify cupom
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="urlParams"></param>
        /// <returns></returns>
        public static T GetCoupons<T>(this ClientNuvemShop apiClient, params Tuple<string, string>[] urlParams)
        {
            var builder = new StringBuilder();

            foreach (var p in urlParams)
                builder.Append($"{p.Item1}={p.Item2}&");

            return apiClient.GetData<T>($"{BaseResourceCoupom}?fields={builder}");
        }

        /// <summary>
        ///     Create a new coupom
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        ///     Update an coupon
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static T UpdateCoupons<T>(this ClientNuvemShop apiClient, long id, object model)
        {
            var parameter = new Parameter
            {
                Name = "application/json",
                Type = ParameterType.RequestBody,
                Value = JsonConvert.SerializeObject(model),
                ContentType = "application/json"
            };
            return apiClient.PutData<T>($"{BaseResourceCoupom}/{id}", parameter);
        }

        /// <summary>
        ///     Delete an coupom
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T DeleteCoupom<T>(this ClientNuvemShop apiClient, long id)
        {
            return apiClient.DeleteData<T>($"{BaseResourceCoupom}/{id}/");
        }
    }
}