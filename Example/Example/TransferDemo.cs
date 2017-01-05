using System;
using System.Collections.Generic;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    public class TransferDemo
    {
        ///<summary>
        ///本示例只介绍如何发送企业付款请求，以及如何查询指定 Transfer 对象和 Transfer 列表，
        ///获取到了 Transfer 对象后，不需要客户端做任何处理，指定的用户会在微信客户端收到企业付款消息
        /// </summary>

        public static Transfer Example(string appId)
        {
            var trParams = new Dictionary<string, object>
            {
                {"order_no", new Random().Next(1, 999999999)},
                {"amount", 100},
                {"channel", "wx_pub"},
                {"currency", "cny"},
                {"type", "b2c"},
                {"recipient", "Your recipient id"},
                {"description", "Description"},
                {"app", new Dictionary<string, string> {{"id", appId}}},
                {
                    "extra", new Dictionary<string, object>
                    {
                        {"user_name", "User Name"},
                        {"force_check", false}
                    }
                }
            };

            var tr = Transfer.Create(trParams);
            Console.WriteLine("****创建 Transfer 对象****");
            Console.WriteLine(tr);
            Console.WriteLine();

            Console.WriteLine("****查询指定 Transfer 对象****");
            Console.WriteLine(Transfer.Retrieve(tr.Id));
            Console.WriteLine();

            Console.WriteLine("****查询 Transfer 对象列表****");
            Console.WriteLine(Transfer.List(new Dictionary<string, object> {{"limit", 3}}));
            Console.WriteLine();

            Console.WriteLine("****更新 Transfer 对象****");
            Console.WriteLine(Transfer.Cancel(tr.Id));
            Console.WriteLine();

            return tr;
        }
    }

}
