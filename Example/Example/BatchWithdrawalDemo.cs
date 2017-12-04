using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    internal class BatchWithdrawalDemo
    {
        public static void Example(string appId) 
        {
            var batchwrParams = new Dictionary<string, object> 
            {
                {"withdrawals", new List<string>{
                    "1701611150302360654",
                    "1701611151015078981"}}
            };
            var batchWithDrawal = BatchWithdrawal.Create(appId, batchwrParams);
            Console.WriteLine("****创建批量提现确认 batch_withdrawals 对象****");
            Console.WriteLine(batchWithDrawal);
            Console.WriteLine();

            Console.WriteLine("****查询批量提现确认 batch_withdrawals 对象****");
            Console.WriteLine(BatchWithdrawal.Retrieve(appId, "1911612011126056780"));
            Console.WriteLine();

            //status 参数可选：提现状态，已申请：created，处理中：pending，完成：succeeded，失败：failed，取消：canceled
            var listParams = new Dictionary<string, object> 
            {
                {"page", 1},
                {"per_page", 15},
                {"status","created"}
            };
            Console.WriteLine("****批量提现列表查询****");
            Console.WriteLine(BatchWithdrawal.List(appId, listParams));
            Console.WriteLine();
        }
    }
}
