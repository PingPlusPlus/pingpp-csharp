using System;
using System.Collections.Generic;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    public class TransferDemo
    {
        ///<summary>
        ///本示例只介绍如何发送企业付款请求，以及如何查询指定 Transfer 对象和 Transfer 列表，取消指定 Transfer
        ///获取到了 Transfer 对象后，不需要客户端做任何处理，指定的用户会在微信客户端收到企业付款消息
        /// </summary>

        public static void Example(string appId)
        {
            Console.WriteLine("****创建 Transfer 对象- alipay 渠道****");
            Console.WriteLine(alipayTransfer(appId));
            Console.WriteLine();

            Console.WriteLine("****创建 Transfer 对象- allinpay 渠道****");
            Console.WriteLine(allinpayTransfer(appId));
            Console.WriteLine();

            Console.WriteLine("****创建 Transfer 对象- jdpay 渠道****");
            Console.WriteLine(jdpayTransfer(appId));
            Console.WriteLine();

            Console.WriteLine("****创建 Transfer 对象- unionpay 渠道****");
            Console.WriteLine(unionpayTransfer(appId));
            Console.WriteLine();

            Console.WriteLine("****创建 Transfer 对象- wx_pub 渠道****");
            var tr = wx_pubTransfer(appId);
            Console.WriteLine(tr);
            Console.WriteLine();

            Console.WriteLine("****创建 Transfer 对象- balance 渠道****");
            Console.WriteLine(balanceTransfer(appId));
            Console.WriteLine();

            Console.WriteLine("****查询指定 Transfer 对象****");
            Console.WriteLine(Transfer.Retrieve(tr.Id));
            Console.WriteLine();

            Console.WriteLine("****查询 Transfer 对象列表****");
            var listParams = new Dictionary<string, object>() {
                {"app", new Dictionary<string, string >{
                    {"id", appId}
                }},
                {"limit", 5} // 限制每页可以返回多少对象，范围为 1-100 项，默认是 10 项。
            };
            Console.WriteLine(Transfer.List(new Dictionary<string, object> { { "limit", 3 } }));
            Console.WriteLine();
        }

        /// <summary>
        /// 创建 Transfer 对象-alipay 渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Transfer alipayTransfer(String appId)
        {
            var trParams = new Dictionary<string, object>
            {
                // 付款使用的商户内部订单号。 alipay 为 1 ~ 64 位不能重复的数字字母组合;
                {"order_no", new Random().Next(1, 999999999).ToString()},
                 // 订单总金额, 人民币单位：分（如订单总金额为 1 元，此处请填 100,企业付款最小发送金额为1 元）
                {"amount", 100},
                // 目前支持 支付宝：alipay，银联：unionpay，微信公众号：wx_pub，通联：allinpay，京东：jdpay
                {"channel", "alipay"},
                {"currency", "cny"},
                // 付款类型，支持 b2c 、b2b
                {"type", "b2c"},
                // 接收者 id， 渠道为 alipay 时，若 type 为 b2c，为个人支付宝账号，若 type 为 b2b，为企业支付宝账号。
                {"recipient", "Your recipient id"},
                // 备注信息。渠道为 alipay 时，最多 100 个 Unicode 字符。
                {"description", "Description"},
                {"app", new Dictionary<string, string> {{"id", appId}}},
                {"extra", new Dictionary<string, object>
                    {
                        // 必须，收款人姓名，1~50位。
                        {"recipient_name", "张三"},
                        // 可选，收款方账户类型。可取值：1、 ALIPAY_USERID ：支付宝账号对应的支付宝唯一用户号。以2088开头的16位纯数字组成。
                        //                           2、 ALIPAY_LOGONID （默认值）：支付宝登录号，支持邮箱和手机号格式。
                        {"recipient_account_type", "ALIPAY_LOGONID"}
                    }
                }
            };

            return Transfer.Create(trParams);
        }

        /// <summary>
        /// 创建 Transfer 对象-allinpay 渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Transfer allinpayTransfer(String appId)
        {
            var trParams = new Dictionary<string, object>
            {
                // 付款使用的商户内部订单号。 allinpay 限长20-40位不能重复的数字字母组合，必须以签约的通联的商户号开头（建议组合格式：通联商户号 + 时间戳 + 固定位数顺序流水号，不包含+号）
                {"order_no", randomStr(20)},
                 // 订单总金额, 人民币单位：分（如订单总金额为 1 元，此处请填 100,企业付款最小发送金额为1 元）
                {"amount", 100},
                // 目前支持 支付宝：alipay，银联：unionpay，微信公众号：wx_pub，通联：allinpay，京东：jdpay
                {"channel", "allinpay"},
                {"currency", "cny"},
                // 付款类型，支持 b2c 、b2b
                {"type", "b2c"},
                {"description", "Description"},
                {"app", new Dictionary<string, string> {{"id", appId}}},
                {"extra", new Dictionary<string, object>
                    {
                        // 必须，1~32位，收款人银行卡号或者存折号。
                        {"card_number", "6220888888888888"},
                        // 必须，1~100位，收款人姓名。
                        {"user_name", "张三"},
                        // 必须，4位，开户银行编号，详情请参考 企业付款（银行卡）银行编号说明：必须，4位，开户银行编号，详情请参考 企业付款（银行卡）银行编号说明：https://www.pingxx.com/api#银行编号说明
                        {"open_bank_code", "0103"},
                        // 可选，5位，业务代码，根据通联业务人员提供，不填使用通联提供默认值09900。
                        //{"business_code", "09900"},
                        // 可选，1位，银行卡号类型，0：银行卡、1：存折，不填默认使用银行卡。
                        //{"card_type", 0}
                    }
                }
            };

            return Transfer.Create(trParams);
        }

        /// <summary>
        /// 创建 Transfer 对象-jdpay 渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Transfer jdpayTransfer(String appId)
        {
            var trParams = new Dictionary<string, object>
            {
                // 付款使用的商户内部订单号。 jdpay 限长1-64位不能重复的数字字母组合；
                {"order_no", new Random().Next(1, 999999999).ToString()},
                 // 订单总金额, 人民币单位：分（如订单总金额为 1 元，此处请填 100,企业付款最小发送金额为1 元）
                {"amount", 100},
                // 目前支持 支付宝：alipay，银联：unionpay，微信公众号：wx_pub，通联：allinpay，京东：jdpay
                {"channel", "jdpay"},
                {"currency", "cny"},
                // 付款类型，支持 b2c 、b2b
                {"type", "b2c"},
                // 备注信息。渠道为 jdpay 最多100个 Unicode 字符。
                {"description", "Description"},
                {"app", new Dictionary<string, string> {{"id", appId}}},
                {"extra", new Dictionary<string, object>
                    {
                        // 必须，1~32位，收款人银行卡号或者存折号。
                        {"card_number", "6220888888888888"},
                        // 必须，1~100位，收款人姓名。
                        {"user_name", "张三"},
                        // 必须，4位，开户银行编号，详情请参考 企业付款（银行卡）银行编号说明：必须，4位，开户银行编号，详情请参考 企业付款（银行卡）银行编号说明：https://www.pingxx.com/api#银行编号说明
                        {"open_bank_code", "0103"}
                    }
                }
            };

            return Transfer.Create(trParams);
        }

        /// <summary>
        /// 创建 Transfer 对象-unionpay 渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Transfer unionpayTransfer(String appId)
        {
            var trParams = new Dictionary<string, object>
            {
                // 付款使用的商户内部订单号。 unionpay 为1~16位的纯数字。
                {"order_no", new Random().Next(1, 999999999).ToString()},
                 // 订单总金额, 人民币单位：分（如订单总金额为 1 元，此处请填 100,企业付款最小发送金额为1 元）
                {"amount", 100},
                // 目前支持 支付宝：alipay，银联：unionpay，微信公众号：wx_pub，通联：allinpay，京东：jdpay
                {"channel", "unionpay"},
                {"currency", "cny"},
                // 付款类型，支持 b2c 、b2b
                {"type", "b2c"},
                // 备注信息。渠道为 unionpay 时，最多 99 个 Unicode 字符
                {"description", "Description"},
                {"app", new Dictionary<string, string> {{"id", appId}}},
                {"extra", new Dictionary<string, object>
                    {
                        // 必须，1~32位，收款人银行卡号或者存折号。
                        {"card_number", "6220888888888888"},
                        // 必须，1~100位，收款人姓名。
                        {"user_name", "张三"},
                        /// open_bank_code 和 open_bank 两个参数必传一个，建议使用 open_bank_code ，
                        /// 若都传参则优先使用 open_bank_code 读取规则；
                        /// prov 和 city 均为可选参数，如果不传参，则使用默认值 "上海" 给渠道接口。
                        // 条件可选，4位，开户银行编号，详情请参考 企业付款（银行卡）银行编号说明：必须，4位，开户银行编号，详情请参考 企业付款（银行卡）银行编号说明：https://www.pingxx.com/api#银行编号说明
                        {"open_bank_code", "0103"},
                        // 条件可选，1~50位，开户银行，详情请参考 企业付款（银行卡）银行编号说明：https://www.pingxx.com/api#银行编号说明
                        {"open_bank", "农业银行"},
                        // 可选，1～20位，省份。
                        //{"prov", "上海"},
                        // 可选，1～40位，城市。
                        //{"city", "上海"},
                        // 可选，1～80位，开户支行名称。
                        //{"sub_bank", "上海沪东支行"}
                    }
                }
            };

            return Transfer.Create(trParams);
        }

        /// <summary>
        /// 创建 Transfer 对象-wx_pub 渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Transfer wx_pubTransfer(String appId)
        {
            var trParams = new Dictionary<string, object>
            {
                // 付款使用的商户内部订单号。 wx_pub 规定为 1 ~ 50 位不能重复的数字字母组合;
                {"order_no", new Random().Next(1, 999999999).ToString()},
                 // 订单总金额, 人民币单位：分（如订单总金额为 1 元，此处请填 100,企业付款最小发送金额为1 元）
                {"amount", 100},
                // 目前支持 支付宝：alipay，银联：unionpay，微信公众号：wx_pub，通联：allinpay，京东：jdpay
                {"channel", "wx_pub"},
                {"currency", "cny"},
                // 付款类型，支持 b2c 、b2b
                {"type", "b2c"},
                // 备注信息。渠道为 wx_pub 时，最多 99 个英文和数字的组合或最多 33 个中文字符，不可以包含特殊字符；
                {"description", "Description"},
                // 接收者 id， 微信企业付款时为用户在 wx_pub 下的 open_id ;
                {"recipient", "openidxxxxxxxxxxx"},
                {"app", new Dictionary<string, string> {{"id", appId}}},
                {"extra", new Dictionary<string, object>
                    {
                        // 可选，收款人姓名。当该参数为空，则不校验收款人姓名。
                        //{"user_name", "张三"},
                        // 可选，是否强制校验收款人姓名。仅当  user_name 参数不为空时该参数生效。
                        //{"force_check", true}
                    }
                }
            };

            return Transfer.Create(trParams);
        }

        /// <summary>
        /// 创建 Transfer 对象-balance 渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Transfer balanceTransfer(String appId)
        {
            var trParams = new Dictionary<string, object>
            {
                // 付款使用的商户内部订单号。 wx_pub 规定为 1 ~ 50 位不能重复的数字字母组合;
                {"order_no", new Random().Next(1, 999999999).ToString()},
                 // 订单总金额, 人民币单位：分（如订单总金额为 1 元，此处请填 100,企业付款最小发送金额为1 元）
                {"amount", 100},
                // 目前支持 支付宝：alipay，银联：unionpay，微信公众号：wx_pub，通联：allinpay，京东：jdpay
                {"channel", "balance"},
                {"currency", "cny"},
                // 付款类型，支持 b2c 、b2b
                {"type", "b2c"},
                // 备注信息。渠道为 wx_pub 时，最多 99 个英文和数字的组合或最多 33 个中文字符，不可以包含特殊字符；
                {"description", "Description"},
                // 接收者 id， 微信企业付款时为用户在 wx_pub 下的 open_id ;
                {"app", new Dictionary<string, string> {{"id", appId}}}
            };

            return Transfer.Create(trParams);
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
