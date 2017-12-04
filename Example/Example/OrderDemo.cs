using System;
using System.Collections.Generic;
using Pingpp.Models;

namespace Example.Example
{
    internal class OrderDemo
    {
        /// <summary>
        /// 本示例只介绍如何创建订单（Order 对象）、支付订单、取消订单以及如何查询指定 Order 对象和 Order 列表，
        /// 至于如何将 Order 对象传递给客户端需要接入者自行处理
        /// </summary>
        public static void Example(string appId)
        {
            var orParams = new Dictionary<string, object>
            {
                {"app", appId},
                {"uid", "test_user_001"},   //uid为可选参数
                {"merchant_order_no", new Random().Next(1, 999999999).ToString()},
                {"amount", 10},
                {"currency", "cny"},
                {"client_ip", "127.0.0.1"},
                {"subject", "Your Subject"},
                {"body", "Your Body"},
                {"description", "Your description"},
                {"coupon", "300317040115550700088888"},
                {"receipt_app", appId}, //收款方应用
                {"service_app", appId}, //服务方应用
                {"royalty_users", new List<Dictionary<string,object>>{  //分润的用户列表,默认为 []，不分润
                    new Dictionary<string,object>{
                        {"user", "user_001"},
                        {"amount",1}
                    },
                    new Dictionary<string,object>{
                        {"user", "user_002"},
                        {"amount",1}
                    }
                }}
            };

            var or = Order.Create(orParams);
            Console.WriteLine("****创建 Order 对象****");
            Console.WriteLine(or);
            Console.WriteLine();
            Console.WriteLine("****支付指定 Order 对象****");
            Console.WriteLine(Order.Pay(or.Id, new Dictionary<string, object> { 
                { "charge_amount",10},
                { "channel", "alipay" },
                {"charge_order_no", "20170808100000001"}
            }));
            Console.WriteLine();
            Console.WriteLine("****查询指定 Order 对象****");
            Console.WriteLine(Order.Retrieve(or.Id));
            Console.WriteLine();
            Console.WriteLine("***查询指定 Order Charge列表***");
            Console.WriteLine(Order.ChargeList(or.Id));
            Console.WriteLine();
            Console.WriteLine("***查询指定 Order Charge对象***");
            Console.WriteLine(Order.ChargeRetrieve("2011708140000074741", "ch_OanvTSaPOqjDT00CWLbfz54C"));
            Console.WriteLine();

            Console.WriteLine("****取消指定 Order 对象****");
            Console.WriteLine(Order.Cancel(or.Id, new Dictionary<string, object> {
                {"user", or.Uid}
            }));
            Console.WriteLine();

            Console.WriteLine("****查询 Order 列表****");
            Console.WriteLine(Order.List(new Dictionary<string, object> 
            { 
                {"app", appId},
                {"paid", true}
            }));
            Console.WriteLine();
        }
    }
}
