using System;
using System.Collections.Generic;
using System.Linq;
using Pingpp;
using Pingpp.Models;


namespace Example.Example
{
    /// <summary>
    /// 本示例介绍查询分润结算明细对象列表查询和列表查询接口
    /// </summary>
    class RoyaltyTransactionDemo
    {
        public static void Example() 
        {
            
            var listParam = new Dictionary<string, object> {
                {"page", 1},
                {"per_page", 10}
            };
            Console.WriteLine("**** 查询royalty_transaction 对象 ****");
            Console.WriteLine(RoyaltyTransaction.List(listParam));

            Console.WriteLine("**** 查询royalty_transaction 列表 ****");
            Console.WriteLine(RoyaltyTransaction.Retrieve("441170321101800003"));
            Console.WriteLine();
        }
    }
}
