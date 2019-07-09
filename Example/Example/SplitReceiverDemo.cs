using System;
using System.Collections.Generic;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    internal class SplitReceiverDemo
    {
        public static void Example(string appId)
        {
            Console.WriteLine("****创建 split_receiver　****");
            Dictionary<string, object> createParams = new Dictionary<string, object> { 
                {"app", appId},
                {"type", "MERCHANT_ID"},
                {"account", "190001001"},
                {"name", "示例商户全称"},
                {"channel", "wx_pub_qr"}
            };
            Console.WriteLine(SplitReceiver.Create(createParams));
            Console.WriteLine();

            Console.WriteLine("****查询 split_receiver 列表****");
            Dictionary<string, object> listParams = new Dictionary<string, object> { 
                {"app", appId},
                {"page", 1}
            };
            Console.WriteLine(SplitReceiver.List(listParams));
            Console.WriteLine();

            Console.WriteLine("****查询 split_receiver ****");
            Console.WriteLine(SplitReceiver.Retrieve("recv_1fRbIszF3tAuPy"));
            Console.WriteLine();

            Console.WriteLine("****删除 split_receiver ****");
            Console.WriteLine(SplitReceiver.Delete("recv_1fRbIszF3tAuPy"));
            Console.WriteLine();
        }
    }
}
