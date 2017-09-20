using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvemShopApi.ExtensionsNuvem
{
    public static class StoreNuvemExtension
    {
        public const string BaseResourceCoupom = "/store";

        public static T GetStore<T>(this ClientNuvemShop apiClient)
        {
            return apiClient.GetData<T>($"{BaseResourceCoupom}");
        }
    }
}
