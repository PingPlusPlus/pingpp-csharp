using System;
using System.Collections.Generic;
using System.Linq;
using Pingpp;
using Pingpp.Models;


namespace Example.Example
{
    /// <summary>
    /// 本示例介绍结算账号创建、查询、删除、查询列表
    /// </summary>
    class SettleAccountDemo
    {
        public static void Example(string appId) 
        {
            Console.WriteLine("****查询 settle_account 列表****");
            Console.WriteLine(SettleAccount.List(appId, "test_user_002"));
            Console.WriteLine();


            var paramBankAccount = new Dictionary<string, object> {
                {"channel","bank_account"},
                {"recipient", new Dictionary<string,object>{
                    {"account", "6214666666666666"},    //接收者银行卡账号。
                    {"name", "张三"},                    //接收者姓名。
                    {"type", "b2c"},                    //转账类型。b2c：企业向个人付款，b2b：企业向企业付款。
                    {"open_bank", "招商银行"},           //开户银行。
                    {"open_bank_code", "0308"},         //业务代码，根据通联业务人员提供，不填使用通联提供默认值 09900。
                    {"business_code","09900"},          //业务代码，根据通联业务人员提供，不填使用通联提供默认值 09900。
                    {"card_type", 0},                   //银行卡号类型，0：银行卡；1：存折。
                    {"prov", "上海市"},                  //开户银行所在省份。
                    {"city", "上海市"},                  //开户银行所在城市。
                    {"term_type", "07"},                //代付业务使用场景, 07: 互联网, 08: 移动端。
                    {"sub_bank", "陆家嘴支行"}           //开户支行名称。
                }}
            };
            Console.WriteLine("**** 创建 settle_account-bank_account 渠道 对象 ****");
            Console.WriteLine(SettleAccount.Create(appId, "test_user_002", paramBankAccount));
            Console.WriteLine();

            var paramAlipay = new Dictionary<string, object> {
                {"channel","alipay"},
                {"recipient", new Dictionary<string,object>{
                    {"account", "13166666666"},
                    {"name", "接收者姓名"},
                    {"type", "b2c"}, 
                }}
            };
            Console.WriteLine("**** 创建 settle_account 对象-alipay渠道 ****");
            Console.WriteLine(SettleAccount.Create(appId, "test_user_002", paramAlipay));
            Console.WriteLine();

            var paramWxpub = new Dictionary<string, object> {
                {"channel","wx_pub"},
                {"recipient", new Dictionary<string,object>{
                    {"account", "接收者open_id"},
                    {"name", "王五"}, //收款人姓名。当该参数为空，则不校验收款人姓名。
                    {"type", "b2c"},    //转账类型。b2c：企业向个人付款，b2b：企业向企业付款。
                    {"force_check", false}, //是否强制校验收款人姓名。仅当 name 参数不为空时该参数生效。
                }}
            };
            Console.WriteLine("**** 创建 settle_account 对象-wx_pub渠道 ****");
            Console.WriteLine(SettleAccount.Create(appId, "test_user_002", paramWxpub));
            Console.WriteLine();

            Console.WriteLine("**** 查询 settle_account 对象 ****");
            Console.WriteLine(SettleAccount.Retrieve(appId, "test_user_002", "320217032111554400000901"));

            Console.WriteLine("**** 删除settle_account 对象 ****");
            Console.WriteLine(SettleAccount.Delete(appId, "test_user_002", "320217032111554400000901"));
            Console.WriteLine();

            Console.WriteLine("****查询 settle_account 列表****");
            Console.WriteLine(SettleAccount.List(appId, "test_user_002"));
            Console.WriteLine();
        }
    }
}
