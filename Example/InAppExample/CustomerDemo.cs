using System;
using System.Collections.Generic;
using Pingpp.Models;

namespace Example.InAppExample
{
    public class CustomerDemo
    {
        /// <summary>
        /// 本示例只介绍如何新建 customer，以及如何查询指定 customer 对象和 customer 列表，
        /// 至于如何将 customer 对象传递给客户端需要接入者自行处理
        /// </summary>

        public static Customer Example(string appId)
        {
            var param = new Dictionary<string, object>
            {
                {"source", "tok_xxxxxxxxxxxxx"},
                {"description", "Description"},
                {"email", "xxx@xxx.com"},
                {"app", appId},
                {"sms_id", "sms_xxxxxxxxxx"},
                {"sms_code", "123456"}
            };

            var cus = Customer.Create(param);
            Console.WriteLine("****创建 customer 对象****");
            Console.WriteLine(cus);
            Console.WriteLine();

            Console.WriteLine("****查询指定 customer 对象****");
            Console.WriteLine(Customer.Retrieve(cus.Id));
            Console.WriteLine();

            Console.WriteLine("****查询 Cutomer 列表****");
            Console.WriteLine(Customer.List(new Dictionary<string, object> { { "limit", 3 } }));
            Console.WriteLine();

            Console.WriteLine("****更新 Cutomer 对象****");
            Console.WriteLine(Customer.Update(cus.Id, new Dictionary<string, object> { { "description", "Description" } }));
            Console.WriteLine();

            // Console.WriteLine("****删除 Cutomer 对象****");
            // Console.WriteLine(Customer.Delete(cus.Id));
            // Console.WriteLine();

            return cus;
        }
    }
}


