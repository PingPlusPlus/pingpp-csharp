using System;
using System.Collections.Generic;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    internal class CustomsDemo
    {
        /// <summary>
        /// 本示例介绍如何进行海关报关
        /// </summary>
        public static void Example(string appId, string chId)
        {
            var cuParams = new Dictionary<string, object>
            {
                {"app", appId},
                {"charge", chId},
                {"channel", "upacp_pc"},
                {"trade_no", new Random().Next(1, 999999999).ToString()},
                {"customs_code", "GUANGZHOU"},
                {"amount", 1},
                {"is_split", true},
                {"sub_order_no", new Random().Next(1, 999999).ToString()},
                {"extra", new Dictionary<string, object>{
                    {"pay_account", "123456"},
                    {"certif_type", "02"},
                    {"customer_name", "customer name"},
                    {"certif_id", "62148502"},
                    {"tax_amount", 10}
                }}
            };

            Console.WriteLine("****发起海关报关请求****");
            var cu = Customs.Create(cuParams);
            Console.WriteLine(cu);
            Console.WriteLine();


            Console.WriteLine("****查询海关报关对象****");
            Console.WriteLine(Customs.Retrieve(cu.Id));
            Console.WriteLine();
        }
    }
}
