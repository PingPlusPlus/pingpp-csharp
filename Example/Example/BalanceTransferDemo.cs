using System;
using System.Collections.Generic;
using System.Linq;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    internal class BalanceTransferDemo
    {
        /// <summary>
        /// 本示例介绍用户余额转账创建,查询,/查询对象列表
        /// </summary>
        public static void Example(string appId)
        {
            var createParams = new Dictionary<string, object>
            {
                {"amount",10},              //用户收到转账的余额，单位：分
                {"user_fee", 0},            //向发起转账的用户额外收取的手续费，单位：分
                {"user", "user_test_01"},   //发起转账的用户 ID（可以是 customer 或 business，但不能填 0）
                {"recipient", "user_test_02"},  //接收转账的用户 ID（可以是 customer 或 business，可以为 0）
                {"order_no", new Random().Next(1, 999999999).ToString()},   //商户订单号，必须在商户系统内唯一
                {"description", "Your Description"},    //	描述
                {"metadata", new Dictionary<string,object>{}}   //metadata 元数据
            };
            var balanceTransfer = BalanceTransfer.Create(appId, createParams);
            Console.WriteLine("*** 创建 balance_transfer 对象***");
            Console.WriteLine(balanceTransfer);
            Console.WriteLine();

            Console.WriteLine("*** 查询 balance_transfer 对象 ***");
            Console.WriteLine(BalanceTransfer.Retrieve(appId, balanceTransfer.Id));
            Console.WriteLine();

            Console.WriteLine("*** 查询 balance_transfer 对象列表 ***");
            Console.WriteLine(BalanceTransfer.List(appId, new Dictionary<string, object> 
            {
                {"page", 1},
                {"per_page", 10}
            }
            ));
            Console.WriteLine();
        }
    }
}
