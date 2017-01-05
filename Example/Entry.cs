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
        /// 本示例只介绍如何请求支付凭据（charge 对象），以及如何查询指定 charge 对象和 charge 列表，
        /// 至于如何将 charge 对象传递给客户端需要接入者自行处理
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

                Examples(appId);

                // 应用内支付相关示例
                // InAppExamples(appId);
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
            //var ch = ChargeDemo.Example(appId);
            //RefundDemo.Example(ch.Id);
            //RedEnvelopeDemo.Example(appId);
            //TransferDemo.Example(appId);
            // VerifyDemo.Example();
            // WebhooksDemo.Example();
            //IdentificationDemo.Example(appId);
            //CustomsDemo.Example(appId, "ch_CGuj94yXPW944CWbr1Sa5q1K");
            // BatchRrefundDemo.Example(appId);
            BatchTransferDemo.Example(appId);
        }

        private static void InAppExamples(string appId)
        {
            InAppChargeDemo.Example(appId);
            // CardDemo.Example(appId);
            // CustomerDemo.Example(appId);
        }
    }
}
