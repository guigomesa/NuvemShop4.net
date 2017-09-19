using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvemShopApi.ExtensionsNuvem
{
    public static class CategoryNuvemExtension
    {
        private const string BaseResourceCategory = "/categories";

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <returns></returns>
        public static T GetCategory<T>(this ClientNuvemShop apiClient)
        {
            return apiClient.GetData<T>($"{BaseResourceCategory}");
        }

        /// <summary>
        /// Get a specify category based on id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T GetCategory<T>(this ClientNuvemShop apiClient, long id)
        {
            return apiClient.GetData<T>($"{BaseResourceCategory}/{id}/");
        }

        /// <summary>
        /// Get specify fields of categories
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static T GetCategory<T>(this ClientNuvemShop apiClient, params string[] fields)
        {
            var builder = new StringBuilder();

            foreach (var p in fields)
            {
                builder.Append($"{p},");
            }

            return apiClient.GetData<T>($"{BaseResourceCategory}?fields={builder}");
        }

        /// <summary>
        /// Get specify fields of category
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static T GetCategory<T>(this ClientNuvemShop apiClient, long id,params string[] fields)
        {
            var builder = new StringBuilder();

            foreach (var p in fields)
            {
                builder.Append($"{p},");
            }

            return apiClient.GetData<T>($"{BaseResourceCategory}/{id}/?fields={builder}");
        }

        /// <summary>
        /// Create a new category
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="model"></param>
        /// <param name="urlParams"></param>
        /// <returns></returns>
        public static T CreateCategory<T>(this ClientNuvemShop apiClient, object model, params Tuple<string, string>[] urlParams)
        {
            var builder = new StringBuilder();

            foreach (var p in urlParams)
            {
                builder.Append($"{p.Item1}={p.Item2}&");
            }
            return apiClient.PostData<T>($"{BaseResourceCategory}?{builder}");
        }

        /// <summary>
        /// Update a category
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <param name="urlParams"></param>
        /// <returns></returns>
        public static T UpdateCategory<T>(this ClientNuvemShop apiClient, object model, long id,params Tuple<string, string>[] urlParams)
        {
            var builder = new StringBuilder();

            foreach (var p in urlParams)
            {
                builder.Append($"{p.Item1}={p.Item2}&");
            }
            return apiClient.PostData<T>($"{BaseResourceCategory}/{id}/?{builder}");
        }

        /// <summary>
        /// Delete a category
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T DeleteCategory<T>(this ClientNuvemShop apiClient, long id)
        {
            return apiClient.DeleteData<T>($"{BaseResourceCategory}/{id}/");
        }
    }
}
