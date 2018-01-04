using System;
using System.Collections.Generic;
using System.Linq;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    class BatchTransferDemo
    {
        /// <summary>
        /// 本示例介绍批量付款对象创建、对象列表和明细查询
        /// </summary>
        /// <param name="appId"></param>
        public static void Example(string appId)
        {
            Console.WriteLine("****创建批量转账 batch_transfers-对象（alipay渠道）****");
            Console.WriteLine(alipayBatchTransfer(appId));
            Console.WriteLine();

            Console.WriteLine("****创建批量转账 batch_transfers-对象（allinpay渠道）****");
            Console.WriteLine(allinpayBatchTransfer(appId));
            Console.WriteLine();

            Console.WriteLine("****创建批量转账 batch_transfers-对象（jdpay渠道）****");
            Console.WriteLine(jdpayBatchTransfer(appId));
            Console.WriteLine();

            Console.WriteLine("****创建批量转账 batch_transfers-对象（unionpay渠道）****");
            Console.WriteLine(unionpayBatchTransfer(appId));
            Console.WriteLine();

            Console.WriteLine("****创建批量转账 batch_transfers-对象（wx_pub渠道）****");
            var batchTranster = wx_pubBatchTransfer(appId);
            Console.WriteLine(batchTranster);
            Console.WriteLine();

            Console.WriteLine("****创建批量转账 batch_transfers-对象（ balance 渠道）****");
            Console.WriteLine(balanceBatchTransfer(appId));
            Console.WriteLine();


            Console.WriteLine("****查询批量转账明细 batch_transfers 对象****");
            Console.WriteLine(BatchTransfer.Retrieve(batchTranster.Id));
            Console.WriteLine();

            var listParams = new Dictionary<string, object>
            {
                {"page", 1},    //页码，取值范围：1~1000000000；默认值为"1"
                {"per_page", 10}    //每页数量，取值范围：1～100；默认值为"10"
            };

            Console.WriteLine("****查询批量转账明细 batch_transfers 对象****");
            Console.WriteLine(BatchTransfer.List(listParams));
            Console.WriteLine();
        }

        /// <summary>
        ///  批量转账-创建(alipay 渠道)
        /// </summary>
        public static BatchTransfer alipayBatchTransfer(String appId)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            list.Add(new Dictionary<string, object>
            {
                // 必须，接收者支付宝账号。
                {"account", "account01@alipay.com"},
                //必须，金额，单位为分。
                {"amount", 5000},
                // 必须，接收者姓名
                {"name", "李狗"},
                //可选，批量企业付款描述，最多 200 字节。
                {"description", "Your description"},
                // 可选，账户类型，alipay 2.0 渠道会用到此字段，取值范围： 1、ALIPAY_USERID：支付宝账号对应的支付宝唯一用户号。2088开头的16位纯数字组成。
                //                                                  2、ALIPAY_LOGONID（默认值）：支付宝登录号，支持邮箱和手机号格式。
                {"account_type", "ALIPAY_LOGONID"},
                //可选，订单号， 1 ~ 64 位不能重复的数字字母组合。
                {"order_no", "123456789"}
            });
            list.Add(new Dictionary<string, object>
            {
                {"account", "account02@alipay.com"},
                {"amount", 3000},
                {"name", "伢子"},
            });

            var btParams = new Dictionary<string, object>
            {
                {"amount",8000},//批量付款总金额，单位为分。为 recipients 中 amount 的总和。
                {"app", appId},
                {"batch_no", "2017042810380015"},//批量转账批次号，3-24位，允许字母和英文
                {"channel", "alipay"},  //目前支持 渠道。支付宝：alipay，银联：unionpay，微信公众号：wx_pub，通联：allinpay，京东：jdpay
                {"description", "Batch trans description."},
                {"type", "b2c"}, //付款类型 (当前 alipay、wx_pub 仅支持: b2c, unionpay、allinpay、jdpay 支持:  b2b、b2c)
                {"recipients", list}
            };

            return BatchTransfer.Create(btParams);
        }

        /// <summary>
        /// 批量转账-创建示例(allinpay 渠道)
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static BatchTransfer allinpayBatchTransfer(String appId)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            list.Add(new Dictionary<string, object>
            {
                // 必须，接收者银行卡账号。
                {"account", "656565656565656565656562"},
                //必须，金额，单位为分。
                {"amount", 5000},
                // 必须，接收者姓名
                {"name", "李狗"},
                // 必须，4位，开户银行编号。具体值参考此链接 https://www.pingxx.com/api#银行编号说明
                {"open_bank_code","0308"},
                // 可选，批量付款描述，最多 30 个 Unicode 字符。
                //{"description", "Your description"},
                // 可选，业务代码，allinpay 渠道会用到此字段，5位，根据通联业务人员提供，不填使用通联提供默认值09900。
                //{"business_code","09900"},
                // 可选，银行卡号类型，allinpay 渠道会用到此字段，0：银行卡、1：存折，不填默认使用银行卡。
                //{"card_type", 0},
                // 可选，订单号， 20 ~ 40 位不能重复的数字字母组合（必须以通联的商户号开头，建议组合格式：通联商户号 + 时间戳 + 固定位数顺序流水号，不包含+号）
                // 这里不传的话程序会调用商户的通联商户号加上随机数自动生成 order_no。
                {"order_no","321101234554321098765432112"}

            });
            list.Add(new Dictionary<string, object>
            {
                {"account", "656565656565656565656565"},
                {"amount", 3000},
                {"name", "李四"},
                {"open_bank_code", "0308"},
            });

            var btParams = new Dictionary<string, object>
            {
                {"amount",8000},//批量付款总金额，单位为分。为 recipients 中 amount 的总和。
                {"app", appId},
                {"batch_no", "2017042810380015"},//批量转账批次号，3-24位，允许字母和英文
                {"channel", "allinpay"},  //目前支持 渠道。支付宝：alipay，银联：unionpay，微信公众号：wx_pub，通联：allinpay，京东：jdpay
                {"description", "Batch trans description."},
                {"type", "b2c"}, //付款类型 (当前 alipay、wx_pub 仅支持: b2c, unionpay、allinpay、jdpay 支持:  b2b、b2c)
                {"recipients", list}
            };

            return BatchTransfer.Create(btParams);
        }

        /// <summary>
        /// 批量转账-创建示例(jdpay 渠道)
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static BatchTransfer jdpayBatchTransfer(String appId)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            list.Add(new Dictionary<string, object>
            {
                //必须，接收者银行卡账号。
                {"account", "656565656565656565656562"},
                //必须，金额，单位为分。
                {"amount", 5000},
                //必须，接收者姓名
                {"name", "李狗"},
                //必须，4位，开户银行编号。具体值参考此链接 https://www.pingxx.com/api#银行编号说明
                {"open_bank_code","0308"},
                //可选，批量付款描述，最多 30 个 Unicode 字符。
                //{"description", "Your description"},
                // 可选，订单号，jdpay 限长1-64位不能重复的数字字母组合。
                {"order_no","12345678"}

            });
            list.Add(new Dictionary<string, object>
            {
                {"account", "656565656565656565656565"},
                {"amount", 3000},
                {"name", "李四"},
                {"open_bank_code", "0308"},
            });

            var btParams = new Dictionary<string, object>
            {
                {"amount",8000},//批量付款总金额，单位为分。为 recipients 中 amount 的总和。
                {"app", appId},
                {"batch_no", "2017042810380015"},//批量转账批次号，3-24位，允许字母和英文
                {"channel", "jdpay"},  //目前支持 渠道。支付宝：alipay，银联：unionpay，微信公众号：wx_pub，通联：allinpay，京东：jdpay
                {"description", "Batch trans description."}, //批量转账详情，最多 255 个 Unicode 字符
                {"type", "b2c"}, //付款类型 (当前 alipay、wx_pub 仅支持: b2c, unionpay、allinpay、jdpay 支持:  b2b、b2c)
                {"recipients", list}
            };

            return BatchTransfer.Create(btParams);
        }

        /// <summary>
        /// 批量转账-创建示例(unionpay 渠道)
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static BatchTransfer unionpayBatchTransfer(String appId)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            list.Add(new Dictionary<string, object>
            {
                //必须，接收者银行卡账号。
                {"account", "656565656565656565656562"},
                //必须，金额，单位为分。
                {"amount", 5000},
                //必须，接收者姓名
                {"name", "李狗"},
                //可选，批量企业付款描述，最多 200 字节。
                //{"description", "Your description"},
                // open_bank_code 和 open_bank 两个参数必传一个，建议使用 open_bank_code ，若都传参则优先使用 open_bank_code 读取规则。
                //条件可选，1~50位，开户银行。
                {"open_bank", "招商银行"},
                //条件可选，4位，开户银行编号 具体值参考此链接 https://www.pingxx.com/api#银行编号说明
                {"open_bank_code", "0308"},
                // 可选，订单号， 1 ~ 16 位数字。
                {"order_no","12345678"}

            });
            list.Add(new Dictionary<string, object>
            {
                {"account", "656565656565656565656565"},
                {"amount", 3000},
                {"name", "李四"},
                {"open_bank", "招商银行"},
                {"open_bank_code", "0308"},
            });

            var btParams = new Dictionary<string, object>
            {
                {"amount",8000},//批量付款总金额，单位为分。为 recipients 中 amount 的总和。
                {"app", appId},
                {"batch_no", "2017042810380015"},//批量转账批次号，3-24位，允许字母和英文
                {"channel", "unionpay"},  //目前支持 渠道。支付宝：alipay，银联：unionpay，微信公众号：wx_pub，通联：allinpay，京东：jdpay
                {"description", "Batch trans description."}, //批量转账详情，最多 255 个 Unicode 字符
                {"type", "b2c"}, //付款类型 (当前 alipay、wx_pub 仅支持: b2c, unionpay、allinpay、jdpay 支持:  b2b、b2c)
                {"recipients", list}
            };

            return BatchTransfer.Create(btParams);
        }

        /// <summary>
        /// 批量转账-创建示例(wx_pub 渠道)
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static BatchTransfer wx_pubBatchTransfer(String appId)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            list.Add(new Dictionary<string, object>
            {
                //必须，接收者 id，为用户在 wx_pub 下的 open_id。
                {"open_id", "openidxxxxxxxxxxxx"},
                //必须，金额，单位为分。
                {"amount", 5000},
                //可选，收款人姓名。当该参数为空，则不校验收款人姓名。
                {"name", "李狗"},
                //可选，批量企业付款描述，最多 99 个英文和数字的组合或最多 33 个中文字符，不可以包含特殊字符。不填默认使用外层参数中的 description。
                //{"description", "Your description"},

                // 可选，是否强制校验收款人姓名。布尔类型，仅当 name 参数不为空时该参数生效。
                {"force_check", false},
                // 可选，订单号， 1 ~ 32 位不能重复的数字字母组合。
                {"order_no","12345678"}

            });
            list.Add(new Dictionary<string, object>
            {
                {"open_id", "openidxxxxxxxxxxxx"},
                {"amount",3000},
            });

            var btParams = new Dictionary<string, object>
            {
                {"amount",8000},//批量付款总金额，单位为分。为 recipients 中 amount 的总和。
                {"app", appId},
                {"batch_no", "2017042810380015"},//批量转账批次号，3-24位，允许字母和英文
                {"channel", "wx_pub"},  //目前支持 渠道。支付宝：alipay，银联：unionpay，微信公众号：wx_pub，通联：allinpay，京东：jdpay
                {"description", "Batch trans description."}, //批量转账详情，最多 255 个 Unicode 字符
                {"type", "b2c"}, //付款类型 (当前 alipay、wx_pub 仅支持: b2c, unionpay、allinpay、jdpay 支持:  b2b、b2c)
                {"recipients", list}
            };

            return BatchTransfer.Create(btParams);
        }

        /// <summary>
        /// 批量转账-创建示例(balance 渠道)
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static BatchTransfer balanceBatchTransfer(String appId)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            list.Add(new Dictionary<string, object>
            {
                //必须，接收者用户 ID。
                {"user", "user_001"},
                //必须，金额，单位为分。
                {"amount", 5000},
                //不填默认使用外层参数中的 description	批量付款描述，最多 100 个 Unicode 字符。
                {"description", "Your description"},
                //可选 订单号， 1 ~ 64 位不能重复的数字字母组合。
                {"order_no", "2017080800000001"}
            });
            list.Add(new Dictionary<string, object>
            {
                {"user", "user_002"},
                {"amount", 3000},
                {"description", "Your description"},
                {"order_no", "2017080800000002"},
            });

            var btParams = new Dictionary<string, object>
            {
                {"amount",8000},//批量付款总金额，单位为分。为 recipients 中 amount 的总和。
                {"app", appId},
                {"batch_no", "2017080810000001"},//批量转账批次号，3-24位，允许字母和英文
                {"channel", "balance"},  //目前支持 渠道。支付宝：alipay，银联：unionpay，微信公众号：wx_pub，通联：allinpay，京东：jdpay,余额 balance
                {"description", "Batch trans description."}, //批量转账详情，最多 255 个 Unicode 字符
                {"type", "b2c"}, //付款类型 (当前 alipay、wx_pub 仅支持: b2c, unionpay、allinpay、jdpay 支持:  b2b、b2c)
                {"recipients", list}
            };

            return BatchTransfer.Create(btParams);
        }
    }
}
