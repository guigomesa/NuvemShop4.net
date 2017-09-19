using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvemShopApi.ExtensionsNuvem
{
    public static class ProductsNuvemExtension
    {
        private const string BaseResourceProducts = "/products";

        /// <summary>
        /// Retry products from API
        /// <para>Consult documentation to get parameters to filter request <see cref="https://github.com/TiendaNube/api-docs/blob/master/resources/product.md#get-products"/> </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="urlParams"></param>
        /// <returns></returns>
        public static T GetProducts<T>(this ClientNuvemShop apiClient, params Tuple<string,string>[] urlParams )
        {
            var builder = new StringBuilder();

            foreach (var p in urlParams)
            {
                builder.Append($"{p.Item1}={p.Item2}&");
            }
            return apiClient.GetData<T>($"{BaseResourceProducts}?{builder}");
        }

        /// <summary>
        /// Get a product based on ID
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="id"></param>
        /// <param name="urlParams"></param>
        /// <returns></returns>
        public static T GetProduct<T>(this ClientNuvemShop apiClient, long id,params Tuple<string, string>[] urlParams)
        {
            var builder = new StringBuilder();

            foreach (var p in urlParams)
            {
                builder.Append($"{p.Item1}={p.Item2}&");
            }
            return apiClient.GetData<T>($"{BaseResourceProducts}/{id}/?{builder}");
        }
        
        /// <summary>
        /// Create a new product
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="model"></param>
        /// <param name="urlParams"></param>
        /// <returns></returns>
        public static T CreateProduct<T>(this ClientNuvemShop apiClient, object model, params Tuple<string, string>[] urlParams)
        {
            var builder = new StringBuilder();

            foreach (var p in urlParams)
            {
                builder.Append($"{p.Item1}={p.Item2}&");
            }
            return apiClient.PostData<T>($"{BaseResourceProducts}?{builder}");
        }

        /// <summary>
        /// Update data on product
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <param name="urlParams"></param>
        /// <returns></returns>
        public static T UpdateProduct<T>(this ClientNuvemShop apiClient, object model, long id,params Tuple<string, string>[] urlParams)
        {
            var builder = new StringBuilder();

            foreach (var p in urlParams)
            {
                builder.Append($"{p.Item1}={p.Item2}&");
            }
            return apiClient.PutData<T>($"{BaseResourceProducts}/{id}/?{builder}");
        }

        /// <summary>
        /// Remove a product
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
