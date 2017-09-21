using System;
using System.Text;
using Newtonsoft.Json;
using RestSharp;

namespace NuvemShopApi.ExtensionsNuvem
{
    public static class WebhookNuvemExtension
    {
        public const string BaseResourceWebHook = "/webhooks";


        public static T GetWebHook<T>(this ClientNuvemShop apiClient, params Tuple<string, string>[] urlParams)
        {
            var builder = new StringBuilder();

            foreach (var p in urlParams)
                builder.Append($"{p.Item1}={p.Item2}&");
            return apiClient.GetData<T>($"{BaseResourceWebHook}?{builder}");
        }

        public static T GetWebHook<T>(this ClientNuvemShop apiClient, long idWebHook)
        {
            return apiClient.GetData<T>($"{BaseResourceWebHook}/{idWebHook}");
        }

        public static T CreateWebHook<T>(this ClientNuvemShop apiClient, object model)
        {
            var parameter = new Parameter
            {
                Name = "application/json",
                Type = ParameterType.RequestBody,
                Value = JsonConvert.SerializeObject(model),
                ContentType = "application/json"
            };
            return apiClient.PostData<T>($"{BaseResourceWebHook}", parameter);
        }

        public static T UpdateWebHook<T>(this ClientNuvemShop apiClient, long idWebhook, object model)
        {
            var parameter = new Parameter
            {
                Name = "application/json",
                Type = ParameterType.RequestBody,
                Value = JsonConvert.SerializeObject(model),
                ContentType = "application/json"
            };
            return apiClient.PutData<T>($"{BaseResourceWebHook}/{idWebhook}", parameter);
        }

        public static T DeleteWebHook<T>(this ClientNuvemShop apiClient, long idWebhook)
        {
            return apiClient.DeleteData<T>($"{BaseResourceWebHook}/{idWebhook}");
        }
    }
}