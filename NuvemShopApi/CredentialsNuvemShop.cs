using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvemShopApi
{
    public interface ICredentialsNuvemShop
    {
        string AppId { get; set; }
        string AccessToken { get; set; }
        string StoreId { get; set; }
        string AppSecret { get; set; }
        string ToString();
    }

    public class CredentialsNuvemShop : ICredentialsNuvemShop
    {
        public string AppId { get; set; }
        public string AccessToken { get; set; }
        public string StoreId { get; set; }
        public string AppSecret { get; set; }
        

        public CredentialsNuvemShop(string storeId, String accessToken)
        {
            this.StoreId = storeId;
            this.AccessToken = accessToken;
        }

        public CredentialsNuvemShop(long storeId, string accessToken)
        {
            this.StoreId = storeId.ToString();
            this.AccessToken = accessToken;
        }
        public CredentialsNuvemShop() { }

        public override string ToString()
        {
            return $"AppId: {AppId} - AccessToken: {AccessToken} - StoreId: {StoreId} - ApSecret: {AppSecret}";
        }

        public static CredentialsNuvemShop PrepareCredential(string appId, string appSecret)
        {
            var retorno = new CredentialsNuvemShop
            {
                AppId =  appId,
                AppSecret = appSecret
            };
            return retorno;
        }
    }
}
