using System;
using Pingpp;
using Pingpp.Models;
using System.Collections.Generic;

namespace Example.Example
{
    internal class CardInfoDemo
    {
        /// <summary>
        /// 本示例介绍银行卡信息查询
        /// </summary>
        /// <param name="appId"></param>
        public static void Example(String appId)
        {
            var createParams = new Dictionary<string, object>
            {
                {"app",appId},
                {"bank_account", "6214888888888888"}
            };

            Console.WriteLine("**** 银行卡信息查询 ****");
            Console.WriteLine(CardInfo.Query(createParams));
            Console.WriteLine();
        }
    }
}
