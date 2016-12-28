using System;
using System.Collections.Generic;
using System.Linq;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    internal class BatchRrefundDemo
    {
        public static void Example(string appId) 
        {
            var reParams = new Dictionary<string, object> 
            {
                {"app", appId},
                {"batch_no", "batchrefund2016113"},
                {"charges", new List<string>
                    {
                        "ch_fn1WXHDur5qPvfffbL1uXnv9",
                        "ch_1OmvXTzr9WnPPKuf50iH4aP0"
                    }
                },
                {"description", "Batch refund description."},
                {"metadata", null}
            };

            var batchRefund = BatchRefund.Create(reParams);
            Console.WriteLine("****创建批量退款 Batch Refund 对象****");
            Console.WriteLine(batchRefund);
            Console.WriteLine();

            Console.WriteLine("****查询 Batch refund 对象****");
            Console.WriteLine(BatchRefund.Retrieve(batchRefund.Id));
            Console.WriteLine();

            Console.WriteLine("****查询 Batch refund 对象列表****");
            var listParams = new Dictionary<string, object>
            {
                {"app", appId},
                {"page", 1},
                {"per_page", 10}
            };
            Console.WriteLine(BatchRefund.List(listParams));
            Console.WriteLine();
        }
    }
}
