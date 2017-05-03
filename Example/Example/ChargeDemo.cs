using System;
using System.Collections.Generic;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    internal class ChargeDemo
    {
        /// <summary>
        /// 本示例只介绍如何请求支付凭据（charge 对象），以及如何查询指定 charge 对象和 charge 列表，
        /// 至于如何将 charge 对象传递给客户端需要接入者自行处理
        /// </summary>
        public static void Example(string appId)
        {

            Console.WriteLine("****发起交易请求创建 charge 对象-alipay 渠道****");
            Console.WriteLine(alipayCharge(appId));
            Console.WriteLine();

            Console.WriteLine("****发起交易请求创建 charge 对象- alipay_pc_direct 渠道****");
            Console.WriteLine(alipay_pc_directCharge(appId));
            Console.WriteLine();

            Console.WriteLine("****发起交易请求创建 charge 对象-  applepay_upacp 渠道****");
            Console.WriteLine(applepay_upacpCharge(appId));
            Console.WriteLine();

            Console.WriteLine("****发起交易请求创建 charge 对象- bfb_wap 渠道****");
            Console.WriteLine(bfb_wapCharge(appId));
            Console.WriteLine();

            Console.WriteLine("****发起交易请求创建 charge 对象- cmb_wallet 渠道****");
            Console.WriteLine(cmb_walletCharge(appId));
            Console.WriteLine();

            Console.WriteLine("****发起交易请求创建 charge 对象- fqlpay_wap 渠道****");
            Console.WriteLine(fqlpay_wapCharge(appId));
            Console.WriteLine();

            Console.WriteLine("****发起交易请求创建 charge 对象- jdpay_wap 渠道****");
            Console.WriteLine(jdpay_wapCharge(appId));
            Console.WriteLine();

            Console.WriteLine("****发起交易请求创建 charge 对象- mmdpay_wap 渠道****");
            Console.WriteLine(mmdpay_wapCharge(appId));
            Console.WriteLine();

            Console.WriteLine("****发起交易请求创建 charge 对象-qgbc_wap 渠道****");
            Console.WriteLine(qgbc_wapCharge(appId));
            Console.WriteLine();

            Console.WriteLine("****发起交易请求创建 charge 对象- qpay 渠道****");
            Console.WriteLine(qpayCharge(appId));
            Console.WriteLine();

            Console.WriteLine("****发起交易请求创建 charge 对象-upacp 渠道****");
            Console.WriteLine(upacpCharge(appId));
            Console.WriteLine();

            Console.WriteLine("****发起交易请求创建 charge 对象-upacp_pc 渠道****");
            Console.WriteLine(upacp_pcCharge(appId));
            Console.WriteLine();

            Console.WriteLine("****发起交易请求创建 charge 对象- upacp_wap 渠道****");
            Console.WriteLine(upacp_wapCharge(appId));
            Console.WriteLine();

            Console.WriteLine("****发起交易请求创建 charge 对象-wx 渠道****");
            Console.WriteLine(wxCharge(appId));
            Console.WriteLine();

            Console.WriteLine("****发起交易请求创建 charge 对象-wx_lite 渠道****");
            Console.WriteLine(wx_liteCharge(appId));
            Console.WriteLine();

            Console.WriteLine("****发起交易请求创建 charge 对象- wx_pub 渠道****");
            Console.WriteLine(wx_pubCharge(appId));
            Console.WriteLine();

            Console.WriteLine("****发起交易请求创建 charge 对象- wx_pub_qr 渠道****");
            Console.WriteLine(wx_pub_qrCharge(appId));
            Console.WriteLine();

            Console.WriteLine("****发起交易请求创建 charge 对象- wx_wap 渠道****");
            Console.WriteLine(wx_wapCharge(appId));
            Console.WriteLine();

            Console.WriteLine("****发起交易请求创建 charge 对象-yeepay_wap 渠道****");
            var ch = yeepay_wapCharge(appId);
            Console.WriteLine(ch);
            Console.WriteLine();

            Console.WriteLine("****查询指定 charge 对象****");
            Console.WriteLine(Charge.Retrieve(ch.Id));
            Console.WriteLine();

            Console.WriteLine("****查询 charge 列表****");
            Dictionary<string, object> listParams = new Dictionary<string, object>{
                {"app", new Dictionary<string, string> {{"id", appId}}}, // 必填支付使用的  app 对象的  id
                {"limit", 10},  //限制有多少对象可以被返回，限制范围是从 1-20 项，默认是 10 项。
                {"paid", true}, // 是否已付款。
                {"refunded", false } // 是否存在退款信息，无论退款是否成功。
            };
            Console.WriteLine(Charge.List(listParams));
        }

        /// <summary>
        /// charge创建-alipay 渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Charge alipayCharge(String appId)
        {
            //交易请求参数，这里只列出必填参数，可选参数请参考 https://www.pingxx.com/api#创建-charge-对象
            var chParams = new Dictionary<string, object>
            {
                // 推荐使用 8-20 位，要求数字或字母，不允许其他字符
                {"order_no", new Random().Next(1, 999999999).ToString()},
                // 订单总金额, 人民币单位：分（如订单总金额为 1 元，此处请填 100）
                {"amount", 1},
                // 支付使用的第三方支付渠道取值，请参考： https://www.pingxx.com/api#支付渠道属性值
                {"channel", "alipay"},
                // 3 位 ISO 货币代码，人民币为  cny 。
                {"currency", "cny"},
                // 商品标题，该参数最长为 32 个 Unicode 字符，银联全渠道（ upacp / upacp_wap ）限制在 32 个字节。
                {"subject", "Your Subject"},
                // 商品描述信息，该参数最长为 128 个 Unicode 字符， yeepay_wap 对于该参数长度限制为 100 个 Unicode 字符。
                {"body", "Your Body"},
                // 发起支付请求客户端的 IP 地址，格式为 IPV4，如: 127.0.0.1
                {"client_ip", "127.0.0.1"},
                {"app", new Dictionary<string, string> {{"id", appId}}},
                // 特定渠道发起交易时需要的额外参数，以及部分渠道支付成功返回的额外参数，详细参考 https://www.pingxx.com/api#支付渠道-extra-参数说明
                {"extra", new Dictionary<string,object>{
                    // 可选，开放平台返回的包含账户信息的 token（授权令牌，商户在一定时间内对支付宝某些服务的访问权限）。通过授权登录后获取的  alipay_open_id ，作为该参数的  value ，登录授权账户即会为支付账户，32 位字符串。
                    {"extern_token", ""},
                    // 可选，是否发起实名校验，T 代表发起实名校验；F 代表不发起实名校验。
                    {"rn_check",'T'}
                }},
                // 可选：订单失效时间，用 Unix 时间戳表示。时间范围在订单创建后的 1 分钟到 15 天，默认为 1 天,创建时间以 Ping++ 服务器时间为准。 微信对该参数的有效值限制为 2 小时内；银联对该参数的有效值限制为 1 小时内。
                {"time_expire", timeExpire()},
                // 可选：订单附加说明，最多 255 个 Unicode 字符。
                {"description", "Your chare description"}
            };

            return Charge.Create(chParams);
        }

        /// <summary>
        /// charge创建-alipay_pc_direct 渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Charge alipay_pc_directCharge(String appId)
        {
            //交易请求参数，这里只列出必填参数，可选参数请参考 https://www.pingxx.com/api#创建-charge-对象
            var chParams = new Dictionary<string, object>
            {
                // 推荐使用 8-20 位，要求数字或字母，不允许其他字符
                {"order_no", new Random().Next(1, 999999999).ToString()},
                // 订单总金额, 人民币单位：分（如订单总金额为 1 元，此处请填 100）
                {"amount", 1},
                // 支付使用的第三方支付渠道取值，请参考： https://www.pingxx.com/api#支付渠道属性值
                {"channel", "alipay_pc_direct"},
                // 3 位 ISO 货币代码，人民币为  cny 。
                {"currency", "cny"},
                // 商品标题，该参数最长为 32 个 Unicode 字符，银联全渠道（ upacp / upacp_wap ）限制在 32 个字节。
                {"subject", "Your Subject"},
                // 商品描述信息，该参数最长为 128 个 Unicode 字符， yeepay_wap 对于该参数长度限制为 100 个 Unicode 字符。
                {"body", "Your Body"},
                // 发起支付请求客户端的 IP 地址，格式为 IPV4，如: 127.0.0.1
                {"client_ip", "127.0.0.1"},
                {"app", new Dictionary<string, string> {{"id", appId}}},
                // 特定渠道发起交易时需要的额外参数，以及部分渠道支付成功返回的额外参数，详细参考 https://www.pingxx.com/api#支付渠道-extra-参数说明
                {"extra", new Dictionary<string,object>{
                    // 必须，支付成功的回调地址，在本地测试不要写 localhost ，请写 127.0.0.1。URL 后面不要加自定义参数。
                    {"success_url", "http://example.com/success"},
                    // 可选，是否开启防钓鱼网站的验证参数（如果已申请开通防钓鱼时间戳验证，则此字段必填）。
                    //{"enable_anti_phishing_key",false},
                    // 可选，客户端 IP ，用户在创建交易时，该用户当前所使用机器的IP（如果商户申请后台开通防钓鱼IP地址检查选项，此字段必填，校验用）。
                    //{"exter_invoke_ip", "8.8.8.8"}
                }},
                // 可选：订单失效时间，用 Unix 时间戳表示。时间范围在订单创建后的 1 分钟到 15 天，默认为 1 天,创建时间以 Ping++ 服务器时间为准。 微信对该参数的有效值限制为 2 小时内；银联对该参数的有效值限制为 1 小时内。
                {"time_expire", timeExpire()},
                // 可选：订单附加说明，最多 255 个 Unicode 字符。
                {"description", "Your chare description"}
            };

            return Charge.Create(chParams);
        }

        /// <summary>
        /// charge创建-alipay_wap 渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Charge alipay_wapCharge(String appId)
        {
            //交易请求参数，这里只列出必填参数，可选参数请参考 https://www.pingxx.com/api#创建-charge-对象
            var chParams = new Dictionary<string, object>
            {
                // 推荐使用 8-20 位，要求数字或字母，不允许其他字符
                {"order_no", new Random().Next(1, 999999999).ToString()},
                // 订单总金额, 人民币单位：分（如订单总金额为 1 元，此处请填 100）
                {"amount", 1},
                // 支付使用的第三方支付渠道取值，请参考： https://www.pingxx.com/api#支付渠道属性值
                {"channel", "alipay_wap"},
                // 3 位 ISO 货币代码，人民币为  cny 。
                {"currency", "cny"},
                // 商品标题，该参数最长为 32 个 Unicode 字符，银联全渠道（ upacp / upacp_wap ）限制在 32 个字节。
                {"subject", "Your Subject"},
                // 商品描述信息，该参数最长为 128 个 Unicode 字符， yeepay_wap 对于该参数长度限制为 100 个 Unicode 字符。
                {"body", "Your Body"},
                // 发起支付请求客户端的 IP 地址，格式为 IPV4，如: 127.0.0.1
                {"client_ip", "127.0.0.1"},
                {"app", new Dictionary<string, string> {{"id", appId}}},
                // 特定渠道发起交易时需要的额外参数，以及部分渠道支付成功返回的额外参数，详细参考 https://www.pingxx.com/api#支付渠道-extra-参数说明
                {"extra", new Dictionary<string,object>{
                    // 必须，支付成功的回调地址，在本地测试不要写 localhost ，请写 127.0.0.1。URL 后面不要加自定义参数。
                    {"success_url", "http://example.com/success"},
                    // 可选，支付取消的回调地址， app_pay 为true时，该字段无效，在本地测试不要写 localhost ，请写 127.0.0.1。URL 后面不要加自定义参数。
                    {"cancel_url","http://example.com/cancel"},
                    // 可选，2016 年 6 月 16 日之前登录 Ping++ 管理平台填写支付宝手机网站的渠道参数的旧接口商户，需要更新接口时设置此参数值为true，6月16号后接入的新接口商户不需要设置该参数。
                    {"new_version", true},
                    // 可选，是否使用支付宝客户端支付，该参数为true时，调用客户端支付。
                    {"app_pay",true}
                }},
                // 可选：订单失效时间，用 Unix 时间戳表示。时间范围在订单创建后的 1 分钟到 15 天，默认为 1 天,创建时间以 Ping++ 服务器时间为准。 微信对该参数的有效值限制为 2 小时内；银联对该参数的有效值限制为 1 小时内。
                {"time_expire", timeExpire()},
                // 可选：订单附加说明，最多 255 个 Unicode 字符。
                {"description", "Your chare description"}
            };

            return Charge.Create(chParams);
        }


        /// <summary>
        /// charge创建-applepay_upacp 渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Charge applepay_upacpCharge(String appId)
        {
            //交易请求参数，这里只列出必填参数，可选参数请参考 https://www.pingxx.com/api#创建-charge-对象
            var chParams = new Dictionary<string, object>
            {
                // 推荐使用 8-20 位，要求数字或字母，不允许其他字符
                {"order_no", new Random().Next(1, 999999999).ToString()},
                // 订单总金额, 人民币单位：分（如订单总金额为 1 元，此处请填 100）
                {"amount", 1},
                // 支付使用的第三方支付渠道取值，请参考： https://www.pingxx.com/api#支付渠道属性值
                {"channel", "applepay_upacp"},
                // 3 位 ISO 货币代码，人民币为  cny 。
                {"currency", "cny"},
                // 商品标题，该参数最长为 32 个 Unicode 字符，银联全渠道（ upacp / upacp_wap ）限制在 32 个字节。
                {"subject", "Your Subject"},
                // 商品描述信息，该参数最长为 128 个 Unicode 字符， yeepay_wap 对于该参数长度限制为 100 个 Unicode 字符。
                {"body", "Your Body"},
                // 发起支付请求客户端的 IP 地址，格式为 IPV4，如: 127.0.0.1
                {"client_ip", "127.0.0.1"},
                {"app", new Dictionary<string, string> {{"id", appId}}},
                // 可选：订单失效时间，用 Unix 时间戳表示。时间范围在订单创建后的 1 分钟到 15 天，默认为 1 天,创建时间以 Ping++ 服务器时间为准。 微信对该参数的有效值限制为 2 小时内；银联对该参数的有效值限制为 1 小时内。
                {"time_expire", timeExpire()},
                // 可选：订单附加说明，最多 255 个 Unicode 字符。
                {"description", "Your chare description"}
            };

            return Charge.Create(chParams);
        }

        /// <summary>
        /// charge创建-bfb_wap 渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Charge bfb_wapCharge(String appId)
        {
            //交易请求参数，这里只列出必填参数，可选参数请参考 https://www.pingxx.com/api#创建-charge-对象
            var chParams = new Dictionary<string, object>
            {
                // 推荐使用 8-20 位，要求数字或字母，不允许其他字符
                {"order_no", new Random().Next(1, 999999999).ToString()},
                // 订单总金额, 人民币单位：分（如订单总金额为 1 元，此处请填 100）
                {"amount", 1},
                // 支付使用的第三方支付渠道取值，请参考： https://www.pingxx.com/api#支付渠道属性值
                {"channel", "bfb_wap"},
                // 3 位 ISO 货币代码，人民币为  cny 。
                {"currency", "cny"},
                // 商品标题，该参数最长为 32 个 Unicode 字符，银联全渠道（ upacp / upacp_wap ）限制在 32 个字节。
                {"subject", "Your Subject"},
                // 商品描述信息，该参数最长为 128 个 Unicode 字符， yeepay_wap 对于该参数长度限制为 100 个 Unicode 字符。
                {"body", "Your Body"},
                // 发起支付请求客户端的 IP 地址，格式为 IPV4，如: 127.0.0.1
                {"client_ip", "127.0.0.1"},
                {"app", new Dictionary<string, string> {{"id", appId}}},
                // 特定渠道发起交易时需要的额外参数，以及部分渠道支付成功返回的额外参数，详细参考 https://www.pingxx.com/api#支付渠道-extra-参数说明
                {"extra", new Dictionary<string,object>{
                    // 必须，支付成功的回调地址，在本地测试不要写 localhost ，请写 127.0.0.1。URL 后面不要加自定义参数。
                    {"result_url", "http://example.com/success"},
                    // 必须，是否需要登录百度钱包来进行支付。
                    {"bfb_login", true}
                }},
                // 可选：订单失效时间，用 Unix 时间戳表示。时间范围在订单创建后的 1 分钟到 15 天，默认为 1 天,创建时间以 Ping++ 服务器时间为准。 微信对该参数的有效值限制为 2 小时内；银联对该参数的有效值限制为 1 小时内。
                {"time_expire", timeExpire()},
                // 可选：订单附加说明，最多 255 个 Unicode 字符。
                {"description", "Your chare description"}
            };

            return Charge.Create(chParams);
        }


        /// <summary>
        /// charge创建-cmb_wallet 渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Charge cmb_walletCharge(String appId)
        {
            //交易请求参数，这里只列出必填参数，可选参数请参考 https://www.pingxx.com/api#创建-charge-对象
            var chParams = new Dictionary<string, object>
            {
                // 推荐使用 8-20 位，要求数字或字母，不允许其他字符
                {"order_no", randomStr(10)},
                // 订单总金额, 人民币单位：分（如订单总金额为 1 元，此处请填 100）
                {"amount", 100},
                // 支付使用的第三方支付渠道取值，请参考： https://www.pingxx.com/api#支付渠道属性值
                {"channel", "cmb_wallet"},
                // 3 位 ISO 货币代码，人民币为  cny 。
                {"currency", "cny"},
                // 商品标题，该参数最长为 32 个 Unicode 字符，银联全渠道（ upacp / upacp_wap ）限制在 32 个字节。
                {"subject", "Your Subject"},
                // 商品描述信息，该参数最长为 128 个 Unicode 字符， yeepay_wap 对于该参数长度限制为 100 个 Unicode 字符。
                {"body", "Your Body"},
                // 发起支付请求客户端的 IP 地址，格式为 IPV4，如: 127.0.0.1
                {"client_ip", "127.0.0.1"},
                {"app", new Dictionary<string, string> {{"id", appId}}},
                // 特定渠道发起交易时需要的额外参数，以及部分渠道支付成功返回的额外参数，详细参考 https://www.pingxx.com/api#支付渠道-extra-参数说明
                {"extra", new Dictionary<string,object>{
                    // 必须，交易完成跳转的地址。
                    {"result_url", "http://example.com/success"},
                    /// 对于 p_no, seq , m_uid , mobile 这几个参数：
                    ///     1. 这几个参数是用户自定义的。
                    ///     2. 对于同一个终端用户每次请求 charge 务必使用同一套参数（确保每个参数都不变），\
                    ///     任意参数变更都会导致用户重新签约，同一个用户和招行重新签约的次数有限制，超限制就会无法签约 ，导致用户无法使用。
                    // 必须，客户协议号，不超过 30 位的纯数字字符串。
                    {"p_no", "12345678901234567890"},
                    // 必须，协议开通请求流水号，不超过 20 位的纯数字字符串，请保证系统内唯一。
                    {"seq", "123456789066"},
                    // 必须，协议用户 ID，不超过 20 位的纯数字字符串。
                    {"m_uid", "88888888"},
                    // 必须，协议手机号，11 位数字。
                    {"mobile", "13088888888"}
                }},
                // 可选：订单失效时间，用 Unix 时间戳表示。时间范围在订单创建后的 1 分钟到 15 天，默认为 1 天,创建时间以 Ping++ 服务器时间为准。 微信对该参数的有效值限制为 2 小时内；银联对该参数的有效值限制为 1 小时内。
                {"time_expire", timeExpire()},
                // 可选：订单附加说明，最多 255 个 Unicode 字符。
                {"description", "Your chare description"}
            };

            return Charge.Create(chParams);
        }


        /// <summary>
        /// charge创建-fqlpay_wap 渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Charge fqlpay_wapCharge(String appId)
        {
            //交易请求参数，这里只列出必填参数，可选参数请参考 https://www.pingxx.com/api#创建-charge-对象
            var chParams = new Dictionary<string, object>
            {
                // 推荐使用 8-20 位，要求数字或字母，不允许其他字符
                {"order_no", new Random().Next(1, 999999999).ToString()},
                // 订单总金额, 人民币单位：分（如订单总金额为 1 元，此处请填 100）
                {"amount", 1},
                // 支付使用的第三方支付渠道取值，请参考： https://www.pingxx.com/api#支付渠道属性值
                {"channel", "fqlpay_wap"},
                // 3 位 ISO 货币代码，人民币为  cny 。
                {"currency", "cny"},
                // 商品标题，该参数最长为 32 个 Unicode 字符，银联全渠道（ upacp / upacp_wap ）限制在 32 个字节。
                {"subject", "Your Subject"},
                // 商品描述信息，该参数最长为 128 个 Unicode 字符， yeepay_wap 对于该参数长度限制为 100 个 Unicode 字符。
                {"body", "Your Body"},
                // 发起支付请求客户端的 IP 地址，格式为 IPV4，如: 127.0.0.1
                {"client_ip", "127.0.0.1"},
                {"app", new Dictionary<string, string> {{"id", appId}}},
                // 特定渠道发起交易时需要的额外参数，以及部分渠道支付成功返回的额外参数，详细参考 https://www.pingxx.com/api#支付渠道-extra-参数说明
                {"extra", new Dictionary<string,object>{
                    // 必须，子商户编号，需要提交该订单商户的所属子商户编号。
                    {"c_merch_id", "your c_merch_id"},
                    // 可选，前端回调地址，交易完成跳转的链接，不能带自定义参数。
                    {"return_url", "http://example.com/success"}
                }},
                // 可选：订单失效时间，用 Unix 时间戳表示。时间范围在订单创建后的 1 分钟到 15 天，默认为 1 天,创建时间以 Ping++ 服务器时间为准。 微信对该参数的有效值限制为 2 小时内；银联对该参数的有效值限制为 1 小时内。
                {"time_expire", timeExpire()},
                // 可选：订单附加说明，最多 255 个 Unicode 字符。
                {"description", "Your chare description"}
            };

            return Charge.Create(chParams);
        }

        /// <summary>
        /// charge创建-jdpay_wap 渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Charge jdpay_wapCharge(String appId)
        {
            //交易请求参数，这里只列出必填参数，可选参数请参考 https://www.pingxx.com/api#创建-charge-对象
            var chParams = new Dictionary<string, object>
            {
                // 推荐使用 8-20 位，要求数字或字母，不允许其他字符
                {"order_no", new Random().Next(1, 999999999).ToString()},
                // 订单总金额, 人民币单位：分（如订单总金额为 1 元，此处请填 100）
                {"amount", 1},
                // 支付使用的第三方支付渠道取值，请参考： https://www.pingxx.com/api#支付渠道属性值
                {"channel", "jdpay_wap"},
                // 3 位 ISO 货币代码，人民币为  cny 。
                {"currency", "cny"},
                // 商品标题，该参数最长为 32 个 Unicode 字符，银联全渠道（ upacp / upacp_wap ）限制在 32 个字节。
                {"subject", "Your Subject"},
                // 商品描述信息，该参数最长为 128 个 Unicode 字符， yeepay_wap 对于该参数长度限制为 100 个 Unicode 字符。
                {"body", "Your Body"},
                // 发起支付请求客户端的 IP 地址，格式为 IPV4，如: 127.0.0.1
                {"client_ip", "127.0.0.1"},
                {"app", new Dictionary<string, string> {{"id", appId}}},
                // 特定渠道发起交易时需要的额外参数，以及部分渠道支付成功返回的额外参数，详细参考 https://www.pingxx.com/api#支付渠道-extra-参数说明
                {"extra", new Dictionary<string,object>{
                    // 必须，支付完成的回调地址。
                    {"success_url", "http://example.com/success"},
                    // 必须，支付失败页面跳转路径。
                    {"fail_url", "http://example.com/fail"},
                    // 可选，用户交易令牌，用于识别用户信息，支付成功后会调用 success_url 返回给商户。商户可以记录这个  token 值，当用户再次支付的时候传入该  token ，用户无需再次输入银行卡信息，直接输入短信验证码进行支付。32 位字符串。
                    //{"token", "dsafadsfasdfadsjuyhfnhujkijunhaf"},
                    // 可选，订单类型，值为0表示实物商品订单，值为 1 代表虚拟商品订单，该参数默认值为 0 。
                    {"order_type", 0},
                    //可选，设置是否通过手机端发起支付，值为  true 时调用手机 h5 支付页面，值为  false 时调用 PC 端支付页面，该参数默认值为  true 。
                    {"is_mobile", true},
                    //可选，用户账号类型，取值只能为：BIZ。传参存在问题请参考 帮助中心：https://help.pingxx.com/article/1012535/。
                    //{"user_type", "BIZ"},
                    // 可选，商户的用户账号。传参存在问题请参考 帮助中心：https://help.pingxx.com/article/1012535/。
                    //{"user_id", "your user_id"}
                }},
                // 可选：订单失效时间，用 Unix 时间戳表示。时间范围在订单创建后的 1 分钟到 15 天，默认为 1 天,创建时间以 Ping++ 服务器时间为准。 微信对该参数的有效值限制为 2 小时内；银联对该参数的有效值限制为 1 小时内。
                {"time_expire", timeExpire()},
                // 可选：订单附加说明，最多 255 个 Unicode 字符。
                {"description", "Your chare description"}
            };

            return Charge.Create(chParams);
        }

        /// <summary>
        /// charge创建-mmdpay_wap 渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Charge mmdpay_wapCharge(String appId)
        {
            //交易请求参数，这里只列出必填参数，可选参数请参考 https://www.pingxx.com/api#创建-charge-对象
            var chParams = new Dictionary<string, object>
            {
                // 推荐使用 8-20 位，要求数字或字母，不允许其他字符
                {"order_no", new Random().Next(1, 999999999).ToString()},
                // 订单总金额, 人民币单位：分（如订单总金额为 2000 元，此处请填 200000）
                {"amount", 200000},
                // 支付使用的第三方支付渠道取值，请参考： https://www.pingxx.com/api#支付渠道属性值
                {"channel", "mmdpay_wap"},
                // 3 位 ISO 货币代码，人民币为  cny 。
                {"currency", "cny"},
                // 商品标题，该参数最长为 32 个 Unicode 字符，银联全渠道（ upacp / upacp_wap ）限制在 32 个字节。
                {"subject", "Your Subject"},
                // 商品描述信息，该参数最长为 128 个 Unicode 字符， yeepay_wap 对于该参数长度限制为 100 个 Unicode 字符。
                {"body", "Your Body"},
                // 发起支付请求客户端的 IP 地址，格式为 IPV4，如: 127.0.0.1
                {"client_ip", "127.0.0.1"},
                {"app", new Dictionary<string, string> {{"id", appId}}},
                // 特定渠道发起交易时需要的额外参数，以及部分渠道支付成功返回的额外参数，详细参考 https://www.pingxx.com/api#支付渠道-extra-参数说明
                {"extra", new Dictionary<string,object>{
                    // 必须，手机号。
                    {"phone", "13088888888"},
                    // 必须，身份证号。
                    {"id_no", "666666199001016666"},
                    // 必须，真实姓名。
                    {"name", "张三"}
                }},
                // 可选：订单失效时间，用 Unix 时间戳表示。时间范围在订单创建后的 1 分钟到 15 天，默认为 1 天,创建时间以 Ping++ 服务器时间为准。 微信对该参数的有效值限制为 2 小时内；银联对该参数的有效值限制为 1 小时内。
                {"time_expire", timeExpire()},
                // 可选：订单附加说明，最多 255 个 Unicode 字符。
                {"description", "Your chare description"}
            };

            return Charge.Create(chParams);
        }

        /// <summary>
        /// charge创建-qgbc_wap 渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Charge qgbc_wapCharge(String appId)
        {
            //交易请求参数，这里只列出必填参数，可选参数请参考 https://www.pingxx.com/api#创建-charge-对象
            var chParams = new Dictionary<string, object>
            {
                // 推荐使用 8-20 位，要求数字或字母，不允许其他字符
                {"order_no", new Random().Next(1, 999999999).ToString()},
                // 订单总金额, 人民币单位：分（如订单总金额为 100 元，此处请填 10000）
                {"amount", 10000},
                // 支付使用的第三方支付渠道取值，请参考： https://www.pingxx.com/api#支付渠道属性值
                {"channel", "qgbc_wap"},
                // 3 位 ISO 货币代码，人民币为  cny 。
                {"currency", "cny"},
                // 商品标题，该参数最长为 32 个 Unicode 字符，银联全渠道（ upacp / upacp_wap ）限制在 32 个字节。
                {"subject", "Your Subject"},
                // 商品描述信息，该参数最长为 128 个 Unicode 字符， yeepay_wap 对于该参数长度限制为 100 个 Unicode 字符。
                {"body", "Your Body"},
                // 发起支付请求客户端的 IP 地址，格式为 IPV4，如: 127.0.0.1
                {"client_ip", "127.0.0.1"},
                {"app", new Dictionary<string, string> {{"id", appId}}},
                // 特定渠道发起交易时需要的额外参数，以及部分渠道支付成功返回的额外参数，详细参考 https://www.pingxx.com/api#支付渠道-extra-参数说明
                {"extra", new Dictionary<string,object>{
                    // 必须，手机号码。
                    {"phone", "13088888888"},
                    // 可选，交易完成跳转的地址。
                    {"return_url", "http://example.com/success"},
                    // 可选，分期参数，0 代表不分期，1 代表分 3 期，2 代表分 6 期，3 代表分 9 期，4 代表分 12 期。
                    {"term",0}, 
                    // 可选，账户激活中状态跳转链接。
                    {"activate_url", "http://example.com/activate_url"},
                    // 可选，是否显示量化派页面顶部 header，即是否显示 H5 顶部标题栏，默认为  true 时显示。
                    {"has_header", true}
                }},
                // 可选：订单失效时间，用 Unix 时间戳表示。时间范围在订单创建后的 1 分钟到 15 天，默认为 1 天,创建时间以 Ping++ 服务器时间为准。 微信对该参数的有效值限制为 2 小时内；银联对该参数的有效值限制为 1 小时内。
                {"time_expire", timeExpire()},
                // 可选：订单附加说明，最多 255 个 Unicode 字符。
                {"description", "Your chare description"}
            };

            return Charge.Create(chParams);
        }

        /// <summary>
        /// charge创建-qpay 渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Charge qpayCharge(String appId)
        {
            //交易请求参数，这里只列出必填参数，可选参数请参考 https://www.pingxx.com/api#创建-charge-对象
            var chParams = new Dictionary<string, object>
            {
                // 推荐使用 8-20 位，要求数字或字母，不允许其他字符
                {"order_no", new Random().Next(1, 999999999).ToString()},
                // 订单总金额, 人民币单位：分（如订单总金额为 1 元，此处请填 100）
                {"amount", 1},
                // 支付使用的第三方支付渠道取值，请参考： https://www.pingxx.com/api#支付渠道属性值
                {"channel", "qpay"},
                // 3 位 ISO 货币代码，人民币为  cny 。
                {"currency", "cny"},
                // 商品标题，该参数最长为 32 个 Unicode 字符，银联全渠道（ upacp / upacp_wap ）限制在 32 个字节。
                {"subject", "Your Subject"},
                // 商品描述信息，该参数最长为 128 个 Unicode 字符， yeepay_wap 对于该参数长度限制为 100 个 Unicode 字符。
                {"body", "Your Body"},
                // 发起支付请求客户端的 IP 地址，格式为 IPV4，如: 127.0.0.1
                {"client_ip", "127.0.0.1"},
                {"app", new Dictionary<string, string> {{"id", appId}}},
                // 特定渠道发起交易时需要的额外参数，以及部分渠道支付成功返回的额外参数，详细参考 https://www.pingxx.com/api#支付渠道-extra-参数说明
                {"extra", new Dictionary<string,object>{
                    // 必须，客户端设备类型，取值范围: "ios" ，"android"。
                   {"device", "ios"}
                }},
                // 可选：订单失效时间，用 Unix 时间戳表示。时间范围在订单创建后的 1 分钟到 15 天，默认为 1 天,创建时间以 Ping++ 服务器时间为准。 微信对该参数的有效值限制为 2 小时内；银联对该参数的有效值限制为 1 小时内。
                {"time_expire", timeExpire()},
                // 可选：订单附加说明，最多 255 个 Unicode 字符。
                {"description", "Your chare description"}
            };

            return Charge.Create(chParams);
        }

        /// <summary>
        /// charge创建-upacp 渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Charge upacpCharge(String appId)
        {
            //交易请求参数，这里只列出必填参数，可选参数请参考 https://www.pingxx.com/api#创建-charge-对象
            var chParams = new Dictionary<string, object>
            {
                // 推荐使用 8-20 位，要求数字或字母，不允许其他字符
                {"order_no", new Random().Next(1, 999999999).ToString()},
                // 订单总金额, 人民币单位：分（如订单总金额为 1 元，此处请填 100）
                {"amount", 1},
                // 支付使用的第三方支付渠道取值，请参考： https://www.pingxx.com/api#支付渠道属性值
                {"channel", "upacp"},
                // 3 位 ISO 货币代码，人民币为  cny 。
                {"currency", "cny"},
                // 商品标题，该参数最长为 32 个 Unicode 字符，银联全渠道（ upacp / upacp_wap ）限制在 32 个字节。
                {"subject", "Your Subject"},
                // 商品描述信息，该参数最长为 128 个 Unicode 字符， yeepay_wap 对于该参数长度限制为 100 个 Unicode 字符。
                {"body", "Your Body"},
                // 发起支付请求客户端的 IP 地址，格式为 IPV4，如: 127.0.0.1
                {"client_ip", "127.0.0.1"},
                {"app", new Dictionary<string, string> {{"id", appId}}},
                // 可选：订单失效时间，用 Unix 时间戳表示。时间范围在订单创建后的 1 分钟到 15 天，默认为 1 天,创建时间以 Ping++ 服务器时间为准。 微信对该参数的有效值限制为 2 小时内；银联对该参数的有效值限制为 1 小时内。
                {"time_expire", timeExpire()},
                // 可选：订单附加说明，最多 255 个 Unicode 字符。
                {"description", "Your chare description"}
            };

            return Charge.Create(chParams);
        }


        /// <summary>
        /// charge创建-upacp_pc 渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Charge upacp_pcCharge(String appId)
        {
            //交易请求参数，这里只列出必填参数，可选参数请参考 https://www.pingxx.com/api#创建-charge-对象
            var chParams = new Dictionary<string, object>
            {
                // 推荐使用 8-20 位，要求数字或字母，不允许其他字符
                {"order_no", new Random().Next(1, 999999999).ToString()},
                // 订单总金额, 人民币单位：分（如订单总金额为 1 元，此处请填 100）
                {"amount", 1},
                // 支付使用的第三方支付渠道取值，请参考： https://www.pingxx.com/api#支付渠道属性值
                {"channel", "upacp_pc"},
                // 3 位 ISO 货币代码，人民币为  cny 。
                {"currency", "cny"},
                // 商品标题，该参数最长为 32 个 Unicode 字符，银联全渠道（ upacp / upacp_wap ）限制在 32 个字节。
                {"subject", "Your Subject"},
                // 商品描述信息，该参数最长为 128 个 Unicode 字符， yeepay_wap 对于该参数长度限制为 100 个 Unicode 字符。
                {"body", "Your Body"},
                // 发起支付请求客户端的 IP 地址，格式为 IPV4，如: 127.0.0.1
                {"client_ip", "127.0.0.1"},
                {"app", new Dictionary<string, string> {{"id", appId}}},
                // 特定渠道发起交易时需要的额外参数，以及部分渠道支付成功返回的额外参数，详细参考 https://www.pingxx.com/api#支付渠道-extra-参数说明
                {"extra", new Dictionary<string,object>{
                    // 必须，支付成功的回调地址，在本地测试不要写 localhost ，请写 127.0.0.1。URL 后面不要加自定义参数。
                    {"result_url", "http://example.com/success"},
                }},
                // 可选：订单失效时间，用 Unix 时间戳表示。时间范围在订单创建后的 1 分钟到 15 天，默认为 1 天,创建时间以 Ping++ 服务器时间为准。 微信对该参数的有效值限制为 2 小时内；银联对该参数的有效值限制为 1 小时内。
                {"time_expire", timeExpire()},
                // 可选：订单附加说明，最多 255 个 Unicode 字符。
                {"description", "Your chare description"}
            };

            return Charge.Create(chParams);
        }

        /// <summary>
        /// charge创建-upacp_wap 渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Charge upacp_wapCharge(String appId)
        {
            //交易请求参数，这里只列出必填参数，可选参数请参考 https://www.pingxx.com/api#创建-charge-对象
            var chParams = new Dictionary<string, object>
            {
                // 推荐使用 8-20 位，要求数字或字母，不允许其他字符
                {"order_no", new Random().Next(1, 999999999).ToString()},
                // 订单总金额, 人民币单位：分（如订单总金额为 1 元，此处请填 100）
                {"amount", 1},
                // 支付使用的第三方支付渠道取值，请参考： https://www.pingxx.com/api#支付渠道属性值
                {"channel", "upacp_wap"},
                // 3 位 ISO 货币代码，人民币为  cny 。
                {"currency", "cny"},
                // 商品标题，该参数最长为 32 个 Unicode 字符，银联全渠道（ upacp / upacp_wap ）限制在 32 个字节。
                {"subject", "Your Subject"},
                // 商品描述信息，该参数最长为 128 个 Unicode 字符， yeepay_wap 对于该参数长度限制为 100 个 Unicode 字符。
                {"body", "Your Body"},
                // 发起支付请求客户端的 IP 地址，格式为 IPV4，如: 127.0.0.1
                {"client_ip", "127.0.0.1"},
                {"app", new Dictionary<string, string> {{"id", appId}}},
                // 特定渠道发起交易时需要的额外参数，以及部分渠道支付成功返回的额外参数，详细参考 https://www.pingxx.com/api#支付渠道-extra-参数说明
                {"extra", new Dictionary<string,object>{
                    // 必须，支付成功的回调地址，在本地测试不要写 localhost ，请写 127.0.0.1。URL 后面不要加自定义参数。
                    {"result_url", "http://example.com/success"},
                }},
                // 可选：订单失效时间，用 Unix 时间戳表示。时间范围在订单创建后的 1 分钟到 15 天，默认为 1 天,创建时间以 Ping++ 服务器时间为准。 微信对该参数的有效值限制为 2 小时内；银联对该参数的有效值限制为 1 小时内。
                {"time_expire", timeExpire()},
                // 可选：订单附加说明，最多 255 个 Unicode 字符。
                {"description", "Your chare description"}
            };

            return Charge.Create(chParams);
        }


        /// <summary>
        /// charge创建-wx 渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Charge wxCharge(String appId)
        {
            //交易请求参数，这里只列出必填参数，可选参数请参考 https://www.pingxx.com/api#创建-charge-对象
            var chParams = new Dictionary<string, object>
            {
                // 推荐使用 8-20 位，要求数字或字母，不允许其他字符
                {"order_no", new Random().Next(1, 999999999).ToString()},
                // 订单总金额, 人民币单位：分（如订单总金额为 1 元，此处请填 100）
                {"amount", 1},
                // 支付使用的第三方支付渠道取值，请参考： https://www.pingxx.com/api#支付渠道属性值
                {"channel", "wx"},
                // 3 位 ISO 货币代码，人民币为  cny 。
                {"currency", "cny"},
                // 商品标题，该参数最长为 32 个 Unicode 字符，银联全渠道（ upacp / upacp_wap ）限制在 32 个字节。
                {"subject", "Your Subject"},
                // 商品描述信息，该参数最长为 128 个 Unicode 字符， yeepay_wap 对于该参数长度限制为 100 个 Unicode 字符。
                {"body", "Your Body"},
                // 发起支付请求客户端的 IP 地址，格式为 IPV4，如: 127.0.0.1
                {"client_ip", "127.0.0.1"},
                {"app", new Dictionary<string, string> {{"id", appId}}},
                // 特定渠道发起交易时需要的额外参数，以及部分渠道支付成功返回的额外参数，详细参考 https://www.pingxx.com/api#支付渠道-extra-参数说明
                {"extra", new Dictionary<string,object>{
                    // 可选，指定支付方式，指定不能使用信用卡支付可设置为 no_credit 
                    {"limit_pay", "no_credit"},
                    // 可选，商品标记，代金券或立减优惠功能的参数。。
                    //{"goods_tag", "888ABCD888"}
                }},
                // 可选：订单失效时间，用 Unix 时间戳表示。时间范围在订单创建后的 1 分钟到 15 天，默认为 1 天,创建时间以 Ping++ 服务器时间为准。 微信对该参数的有效值限制为 2 小时内；银联对该参数的有效值限制为 1 小时内。
                {"time_expire", timeExpire()},
                // 可选：订单附加说明，最多 255 个 Unicode 字符。
                {"description", "Your chare description"}
            };

            return Charge.Create(chParams);
        }

        /// <summary>
        /// charge创建-cmb_wallet 渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Charge wx_liteCharge(String appId)
        {
            //交易请求参数，这里只列出必填参数，可选参数请参考 https://www.pingxx.com/api#创建-charge-对象
            var chParams = new Dictionary<string, object>
            {
                // cmb_wallet :10 位纯数字字符串。
                {"order_no", new Random().Next(1,9).ToString() + new Random().Next(111111111, 999999999).ToString()},
                // 订单总金额, 人民币单位：分（如订单总金额为 1 元，此处请填 100）
                {"amount", 1},
                // 支付使用的第三方支付渠道取值，请参考： https://www.pingxx.com/api#支付渠道属性值
                {"channel", "wx_lite"},
                // 3 位 ISO 货币代码，人民币为  cny 。
                {"currency", "cny"},
                // 商品标题，该参数最长为 32 个 Unicode 字符，银联全渠道（ upacp / upacp_wap ）限制在 32 个字节。
                {"subject", "Your Subject"},
                // 商品描述信息，该参数最长为 128 个 Unicode 字符， yeepay_wap 对于该参数长度限制为 100 个 Unicode 字符。
                {"body", "Your Body"},
                // 发起支付请求客户端的 IP 地址，格式为 IPV4，如: 127.0.0.1
                {"client_ip", "127.0.0.1"},
                {"app", new Dictionary<string, string> {{"id", appId}}},
                // 特定渠道发起交易时需要的额外参数，以及部分渠道支付成功返回的额外参数，详细参考 https://www.pingxx.com/api#支付渠道-extra-参数说明
                {"extra", new Dictionary<string,object>{
                    // 可选，指定支付方式，指定不能使用信用卡支付可设置为 no_credit 。
                    {"limit_pay", "no_credit"},
                    // 可选，商品标记，代金券或立减优惠功能的参数。
                    {"goods_tag", "888ABCD888"},
                    // 必须，用户在商户 appid 下的唯一标识。
                    {"open_id", "openidxxxxxxxxxxxx"}
                }},
                // 可选：订单失效时间，用 Unix 时间戳表示。时间范围在订单创建后的 1 分钟到 15 天，默认为 1 天,创建时间以 Ping++ 服务器时间为准。 微信对该参数的有效值限制为 2 小时内；银联对该参数的有效值限制为 1 小时内。
                {"time_expire", timeExpire()},
                // 可选：订单附加说明，最多 255 个 Unicode 字符。
                {"description", "Your chare description"}
            };

            return Charge.Create(chParams);
        }

        /// <summary>
        /// charge创建-cmb_wallet 渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Charge wx_pubCharge(String appId)
        {
            //交易请求参数，这里只列出必填参数，可选参数请参考 https://www.pingxx.com/api#创建-charge-对象
            var chParams = new Dictionary<string, object>
            {
                // 推荐使用 8-20 位，要求数字或字母，不允许其他字符
                {"order_no", new Random().Next(1, 999999999).ToString()},
                // 订单总金额, 人民币单位：分（如订单总金额为 1 元，此处请填 100）
                {"amount", 1},
                // 支付使用的第三方支付渠道取值，请参考： https://www.pingxx.com/api#支付渠道属性值
                {"channel", "wx_pub"},
                // 3 位 ISO 货币代码，人民币为  cny 。
                {"currency", "cny"},
                // 商品标题，该参数最长为 32 个 Unicode 字符，银联全渠道（ upacp / upacp_wap ）限制在 32 个字节。
                {"subject", "Your Subject"},
                // 商品描述信息，该参数最长为 128 个 Unicode 字符， yeepay_wap 对于该参数长度限制为 100 个 Unicode 字符。
                {"body", "Your Body"},
                // 发起支付请求客户端的 IP 地址，格式为 IPV4，如: 127.0.0.1
                {"client_ip", "127.0.0.1"},
                {"app", new Dictionary<string, string> {{"id", appId}}},
                // 特定渠道发起交易时需要的额外参数，以及部分渠道支付成功返回的额外参数，详细参考 https://www.pingxx.com/api#支付渠道-extra-参数说明
                {"extra", new Dictionary<string,object>{
                    // 可选，指定支付方式，指定不能使用信用卡支付可设置为 no_credit 。
                    {"limit_pay", "no_credit"},
                    // 可选，商品标记，代金券或立减优惠功能的参数。
                    {"goods_tag", "888ABCD888"},
                    // 必须，用户在商户 appid 下的唯一标识。
                    {"open_id", "openidxxxxxxxxxxxx"}
                }},
                // 可选：订单失效时间，用 Unix 时间戳表示。时间范围在订单创建后的 1 分钟到 15 天，默认为 1 天,创建时间以 Ping++ 服务器时间为准。 微信对该参数的有效值限制为 2 小时内；银联对该参数的有效值限制为 1 小时内。
                {"time_expire", timeExpire()},
                // 可选：订单附加说明，最多 255 个 Unicode 字符。
                {"description", "Your chare description"}
            };

            return Charge.Create(chParams);
        }

        /// <summary>
        /// charge创建-wx_pub_qr 渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Charge wx_pub_qrCharge(String appId)
        {
            //交易请求参数，这里只列出必填参数，可选参数请参考 https://www.pingxx.com/api#创建-charge-对象
            var chParams = new Dictionary<string, object>
            {
                // 推荐使用 8-20 位，要求数字或字母，不允许其他字符
                {"order_no", new Random().Next(1, 999999999).ToString()},
                // 订单总金额, 人民币单位：分（如订单总金额为 1 元，此处请填 100）
                {"amount", 1},
                // 支付使用的第三方支付渠道取值，请参考： https://www.pingxx.com/api#支付渠道属性值
                {"channel", "wx_pub_qr"},
                // 3 位 ISO 货币代码，人民币为  cny 。
                {"currency", "cny"},
                // 商品标题，该参数最长为 32 个 Unicode 字符，银联全渠道（ upacp / upacp_wap ）限制在 32 个字节。
                {"subject", "Your Subject"},
                // 商品描述信息，该参数最长为 128 个 Unicode 字符， yeepay_wap 对于该参数长度限制为 100 个 Unicode 字符。
                {"body", "Your Body"},
                // 发起支付请求客户端的 IP 地址，格式为 IPV4，如: 127.0.0.1
                {"client_ip", "127.0.0.1"},
                {"app", new Dictionary<string, string> {{"id", appId}}},
                // 特定渠道发起交易时需要的额外参数，以及部分渠道支付成功返回的额外参数，详细参考 https://www.pingxx.com/api#支付渠道-extra-参数说明
                {"extra", new Dictionary<string,object>{
                    // 可选，指定支付方式，指定不能使用信用卡支付可设置为 no_credit 。
                    {"limit_pay", "no_credit"},
                    // 可选，商品标记，代金券或立减优惠功能的参数。
                    {"goods_tag", "888ABCD888"},
                    // 必须，商品 ID，1-32 位字符串。此 id 为二维码中包含的商品 ID，商户可自定义。
                    {"product_id", "6666666666"}
                }},
                // 可选：订单失效时间，用 Unix 时间戳表示。时间范围在订单创建后的 1 分钟到 15 天，默认为 1 天,创建时间以 Ping++ 服务器时间为准。 微信对该参数的有效值限制为 2 小时内；银联对该参数的有效值限制为 1 小时内。
                {"time_expire", timeExpire()},
                // 可选：订单附加说明，最多 255 个 Unicode 字符。
                {"description", "Your chare description"}
            };

            return Charge.Create(chParams);
        }

        /// <summary>
        /// charge创建-wx_wap 渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Charge wx_wapCharge(String appId)
        {
            //交易请求参数，这里只列出必填参数，可选参数请参考 https://www.pingxx.com/api#创建-charge-对象
            var chParams = new Dictionary<string, object>
            {
                // 推荐使用 8-20 位，要求数字或字母，不允许其他字符
                {"order_no", new Random().Next(1, 999999999).ToString()},
                // 订单总金额, 人民币单位：分（如订单总金额为 1 元，此处请填 100）
                {"amount", 1},
                // 支付使用的第三方支付渠道取值，请参考： https://www.pingxx.com/api#支付渠道属性值
                {"channel", "wx_wap"},
                // 3 位 ISO 货币代码，人民币为  cny 。
                {"currency", "cny"},
                // 商品标题，该参数最长为 32 个 Unicode 字符，银联全渠道（ upacp / upacp_wap ）限制在 32 个字节。
                {"subject", "Your Subject"},
                // 商品描述信息，该参数最长为 128 个 Unicode 字符， yeepay_wap 对于该参数长度限制为 100 个 Unicode 字符。
                {"body", "Your Body"},
                // 发起支付请求客户端的 IP 地址，格式为 IPV4，如: 127.0.0.1
                {"client_ip", "127.0.0.1"},
                {"app", new Dictionary<string, string> {{"id", appId}}},
                // 特定渠道发起交易时需要的额外参数，以及部分渠道支付成功返回的额外参数，详细参考 https://www.pingxx.com/api#支付渠道-extra-参数说明
                {"extra", new Dictionary<string,object>{
                    // 可选，支付完成的回调地址。
                    {"result_url", "http://example.com/success"},
                    // 可选，商品标记，代金券或立减优惠功能的参数。
                    {"goods_tag", "8888ABCD8888"}
                }},
                // 可选：订单失效时间，用 Unix 时间戳表示。时间范围在订单创建后的 1 分钟到 15 天，默认为 1 天,创建时间以 Ping++ 服务器时间为准。 微信对该参数的有效值限制为 2 小时内；银联对该参数的有效值限制为 1 小时内。
                {"time_expire", timeExpire()},
                // 可选：订单附加说明，最多 255 个 Unicode 字符。
                {"description", "Your chare description"}
            };

            return Charge.Create(chParams);
        }

        /// <summary>
        /// charge创建-yeepay_wap 渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Charge yeepay_wapCharge(String appId)
        {
            //交易请求参数，这里只列出必填参数，可选参数请参考 https://www.pingxx.com/api#创建-charge-对象
            var chParams = new Dictionary<string, object>
            {
                // 推荐使用 8-20 位，要求数字或字母，不允许其他字符
                {"order_no", new Random().Next(1, 999999999).ToString()},
                // 订单总金额, 人民币单位：分（如订单总金额为 1 元，此处请填 100）
                {"amount", 1},
                // 支付使用的第三方支付渠道取值，请参考： https://www.pingxx.com/api#支付渠道属性值
                {"channel", "yeepay_wap"},
                // 3 位 ISO 货币代码，人民币为  cny 。
                {"currency", "cny"},
                // 商品标题，该参数最长为 32 个 Unicode 字符，银联全渠道（ upacp / upacp_wap ）限制在 32 个字节。
                {"subject", "Your Subject"},
                // 商品描述信息，该参数最长为 128 个 Unicode 字符， yeepay_wap 对于该参数长度限制为 100 个 Unicode 字符。
                {"body", "Your Body"},
                // 发起支付请求客户端的 IP 地址，格式为 IPV4，如: 127.0.0.1
                {"client_ip", "127.0.0.1"},
                {"app", new Dictionary<string, string> {{"id", appId}}},
                // 特定渠道发起交易时需要的额外参数，以及部分渠道支付成功返回的额外参数，详细参考 https://www.pingxx.com/api#支付渠道-extra-参数说明
                {"extra", new Dictionary<string,object>{
                    // 必须，商品类别码，商品类别码参考链接 ：https://www.pingxx.com/api#易宝支付商品类型码
                    {"product_category",1},
                    // 必须，用户标识,商户生成的用户账号唯一标识，最长 50 位字符串。
                    {"identity_id", "12345678901234567890"},
                    // 必须，用户标识类型，用户标识类型参考链接：https://www.pingxx.com/api#易宝支付用户标识类型码 。
                    {"identity_type", 1},
                    // 必须，终端类型，对应取值 0:IMEI, 1:MAC, 2:UUID, 3:other。
                    {"terminal_type", 1},
                    // 必须，终端 ID。
                    {"terminal_id", "your terminal_id"},
                    // 必须，用户使用的移动终端的 UserAgent 信息。
                    {"user_ua", "your user_ua"},
                    // 必须，前台通知地址。
                    {"result_url", "http://example.com/success"}
                }},
                // 可选：订单失效时间，用 Unix 时间戳表示。时间范围在订单创建后的 1 分钟到 15 天，默认为 1 天,创建时间以 Ping++ 服务器时间为准。 微信对该参数的有效值限制为 2 小时内；银联对该参数的有效值限制为 1 小时内。
                {"time_expire", timeExpire()},
                // 可选：订单附加说明，最多 255 个 Unicode 字符。
                {"description", "Your chare description"},
            };

            return Charge.Create(chParams);
        }

        /// <summary>
        /// 获取过期时间时间戳
        /// </summary>
        /// <returns></returns>
        public static long timeExpire(int hour = 1)
        {
            System.DateTime time = DateTime.Now;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds + 3600 * hour; 
        }

        public static String randomStr(int length) 
        {
            string result = "";
            System.Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                result += random.Next(10).ToString();
            }
            return result;
        }
    }
}
