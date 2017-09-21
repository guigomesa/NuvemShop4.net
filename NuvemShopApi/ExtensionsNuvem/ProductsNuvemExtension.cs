using System;
using System.Text;
using Newtonsoft.Json;
using RestSharp;

namespace NuvemShopApi.ExtensionsNuvem
{
    public static class ProductsNuvemExtension
    {
        public const string BaseResourceProducts = "/products";

        /// <summary>
        ///     Retry products from API
        ///     <para>
        ///         Consult documentation to get parameters to filter request
        ///         <see cref="https://github.com/TiendaNube/api-docs/blob/master/resources/product.md#get-products" />
        ///     </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="urlParams"></param>
        /// <returns></returns>
        public static T GetProducts<T>(this ClientNuvemShop apiClient, params Tuple<string, string>[] urlParams)
        {
            var builder = new StringBuilder();

            foreach (var p in urlParams)
                builder.Append($"{p.Item1}={p.Item2}&");
            return apiClient.GetData<T>($"{BaseResourceProducts}?{builder}");
        }

        /// <summary>
        ///     Get a product based on ID
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="id"></param>
        /// <param name="urlParams"></param>
        /// <returns></returns>
        public static T GetProduct<T>(this ClientNuvemShop apiClient, long id, params Tuple<string, string>[] urlParams)
        {
            var builder = new StringBuilder();

            foreach (var p in urlParams)
                builder.Append($"{p.Item1}={p.Item2}&");
            return apiClient.GetData<T>($"{BaseResourceProducts}/{id}/?{builder}");
        }

        /// <summary>
        ///     Create a new product
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static T CreateProduct<T>(this ClientNuvemShop apiClient, object model)
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
        ///     Update data on product
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T UpdateProduct<T>(this ClientNuvemShop apiClient, object model, long id)
        {
            var parameter = new Parameter
            {
                Name = "application/json",
                Type = ParameterType.RequestBody,
                Value = JsonConvert.SerializeObject(model),
                ContentType = "application/json"
            };

            return apiClient.PutData<T>($"{BaseResourceProducts}/{id}/", parameter);
        }

        /// <summary>
        ///     Remove a product
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T DeleteProduct<T>(this ClientNuvemShop apiClient, long id)
        {
            return apiClient.DeleteData<T>($"{BaseResourceProducts}/{id}/");
        }
    }
}