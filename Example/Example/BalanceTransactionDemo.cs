using System;
using System.Collections.Generic;
using System.Linq;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    internal class BalanceTransactionDemo
    {
        /// <summary>
        /// 本示例展示 用户账户交易明细 查询列表,明细
        /// </summary>
        /// <param name="appId"></param>
        public static void Example(string appId)
        {
            var listParams = new Dictionary<string, object> 
            {
                {"page", 1},
                {"per_page", 10},
            };

            var list = BalanceTransaction.List(appId, listParams);
            Console.WriteLine("****查询 balance_transactions 列表****");
            Console.WriteLine(list);
            Console.WriteLine();


            Console.WriteLine("****查询 balance_transactions 明细****");
            Console.WriteLine(BalanceTransaction.Retrieve(appId, "310217032213081700008201"));
            Console.WriteLine();
        }
    }
}
