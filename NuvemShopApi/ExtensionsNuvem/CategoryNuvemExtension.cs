using System.Text;
using Newtonsoft.Json;
using RestSharp;

namespace NuvemShopApi.ExtensionsNuvem
{
    public static class CategoryNuvemExtension
    {
        public const string BaseResourceCategory = "/categories";

        /// <summary>
        ///     Get all categories
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <returns></returns>
        public static T GetCategory<T>(this ClientNuvemShop apiClient)
        {
            return apiClient.GetData<T>($"{BaseResourceCategory}");
        }

        /// <summary>
        ///     Get a specify category based on id
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
        ///     Get specify fields of categories
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static T GetCategory<T>(this ClientNuvemShop apiClient, params string[] fields)
        {
            var builder = new StringBuilder();

            foreach (var p in fields)
                builder.Append($"{p},");

            return apiClient.GetData<T>($"{BaseResourceCategory}?fields={builder}");
        }

        /// <summary>
        ///     Get specify fields of category
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static T GetCategory<T>(this ClientNuvemShop apiClient, long id, params string[] fields)
        {
            var builder = new StringBuilder();

            foreach (var p in fields)
                builder.Append($"{p},");

            return apiClient.GetData<T>($"{BaseResourceCategory}/{id}/?fields={builder}");
        }

        /// <summary>
        ///     Create a new category
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static T CreateCategory<T>(this ClientNuvemShop apiClient, object model)
        {
            var parameter = new Parameter
            {
                Name = "application/json",
                Type = ParameterType.RequestBody,
                Value = JsonConvert.SerializeObject(model),
                ContentType = "application/json"
            };

            return apiClient.PostData<T>($"{BaseResourceCategory}", parameter);
        }

        /// <summary>
        ///     Update a category
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T UpdateCategory<T>(this ClientNuvemShop apiClient, object model, long id)
        {
            var parameter = new Parameter
            {
                Name = "application/json",
                Type = ParameterType.RequestBody,
                Value = JsonConvert.SerializeObject(model),
                ContentType = "application/json"
            };
            return apiClient.PostData<T>($"{BaseResourceCategory}/{id}/", parameter);
        }

        /// <summary>
        ///     Delete a category
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