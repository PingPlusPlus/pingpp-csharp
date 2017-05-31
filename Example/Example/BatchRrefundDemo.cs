using System;
using System.Collections.Generic;
using System.Linq;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    internal class BatchRrefundDemo
    {
        /// <summary>
        /// 本示例介绍批量Batch Refunds 批量退款创建，查询对象，查询对象列表
        /// </summary>
        /// <param name="appId"></param>
        public static void Example(string appId) 
        {
            var reParams = new Dictionary<string, object> 
            {
                {"app", appId},
                //批量退款批次号，3-24位，允许字母和英文
                {"batch_no", "batchrefund2016113"},
                //需要退款的  charge id 列表，一次最多 100 个
                {"charges", new List<string>
                    {
                        "ch_fn1WXHDur5qPvfffbL1uXnv9",
                        "ch_1OmvXTzr9WnPPKuf50iH4aP0"
                    }
                },
                //批量退款详情，最多 255 个 Unicode 字符
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
                {"app", appId}, //批量退款对应的 app 对象 ID，如何获取App ID请查看： https://help.pingxx.com/article/198599/
                {"page", 1},    //页码，取值范围：1~1000000000；默认值为"1"
                {"per_page", 10} //每页数量，取值范围：1～100；默认值为"20"
            };
            Console.WriteLine(BatchRefund.List(listParams));
            Console.WriteLine();
        }
    }
}
