using System;
using System.Text;
using Newtonsoft.Json;
using RestSharp;

namespace NuvemShopApi.ExtensionsNuvem
{
    public static class ProductImageNuvemExtension
    {
        public const string BaseResourceProductImage = "/products/{0}/images";

        /// <summary>
        ///     Get all imagem for a product
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="idProduct"></param>
        /// <param name="urlParams"></param>
        /// <returns></returns>
        public static T GetImages<T>(this ClientNuvemShop apiClient, long idProduct,
            params Tuple<string, string>[] urlParams)
        {
            var builder = new StringBuilder();

            foreach (var p in urlParams)
                builder.Append($"{p.Item1}={p.Item2}&");
            return apiClient.GetData<T>($"{string.Format(BaseResourceProductImage, idProduct)}?{builder}");
        }

        /// <summary>
        ///     Get a specify image for a product
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="idProduct"></param>
        /// <param name="idImage"></param>
        /// <returns></returns>
        public static T GetImage<T>(this ClientNuvemShop apiClient, long idProduct, long idImage)
        {
            return apiClient.GetData<T>($"{string.Format(BaseResourceProductImage, idProduct)}/{idImage}");
        }

        /// <summary>
        ///     Create an image
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="idProduct"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static T CreateImage<T>(this ClientNuvemShop apiClient, long idProduct, object model)
        {
            var parameter = new Parameter
            {
                Name = "application/json",
                Type = ParameterType.RequestBody,
                Value = JsonConvert.SerializeObject(model),
                ContentType = "application/json"
            };
            return apiClient.PostData<T>($"{string.Format(BaseResourceProductImage, idProduct)}", parameter);
        }

        /// <summary>
        ///     Update/Change an image for a product
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="idProduct"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static T UpdateImage<T>(this ClientNuvemShop apiClient, long idProduct, object model)
        {
            var parameter = new Parameter
            {
                Name = "application/json",
                Type = ParameterType.RequestBody,
                Value = JsonConvert.SerializeObject(model),
                ContentType = "application/json"
            };
            return apiClient.PutData<T>($"{string.Format(BaseResourceProductImage, idProduct)}", parameter);
        }

        /// <summary>
        ///     Delete an image for a specify product
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiClient"></param>
        /// <param name="idProduct"></param>
        /// <param name="idImage"></param>
        /// <returns></returns>
        public static T DeleteProduct<T>(this ClientNuvemShop apiClient, long idProduct, long idImage)
        {
            return apiClient.DeleteData<T>($"{string.Format(BaseResourceProductImage, idProduct)}/{idProduct}");
        }
    }
}