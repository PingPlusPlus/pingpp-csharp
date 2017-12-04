using System;
using System.Collections.Generic;
using System.Linq;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    internal class BalanceDemo
    {
        /// <summary>
        /// 
        /// 本示例介绍对余额提现和查看用户余额明细对象/对象列表
        /// 余额的消费、退款请查看 OrderDemo 示例
        /// 查看用户当前余额请使用查看 User 对象接口
        /// 
        /// </summary>
        public static void Example(string appId)
        {
            var uid = "test_user_001";
            var orParams = new Dictionary<string, object>
            {
                {"app", appId},
                {"uid", uid},
                {"merchant_order_no", new Random().Next(1, 999999999)},
                {"channel", "wx"}, // 充值接口需要设置支付渠道
                {"amount", 1},
                {"currency", "cny"},
                {"client_ip", "127.0.0.1"},
                {"subject", "Your Subject"},
                {"body", "Your Body"},
                {"description", "Your description"},
            };

            var wdParams = new Dictionary<string, object>
            {
                {"amount", 1},
                {"order_no", "20160829133002"},
                {"description", "withdraw request"},
                {"extra", new Dictionary<string, object>
                {
                    {"card_number", "6225210207073918"},
                    {"user_name", "姓名"},
                    {"open_bank_code", "0102"},
                    {"prov", "上海"},
                    {"city", "上海"}
                }
                },
            };
            Console.WriteLine("****创建提现 Withdrawal 对象（发起提现申请）****");
            var wd = Withdrawal.Request(appId, wdParams);
            Console.WriteLine(wd);
            Console.WriteLine();

            Console.WriteLine("****提现完成 Withdrawal 对象****");
            Console.WriteLine(Withdrawal.Confirm(appId, wd.Id));
            Console.WriteLine();

            Console.WriteLine("****查看用户交易明细 Balance Transaction 对象列表****");
            var balanceList = BalanceTransaction.List(appId);
            Console.WriteLine(balanceList);
            Console.WriteLine();

            Console.WriteLine("****查看用户交易明细 Balance Transaction 对象****");
            Console.WriteLine(BalanceTransaction.Retrieve(appId, balanceList.Data.First().Id));
            Console.WriteLine();

        }
    }
}
