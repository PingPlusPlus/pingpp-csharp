using System;
using System.Collections.Generic;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    internal class ChargeDemo
    {
        /// <summary>
        /// 本示例只介绍如何请求支付凭据（charge 对象），以及如何查询指定 charge 对象和 charge 列表，
        /// 至于如何将 charge 对象传递给客户端需要接入者自行处理
        /// </summary>
        public static Charge Example(string appId)
        {
            //交易请求参数，这里只列出必填参数，可选参数请参考 https://pingxx.com/document/api#api-c-new
            var chParams = new Dictionary<string, object>
            {
                {"order_no", new Random().Next(1, 999999999)},
                {"amount", 1},
                {"channel", "wx"},
                {"currency", "cny"},
                {"subject", "Your Subject"},
                {"body", "Your Body"},
                {"client_ip", "127.0.0.1"},
                {"app", new Dictionary<string, string> {{"id", appId}}}
            };

            var ch = Charge.Create(chParams);
            Console.WriteLine("****发起交易请求创建 charge 对象****");
            Console.WriteLine(ch);
            Console.WriteLine();

            Console.WriteLine("****查询指定 charge 对象****");
            Console.WriteLine(Charge.Retrieve(ch.Id));
            Console.WriteLine();

            Console.WriteLine("****查询 charge 列表****");
            Console.WriteLine(Charge.List(appId, new Dictionary<string, object> {{"limit", 3}}));
            Console.WriteLine();

            return ch;
        }
    }
}
