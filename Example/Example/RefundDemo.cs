using System;
using System.Collections.Generic;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    public class RefundDemo
    {
        /// <summary>
        /// 本示例只介绍如何发起退款，以及如何查询指定 refund 对象和 refund 列表，
        /// </summary>
        public static Refund Example(string chId)
        {
            //退款请求参数，这里只列出必填参数，可选参数请参考 https://pingxx.com/document/api#api-r-new
            var reParams = new Dictionary<string, object>
            {
                // 退款的金额, 单位为对应币种的最小货币单位，例如：人民币为分（如退款金额为 1 元，此处请填 100）。必须小于等于可退款金额，默认为全额退款
                {"amount", 100},
                {"description", "Refund Reason"}
            };

            var re = Refund.Create(chId, reParams);
            Console.WriteLine("****发起交易请求创建 refund 对象****");
            Console.WriteLine(re);
            Console.WriteLine();

            Console.WriteLine("****查询指定 refund 对象****");
            Console.WriteLine(Refund.Retrieve(chId, re.Id));
            Console.WriteLine();

            Console.WriteLine("****查询 refund 列表****");
            Console.WriteLine(Refund.List(chId, new Dictionary<string, object> {{"limit", 3}}));
            Console.WriteLine();

            return re;
        }
    }
}
