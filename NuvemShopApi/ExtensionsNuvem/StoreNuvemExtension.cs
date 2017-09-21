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