using System;
using System.Text;
using Newtonsoft.Json;
using RestSharp;

namespace NuvemShopApi.ExtensionsNuvem
{
    public static class OrderNuvemExtension
    {
        public const string BaseResourceOrder = "/coupons";

        /// <summary>
        ///     Get orders
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T GetOrders<T>(this ClientNuvemShop apiClient, long id)
        {
            return apiClient.GetData<T>($"{BaseResourceOrder}/{id}/");
        }

        /// <summary>
        ///     Get specify order
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="urlParams"></param>
        /// <returns></returns>
        public static T GetOrders<T>(this ClientNuvemShop apiClient, params Tuple<string, string>[] urlParams)
        {
            var builder = new StringBuilder();

            foreach (var p in urlParams)
                builder.Append($"{p.Item1}={p.Item2}&");

            return apiClient.GetData<T>($"{BaseResourceOrder}?fields={builder}");
        }

        /// <summary>
        ///     Create a new order
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static T CreateOrder<T>(this ClientNuvemShop apiClient, object model)
        {
            var parameter = new Parameter
            {
                Name = "application/json",
                Type = ParameterType.RequestBody,
                Value = JsonConvert.SerializeObject(model),
                ContentType = "application/json"
            };
            return apiClient.PostData<T>($"{BaseResourceOrder}", parameter);
        }

        /// <summary>
        ///     Update an order
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static T UpdateOrder<T>(this ClientNuvemShop apiClient, long id, object model)
        {
            var parameter = new Parameter
            {
                Name = "application/json",
                Type = ParameterType.RequestBody,
                Value = JsonConvert.SerializeObject(model),
                ContentType = "application/json"
            };
            return apiClient.PutData<T>($"{BaseResourceOrder}/{id}", parameter);
        }

        /// <summary>
        ///     ReOpen an order
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T ReOpenOrder<T>(this ClientNuvemShop apiClient, long id)
        {
            return apiClient.PostData<T>($"{BaseResourceOrder}/{id}/open");
        }

        /// <summary>
        ///     Close an order
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T CloseOrder<T>(this ClientNuvemShop apiClient, long id)
        {
            return apiClient.PostData<T>($"{BaseResourceOrder}/{id}/close");
        }

        /// <summary>
        ///     Cancel an order
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T CancelOrder<T>(this ClientNuvemShop apiClient, long id)
        {
            return apiClient.PostData<T>($"{BaseResourceOrder}/{id}/cancel");
        }

        /// <summary>
        ///     Fullfill order
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static T FullFillOrder<T>(this ClientNuvemShop apiClient, long id, object model)
        {
            var parameter = new Parameter
            {
                Name = "application/json",
                Type = ParameterType.RequestBody,
                Value = JsonConvert.SerializeObject(model),
                ContentType = "application/json"
            };
            return apiClient.PostData<T>($"{BaseResourceOrder}/{id}/fulfill", parameter);
        }
    }
}