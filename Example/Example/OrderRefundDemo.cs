using System;
using System.Collections.Generic;
using Pingpp.Models;

namespace Example.Example
{
    public class OrderRefundDemo
    {
        /// <summary>
        /// 本示例介绍如何发起 Order 退款，以及如何查询指定 Order Refund 对象和 Refund 列表，
        /// </summary>
        public static void Example(string orId)
        {
            var reParams = new Dictionary<string, object>
            {
               {"description", "Refund Reason"},
               {"refund_mode", "to_source"},    //退款模式。原路退回：to_source，退至余额：to_balance。默认为原路返回。
               //{"royalty_users", new List<Dictionary<string,object>>{  //退分润的用户列表,默认为 []，不分润
               //     new Dictionary<string,object>{
               //         {"user", "user_001"},
               //         {"amount_refunded",1}
               //     },
               //     new Dictionary<string,object>{
               //         {"user", "user_002"},
               //         {"amount_refunded",1}
               //     }
               // }},
            };

            var re = OrderRefund.Create(orId, reParams);
            Console.WriteLine("****创建 order refund 对象****");
            Console.WriteLine(re);
            Console.WriteLine();

            Console.WriteLine("****查询指定 order refund 对象****");
            Console.WriteLine(OrderRefund.Retrieve(orId, "re_vjz1a1DCufb5n9erLK48SGC0"));
            Console.WriteLine();

            Console.WriteLine("****查询 order refund 列表****");
            Console.WriteLine(OrderRefund.List(orId));
            Console.WriteLine();
        }
    }
}
