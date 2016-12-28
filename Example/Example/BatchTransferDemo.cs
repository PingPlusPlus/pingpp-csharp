using System;
using System.Collections.Generic;
using System.Linq;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    class BatchTransferDemo
    {
        /// <summary>
        /// 本示例介绍批量付款对象创建、对象列表和明细查询
        /// </summary>
        /// <param name="appId"></param>
        public static void Example(string appId) 
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            list.Add(new Dictionary<string, object> 
            {
                {"account", "account01@alipay.com"},
                {"amount", 5000},
                {"name", "李狗"},
                {"open_bank", "招商银行"}
            });
            list.Add(new Dictionary<string, object> 
            {
                {"account", "account01@alipay.com"},
                {"amount", 3000},
                {"name", "伢子"},
                {"open_bank", "招商银行"},
                {"open_bank_code", "0308"}
            });

            var btParams = new Dictionary<string, object> 
            {
                {"amount",8000},
                {"app", appId},
                {"batch_no", "2016102810380013"},
                {"channel", "unionpay"},
                {"description", "Your description"},
                {"type", "b2c"},
                {"recipients", list}
            };

            var batchTranster = BatchTransfer.Create(btParams);
            Console.WriteLine("****创建批量转账 batch_transfers 对象****");
            Console.WriteLine(batchTranster);
            Console.WriteLine();

            Console.WriteLine("****查询批量转账明细 batch_transfers 对象****");
            Console.WriteLine(BatchTransfer.Retrieve(batchTranster.Id));
            Console.WriteLine();

            var listParams = new Dictionary<string, object>
            {

            };

            Console.WriteLine("****查询批量转账明细 batch_transfers 对象****");
            Console.WriteLine(BatchTransfer.List(listParams));
            Console.WriteLine();

            Console.WriteLine("****更新批量企业付款（银行卡） Batch transfer 对象****");
            Console.WriteLine(BatchTransfer.Cancel("1801612281410511500"));
            Console.WriteLine();
        }
    }
}
