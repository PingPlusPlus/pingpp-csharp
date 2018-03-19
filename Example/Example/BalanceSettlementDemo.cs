using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    internal class BalanceSettlementDemo
    {
        /// <summary>
        /// 本示例展示 余额结算 查询列表,明细
        /// </summary>
        /// <param name="appId"></param>
        public static void Example(string appId) 
        {
            Console.WriteLine("****查询批量转账明细 balance_settlement 对象****");
            Console.WriteLine(BalanceSettlement.Retrieve(appId, "670180228410834298880001"));
            Console.WriteLine();

            var listParams = new Dictionary<string, object>
            {
                {"page", 1},    //页码，取值范围：1~1000000000；默认值为"1"
                {"per_page", 10},    //每页数量，取值范围：1～100；默认值为"10",
            };

            Console.WriteLine("****查询余额结算 balance_settlement 对象列表****");
            Console.WriteLine(BalanceSettlement.List(appId, listParams));
            Console.WriteLine();
        }
    }
}
