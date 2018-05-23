using System;
using System.Collections.Generic;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    internal class AgreementDemo
    {
        /// <summary>
        /// 本示例只介绍如何请求支付凭据（charge 对象），以及如何查询指定 charge 对象和 charge 列表，
        /// 至于如何将 charge 对象传递给客户端需要接入者自行处理
        /// </summary>
        public static void Example(string appId)
        {

            Console.WriteLine("**** 创建签约示例 ****");
            var param = new Dictionary<string, object> {
                {"app", appId},
                {"contract_no", randomStr(10)},
                {"channel", "qpay"},
                {"extra", new Dictionary<string, object>{
                    {"display_account", "签约测试"}
                }},
                {"metadata", new Dictionary<string, object>{}}
            };

            var agreement = Agreement.Create(param);
            Console.WriteLine(agreement);
            Console.WriteLine();

            Console.WriteLine("****查询 agreement 对象****");
            Console.WriteLine(Agreement.Retrieve(agreement.Id));
            Console.WriteLine();

            Console.WriteLine("****解除签约 agreement 对象****");
            Console.WriteLine(Agreement.Cancel(agreement.Id));
            Console.WriteLine();


            Console.WriteLine("****查询 agreement 列表****");
            Dictionary<string, object> listParams = new Dictionary<string, object>{
                {"app", appId}, // 必填 签约使用的 app id
                {"per_page", 10},  //限制有多少对象可以被返回，限制范围是从 1-100 项，默认是 10 项。
            };
            Console.WriteLine(Agreement.List(listParams));
        }

        public static String randomStr(int length)
        {
            string result = "";
            System.Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                result += random.Next(10).ToString();
            }
            return result;
        }
    }
}
