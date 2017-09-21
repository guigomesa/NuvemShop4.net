using System;
using System.Text;
using Newtonsoft.Json;
using RestSharp;

namespace NuvemShopApi.ExtensionsNuvem
{
    public static class CustomersNuvemExtension
    {
        public const string BaseResourceProducts = "/customers";

        /// <summary>
        ///     Get all customers
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="urlParams"></param>
        /// <returns></returns>
        public static T GetCustomers<T>(this ClientNuvemShop apiClient, params Tuple<string, string>[] urlParams)
        {
            var builder = new StringBuilder();

            foreach (var p in urlParams)
                builder.Append($"{p.Item1}={p.Item2}&");
            return apiClient.GetData<T>($"{BaseResourceProducts}?{builder}");
        }

        /// <summary>
        ///     Get specify customer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T GetCustomers<T>(this ClientNuvemShop apiClient, long id)
        {
            return apiClient.GetData<T>($"{BaseResourceProducts}/{id}");
        }

        /// <summary>
        ///     Create a new customer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static T CreateCustomers<T>(this ClientNuvemShop apiClient, object model)
        {
            var parameter = new Parameter
            {
                Name = "application/json",
                Type = ParameterType.RequestBody,
                Value = JsonConvert.SerializeObject(model),
                ContentType = "application/json"
            };

            return apiClient.PostData<T>($"{BaseResourceProducts}", parameter);
        }

        /// <summary>
        ///     Update data in customer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="model"></param>
        /// ///
        /// <param name="id"></param>
        /// <returns></returns>
        public static T UpdateCustomers<T>(this ClientNuvemShop apiClient, long id, object model)
        {
            var parameter = new Parameter
            {
                Name = "application/json",
                Type = ParameterType.RequestBody,
                Value = JsonConvert.SerializeObject(model),
                ContentType = "application/json"
            };

            return apiClient.PutData<T>($"{BaseResourceProducts}/{id}", parameter);
        }

        /// <summary>
        ///     Delete a customer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T DeleteCustomer<T>(this ClientNuvemShop apiClient, long id)
        {
            return apiClient.DeleteData<T>($"{BaseResourceProducts}/{id}/");
        }
    }
}