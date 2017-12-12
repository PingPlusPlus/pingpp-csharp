using System;
using Example.Example;
using Example.InAppExample;
using Pingpp;
using Pingpp.Exception;

namespace Example
{
    internal class Entry
    {
        /// <summary>
        /// 作为示例的入口，你可以使用示例的配置参数或者更改为你在 Ping++ 注册后从管理平台中获得的配置参数
        /// 示例分为 3 类：收款/付款类、用户账户类、应用内支付类，你可以通过取消/增加注释的方式根据你的业务场景选择需要调试的接口
        /// 
        /// </summary>
        private static void Main(string[] args)
        {
            try
            {
                //设置 Api Key, 可换成你自己的 test secret key 或者 live secret key
                Pingpp.Pingpp.SetApiKey("sk_test_ibbTe5jLGCi5rzfH4OqPW9KC");

                //设置请求签名密钥，密钥对需要你自己用 openssl 工具生成，同时把配对的公钥填写到 https://dashboard.pingxx.com
                Pingpp.Pingpp.SetPrivateKeyPath(@"../../your_rsa_private_key.pem");

                //设置 App Id, 可以换成自己的应用 Id
                var appId = "app_1Gqj58ynP0mHeX1q";

                // 收款/付款类相关示例
                Examples(appId);

                // 用户账户类相关示例
                //AccountExamples(appId);

                // 应用内支付类相关示例
                //InAppExamples(appId);
            }
            catch (PingppException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            Console.ReadKey();
        }

        private static void Examples(string appId)
        {
            ChargeDemo.Example(appId);
            RedEnvelopeDemo.Example(appId);
            TransferDemo.Example(appId);
            VerifyDemo.Example();
            WebhooksDemo.Example();
            IdentificationDemo.Example(appId);
            CustomsDemo.Example(appId, "ch_avbPyT4aDCe1r9W1eHfv1SuP");
            //批量退款示例
            BatchRefundDemo.Example(appId);
        }

        private static void AccountExamples(string appId)
        {
            //Order 示例
            OrderDemo.Example(appId);
            //Order退款示例
            OrderRefundDemo.Example("2011708140000074741");
            //User 对象相关示例
            UserDemo.Example(appId);
            //用户余额明细示例
            BalanceTransactionDemo.Example(appId);
            //转账 示例
            TransferDemo.Example(appId);
            //余额提现 示例
            WithdrawalDemo.Example(appId);
            //优惠券 示例
            CouponDemo.Example(appId);
            //批量转账 示例
            BatchTransferDemo.Example(appId);
            //批量体现示例
            BatchWithdrawalDemo.Example(appId);
            //子商户示例
            SubAppDemo.Example(appId);
            //子商户渠道设置示例
            ChannelDemo.Example(appId, "app_jXH8WHCCSGC0GCGu");
            //结算账号示例
            SettleAccountDemo.Example(appId);
            //分润示例
            RoyaltyDemo.Example();
            //分润结算明细示例
            RoyaltyTransactionDemo.Example();
            //分润结算示例
            RoyaltySettlementDemo.Example();
            OrderDemo.Example(appId);
             var user = UserDemo.Example(appId);
             BalanceDemo.Example(appId);
             CouponDemo.Example(appId);
            //余额充值接口示例
            RechargeDemo.Example(appId);

            //余额赠送示例
            BalanceBonusDemo.Example(appId);
            //余额转账示例
            BalanceTransferDemo.Example(appId);
            //分润模板示例
            RoyaltyTemplateDemo.Example(appId);
        }

        private static void InAppExamples(string appId)
        {
            InAppChargeDemo.Example(appId);
            // CardDemo.Example(appId);
            // CustomerDemo.Example(appId);
        }
    }
}
