using System;
using System.Collections.Generic;
using System.Linq;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    /// <summary>
    /// recharge 示例
    /// </summary>
    internal class RechargeDemo
    {
        public static void Example(string appId) 
        {
            var createParams = new Dictionary<string, object> 
            {
                {"user", "user_test_01"},    //充值目标用户 ID。
                //{"user_fee", 0},            //	用户充值收取的手续费，单位分，不得大于 amount，不可和 balance_bonus[amount] 同时传，默认 0。
                {"description", "Your Recharge description"}, //描述。
                {"metadata", new Dictionary<string,object>{}},
                {"balance_bonus", new Dictionary<string,object>{
                    {"amount",100}  //充值额外赠送的余额，单位分，不可和 user_fee 同时传，默认 0。
                }},
                {"charge", new Dictionary<string,object>{
                    {"amount", 100},            //用户实际支付金额，单位分。
                    {"channel", "alipay_qr"},   //支付使用的第三方支付渠道。
                    {"order_no", new Random().Next(1, 999999999).ToString()},   //商户订单号，适配每个渠道对此参数的要求，必须在商户系统内唯一。
                    {"subject", "Your subject"},    //充值标题，该参数最长为 32 个 Unicode 字符。银联全渠道（ upacp / upacp_wap / upacp_pc）限制在 32 个字节。
                    {"body", "Your body"},           //充值描述信息，该参数最长为 128 个 Unicode 字符，yeepay_wap 对于该参数长度限制为 100 个 Unicode 字符。
                    {"time_expire", "1502766839"},  //支付失效时间，用 Unix 时间戳表示。时间范围在支付创建后的 5 分钟到 1 天，默认为 1 天，创建时间以 Ping++ 服务器时间为准。 微信对该参数的有效值限制为 2 小时内；银联对该参数的有效值限制为 1 小时内。
                    {"client_ip", "127.0.0.1"},     //客户端的 IP，IPv4，默认 127.0.0.1。
                    {"extra", new Dictionary<string,object>{ }},
                }}
            };

            var recharge = Recharge.Create(appId, createParams);
            Console.WriteLine("****创建充值 Recharge 对象****");
            Console.WriteLine(recharge);
            Console.WriteLine();

            Console.WriteLine("**** 查询充值Recharge对象 ****");
            Console.WriteLine(Recharge.Retrieve(appId, "221170814443320238080000"));
            Console.WriteLine();

            Console.WriteLine("**** 查询充值Recharge对象列表 ****");
            Console.WriteLine(Recharge.List(appId, new Dictionary<string, object> 
            {
                {"page", 1},
                {"per_page", 10}
            }));
            Console.WriteLine();


            Console.WriteLine("**** 创建充值退款 ****");
            Console.WriteLine(RechargeRefund.Create(appId, "221170814443320238080000", new Dictionary<string, object> 
            {
                {"description", "Your Description"},
                {"metadata", new Dictionary<string,object>{}}
            }));


            Console.WriteLine("**** 查询充值退款对象 ****");
            Console.WriteLine(RechargeRefund.Retrieve(appId, "221170814443320238080000", "re_Cuvnn9nnb104W5ebf9LevHOS"));
            Console.WriteLine();

            Console.WriteLine("**** 查询充值退款列表 ****");
            Console.WriteLine(RechargeRefund.List(appId, "221170814443320238080000"));
            Console.WriteLine();
        }
    }
}
