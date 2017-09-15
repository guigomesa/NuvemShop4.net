using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuvemShopApi;
using RestSharp.Extensions;

namespace UsageNuvemShop
{
    class Program
    {
        private static IEnumerable<string> temp = new List<string>();
        static void Main(string[] args)
        {
            var apiNuvem = new ClientNuvemShop("guigomesa@outlook.com", "Test NuvemShop", GetFullCredentials());

            var retorno = apiNuvem.GetData<dynamic>("/products");

            foreach (var r in retorno)
            {
                Console.WriteLine($"Id: {r.id} - Name: {r.name.pt}");
                //Console.WriteLine($"Description: {r.description.pt}");
                Console.WriteLine("= = = = = = = = = = = = = = = = = ");
                if (r.variants is IEnumerable)
                {
                    foreach (var variant in r.variants)
                    {
                        if (variant.sku == null && variant.stock == null) continue;
                        Console.WriteLine($"SKU: {variant.sku} - Stock: {variant.stock}");
                    }
                }
            }

            Console.WriteLine("Consulta feita");
            Console.ReadLine();
        }

        internal static CredentialsNuvemShop GetFullCredentials()
        {
            return new CredentialsNuvemShop
            {
                AccessToken = "access-token",
                AppId = "123456",
                AppSecret = "app-secret",
                StoreId = "987"
            };
        }
    }
}
