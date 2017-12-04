using System;
using System.Collections.Generic;
using System.Linq;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    /// <summary>
    /// Batch Refunds 批量退款示例
    /// </summary>
    public class BatchRefundDemo
    {
        public static void Example(string appId)
        {
            List<Dictionary<string, object>> batchRefundCharges = new List<Dictionary<string, object>>();
            batchRefundCharges.Add(new Dictionary<string, object>{
                {"charge", "ch_b9OerHivrXHGW1iT4GSejTu1"},
                {"amount", 1},
                {"description", "Batch refund description"}
            });
            batchRefundCharges.Add(new Dictionary<string, object>{
                {"charge", "ch_Sir5G0vnrDCCyLCCKCTmrjDG"},
                {"amount", 1},
                {"description", "Batch refund description"}
            });

            //batchRefundCharges.Add(new Dictionary<string, object>{
            //    {"charge", "ch_Sir5G0vnrDCCyLCCKCTmrjDG"},
            //    {"amount", 1},
            //    {"description", "Batch refund description"},
            //    {"funding_source", "unsettled_funds "} // 退款资金来源。unsettled_funds：使用未结算资金退款；recharge_funds：使用可用余额退款。该参数仅适用于微信渠道，包括 wx , wx_pub , wx_pub_qr 三个渠道；该参数仅在请求退款，传入该字段时返回
            //});

            var reParams = new Dictionary<string, object> 
            {
                {"app", appId},
                {"batch_no", "batchrefund2016119"},
                {"charges", batchRefundCharges},
                {"description", "Batch refund description."},
                {"metadata", null}
            };

            Console.WriteLine("****创建批量退款 Batch Refund 对象****");
            var batchRefund = BatchRefund.Create(reParams);
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
