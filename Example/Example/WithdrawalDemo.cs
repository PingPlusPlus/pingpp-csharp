using System;
using System.Collections.Generic;
using Pingpp.Models;

namespace Example.Example
{
    internal class WithdrawalDemo
    {
        /// <summary>
        /// 本示例介绍如何创余额提现申请（Userwithdrawals 对象）、更新 Userwithdrawals 对象 获取列表和明细
        /// </summary>
        /// <param name="appId"></param>
        public static void Example(string appId) 
        {
            Console.WriteLine("****发起余额提现请求创建余额体现 withdrawals对象-unionpay渠道****");
            var withDrawal = unionpayWithdrawal(appId);
            Console.WriteLine(withDrawal);
            Console.WriteLine();

            Console.WriteLine("****发起余额提现请求创建余额体现 withdrawals对象-alipay渠道****");
            Console.WriteLine(alipayWithdrawal(appId));
            Console.WriteLine();

            Console.WriteLine("****发起余额提现请求创建余额体现 withdrawals对象-wx_pub渠道****");
            Console.WriteLine(wxPubWithdrawal(appId));
            Console.WriteLine();

            Console.WriteLine("****发起余额提现请求创建余额体现 withdrawals对象-allinpay渠道****");
            Console.WriteLine(allinpayWithdrawal(appId));
            Console.WriteLine();

            Console.WriteLine("****发起余额提现请求创建余额体现 withdrawals对象-jdpay渠道****");
            Console.WriteLine(jdpayWithdrawal(appId));
            Console.WriteLine();

            var listParams = new Dictionary<string, object> {
                {"page", 1},
                {"per_page", 10},
                {"status", "created"},
                {"channel", "alipay"}   //提现使用渠道。银联：unionpay，支付宝：alipay，微信：wx_pub。
            };
            Console.WriteLine("****发起余额提现列表查询 Userwithdrawals 对象****");
            Console.WriteLine(Withdrawal.List(appId, listParams));

            Console.WriteLine("****余额提现对象查询 Userwithdrawals 对象****");
            Console.WriteLine(Withdrawal.Retrieve(appId, withDrawal.Id));

            Console.WriteLine("****发起余额提现请求确认 Userwithdrawals 对象****");
            Console.WriteLine(Withdrawal.Confirm(appId, withDrawal.Id));
            Console.WriteLine();

            Console.WriteLine("****发起余额提现请求取消 Userwithdrawals 对象****");
            Console.WriteLine(Withdrawal.Cancel(appId, withDrawal.Id));
            Console.WriteLine();
        }

        /// <summary>
        /// unionpay-渠道余额提现申请
        /// </summary>
        /// <returns></returns>
        public static Withdrawal unionpayWithdrawal(String appId) 
        {
            var createParams = new Dictionary<string, object> 
            {
                {"order_no", "2016111000039"}, //提现订单号,unionpay 为1~16位的纯数字;alipay 为 1 ~ 64 位不能重复的数字字母组合;allinpay 为通联商户号(10位数字) + 不重复流水号组合(10~30位 字母数字组合);wx_pub 规定为 1 ~ 50 位不能重复的数字字母组合;jdpay为 1~64 位不能重复的数字字母组合;
                {"amount" , 1}, //体现金额。
                {"user_fee", 0}, //用户需要承担的手续费。
                {"channel", "unionpay"}, //提现使用渠道。银联：unionpay，支付宝：alipay，微信：wx_pub，通联：allinpay，京东：jdpay。（v1.34.1）
                {"user", "user_001"},   //用户 ID。
                {"description", "Your description"}, //描述
                {"extra", new Dictionary<string, object>{
                    {"account", "6214850210294648"}, //收款人银行卡号或者存折号。
                    {"name", "张三"}, //收款人姓名。
                    {"open_bank_code", "0308"}, //开户银行编号，open_bank_code 和 open_bank 必须填写一个，优先推荐填写 open_bank_code
                    {"open_bank", "招商银行"}, //开户银行，open_bank_code 和 open_bank 必须填写一个，优先推荐填写 open_bank_code。
                    {"prov", "上海"}, //省份。
                    {"city", "上海"}, //城市。
                    {"sub_bank","徐家汇支行"} // 开户支行名称。
                }},
                //{"settle_account", "320217081417114300000501"}    //使用结算账户提现，不需要填写 channel 和 extra 相关参数，同时填写时，结算账号不生效
            };
            return Withdrawal.Request(appId,createParams);
        }

        /// <summary>
        /// alipay-渠道余额体现申请
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Withdrawal alipayWithdrawal(string appId) 
        {
            var createParams = new Dictionary<string, object> 
            {
                {"order_no", "2016111000032"}, //提现订单号,unionpay 为1~16位的纯数字;alipay 为 1 ~ 64 位不能重复的数字字母组合;allinpay 为通联商户号(10位数字) + 不重复流水号组合(10~30位 字母数字组合);wx_pub 规定为 1 ~ 50 位不能重复的数字字母组合;jdpay为 1~64 位不能重复的数字字母组合;
                {"amount" , 1}, //体现金额。
                {"user_fee", 0}, //用户需要承担的手续费。
                {"channel", "alipay"}, //提现使用渠道。银联：unionpay，支付宝：alipay，微信：wx_pub，通联：allinpay，京东：jdpay。（v1.34.1）
                {"user", "user_001"},   //用户 ID。
                {"description", "Your description"}, //描述
                {"extra", new Dictionary<string, object>{
                   {"account", "user@example.com"}, //收款人的支付宝账号。
                   {"name", "张三"},  //收款人姓名。
                   {"account_type", "ALIPAY_USERID"} //收款方账户类型。ALIPAY_USERID：支付宝账号对应的支付宝唯一用户号，以 2088 开头的 16 位纯数字组成；ALIPAY_LOGONID：支付宝登录号，支持邮箱和手机号格式。
                }},
                //{"settle_account", "320217081417114300000501"}    //使用结算账户提现，不需要填写 channel 和 extra 相关参数，同时填写时，结算账号不生效
            };
            return Withdrawal.Request(appId, createParams);
        }

