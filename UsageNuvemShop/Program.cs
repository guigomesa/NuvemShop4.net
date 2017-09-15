﻿using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuvemShopApi;
using RestSharp;
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
                        try
                        {
                            var urlPutVariant = $"/products/{r.id}/variants/{variant.id}";

                            variant.stock = 42;

                            var parameters = new List<RestSharp.Parameter>
                            {
                                new Parameter
                                {
                                    Name = "application/json",
                                    Type = ParameterType.RequestBody,
                                    Value = variant
                                }
                            };
                            var clientPut = new ClientNuvemShop("guigomesa@outlook.com", "Test NuvemShop", GetFullCredentials());
                            var retornPutVariant = clientPut.PutData<dynamic>(urlPutVariant, parameters.ToArray());
                            Console.WriteLine($"Variacao sku {variant.sku} foi alterada para estoque {variant.stock}");
                        }
                        catch (NuvemShopApi.ApiNuvemShopException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }


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
