using System;
using System.Text;
using Newtonsoft.Json;
using RestSharp;

namespace NuvemShopApi.ExtensionsNuvem
{
    public static class ProductVariantNuvemExtension
    {
        public const string BaseResourceProductsVariant = "/products/{0}/variants";

        /// <summary>
        ///     Get products variants
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="idProduct"></param>
        /// <param name="urlParams"></param>
        /// <returns></returns>
        public static T GetProductVariants<T>(this ClientNuvemShop apiClient, long idProduct,
            params Tuple<string, string>[] urlParams)
        {
            var builder = new StringBuilder();

            foreach (var p in urlParams)
                builder.Append($"{p.Item1}={p.Item2}&");
            return apiClient.GetData<T>($"{string.Format(BaseResourceProductsVariant, idProduct)}?{builder}");
        }

        /// <summary>
        ///     Get an specify product variant
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="idProduct"></param>
        /// <param name="idVariant"></param>
        /// <returns></returns>
        public static T GetProductVariant<T>(this ClientNuvemShop apiClient, long idProduct, long idVariant)
        {
            return apiClient.GetData<T>($"{string.Format(BaseResourceProductsVariant, idProduct)}/{idVariant}");
        }

        /// <summary>
        ///     Create a new product variant
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="idProduct"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static T CreateProductVariant<T>(this ClientNuvemShop apiClient, long idProduct, object model)
        {
            var parameter = new Parameter
            {
                Name = "application/json",
                Type = ParameterType.RequestBody,
                Value = JsonConvert.SerializeObject(model),
                ContentType = "application/json"
            };
            return apiClient.PostData<T>($"{string.Format(BaseResourceProductsVariant, idProduct)}", parameter);
        }

        /// <summary>
        ///     Update an product variant
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="idProduct"></param>
        /// <param name="idVariant"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static T UpdateProductVariant<T>(this ClientNuvemShop apiClient, long idProduct, long idVariant,
            object model)
        {
            var parameter = new Parameter
            {
                Name = "application/json",
                Type = ParameterType.RequestBody,
                Value = JsonConvert.SerializeObject(model),
                ContentType = "application/json"
            };
            return apiClient.PutData<T>($"{string.Format(BaseResourceProductsVariant, idProduct)}/{idVariant}",
                parameter);
        }

        /// <summary>
        ///     Delete an specify a product variant
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="idProduct"></param>
        /// <param name="idVariant"></param>
        /// <returns></returns>
        public static T DeleteProduct<T>(this ClientNuvemShop apiClient, long idProduct, long idVariant)
        {
            return apiClient.PutData<T>($"{string.Format(BaseResourceProductsVariant, idProduct)}/{idVariant}");
        }
    }
}