        /// <summary>
        /// wx_pub/wx-渠道余额体现申请
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Withdrawal wxPubWithdrawal(string appId) 
        {
            var createParams = new Dictionary<string, object> 
            {
                {"order_no", "2016111000033"}, //提现订单号,unionpay 为1~16位的纯数字;alipay 为 1 ~ 64 位不能重复的数字字母组合;allinpay 为通联商户号(10位数字) + 不重复流水号组合(10~30位 字母数字组合);wx_pub 规定为 1 ~ 50 位不能重复的数字字母组合;jdpay为 1~64 位不能重复的数字字母组合;
                {"amount" , 1000}, //体现金额。
                {"user_fee", 0}, //用户需要承担的手续费。
                {"channel", "wx_pub"}, //提现使用渠道。银联：unionpay，支付宝：alipay，微信：wx_pub，通联：allinpay，京东：jdpay。（v1.34.1）
                {"user", "user_001"},   //用户 ID。
                {"description", "Your description"}, //描述
                {"extra", new Dictionary<string, object>{
                   {"open_id", "wxopenid"}, //收款人的 open_id。
                   {"name", "张三"},  //收款人姓名。
                   {"force_check", false} //是否强制校验收款人姓名。仅当 user_name 参数不为空时该参数生效。
                }},
                //{"settle_account", "320217081417114300000501"}    //使用结算账户提现，不需要填写 channel 和 extra 相关参数，同时填写时，结算账号不生效
            };
            return Withdrawal.Request(appId, createParams);
        }

        /// <summary>
        /// allinpay-渠道余额体现申请
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Withdrawal allinpayWithdrawal(string appId) 
        {
            var createParams = new Dictionary<string, object> 
            {
                {"order_no", "2665666666666622016111000001"}, //提现订单号,unionpay 为1~16位的纯数字;alipay 为 1 ~ 64 位不能重复的数字字母组合;allinpay 为通联商户号(10位数字) + 不重复流水号组合(10~30位 字母数字组合);wx_pub 规定为 1 ~ 50 位不能重复的数字字母组合;jdpay为 1~64 位不能重复的数字字母组合;
                {"amount" , 1}, //体现金额。
                {"user_fee", 0}, //用户需要承担的手续费。
                {"channel", "allinpay"}, //提现使用渠道。银联：unionpay，支付宝：alipay，微信：wx_pub，通联：allinpay，京东：jdpay。（v1.34.1）
                {"user", "user_001"},   //用户 ID。
                {"description", "Your description"}, //描述
                {"extra", new Dictionary<string, object>{
                   {"account", "6214850288888888"}, //收款人银行卡号或者存折号。
                   {"name", "张三"},  //	收款人姓名。
                   {"open_bank_code", "0308"}, //开户银行编号。
                   {"business_code", "09900"}, //业务代码，根据通联业务人员提供，不填使用通联提供默认值 09900。
                   {"card_type", 0} //银行卡号类型，0：银行卡；1：存折。
                }},
                //{"settle_account", "320217081417114300000501"}    //使用结算账户提现，不需要填写 channel 和 extra 相关参数，同时填写时，结算账号不生效
            };
            return Withdrawal.Request(appId, createParams);
        }

        /// <summary>
        /// jdpay-渠道余额体现申请
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Withdrawal jdpayWithdrawal(string appId) 
        {
            var createParams = new Dictionary<string, object> 
            {
                {"order_no", "2016111000035"}, //提现订单号,unionpay 为1~16位的纯数字;alipay 为 1 ~ 64 位不能重复的数字字母组合;allinpay 为通联商户号(10位数字) + 不重复流水号组合(10~30位 字母数字组合);wx_pub 规定为 1 ~ 50 位不能重复的数字字母组合;jdpay为 1~64 位不能重复的数字字母组合;
                {"amount" , 1}, //体现金额。
                {"user_fee", 0}, //用户需要承担的手续费。
                {"channel", "jdpay"}, //提现使用渠道。银联：unionpay，支付宝：alipay，微信：wx_pub，通联：allinpay，京东：jdpay。（v1.34.1）
                {"user", "user_001"},   //用户 ID。
                {"description", "Your description"}, //描述
                {"extra", new Dictionary<string, object>{
                   {"account", "6214850288888888"}, //收款人银行卡号或者存折号。
                   {"name", "张三"},  //	收款人姓名。
                   {"open_bank_code", "0308"} //开户银行编号。
                }},
                //{"settle_account", "320217081417114300000501"}    //使用结算账户提现，不需要填写 channel 和 extra 相关参数，同时填写时，结算账号不生效
            };
            return Withdrawal.Request(appId, createParams);
        }
    }
}
