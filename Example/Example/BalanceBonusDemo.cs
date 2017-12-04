using System;
using System.Collections.Generic;
using System.Linq;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    internal class BalanceBonusDemo
    {
        /// <summary>
        /// 本示例介绍用户余额赠送创建,查询,/查询对象列表
        /// </summary>
        /// <param name="appId"></param>
        public static void Example(String appId)
        {
            var createParams = new Dictionary<string, object>
            {
                {"amount",10},
                {"description", "Your Description"},
                {"user", "user_test_02"},
                {"order_no", new Random().Next(1, 999999999).ToString()}
            };
            Console.WriteLine("*** 创建 balance_bonus 对象***");
            Console.WriteLine(BalanceBonus.Create(appId, createParams));
            Console.WriteLine();

            Console.WriteLine("*** 查询 balance_bonus 对象 ***");
            Console.WriteLine(BalanceBonus.Retrieve(appId, "651170811577777244160000"));
            Console.WriteLine();

            Console.WriteLine("*** 查询 balance_bonus 对象列表 ***");
            Console.WriteLine(BalanceBonus.List(appId, new Dictionary<string, object>
            {
                {"page", 1},
                {"per_page", 10}
            }
            ));
            Console.WriteLine();
        }
    }
}
