using System;
using System.Collections.Generic;
using System.Linq;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    /// <summary>
    /// 本示例介绍分润结算对象创建、查询、更新、查询列表
    /// </summary>
    public class RoyaltySettlementDemo
    {
        public static void Example() 
        {
            var createParam = new Dictionary<string, object> { 
                {"payer_app", "app_LibTW1n1SOq9Pin1"},  //分润发起方所在应用的 id
                {"method", "alipay"},                   //分润的方式，余额 balance 或渠道名称，例如 alipay
                {"recipient_app", "app_1Gqj58ynP0mHeX1q"},//分润接收方的应用 id，即分润用户关联的应用 id。
                {"created", new Dictionary<string,object>{
                    {"gt"   , 1488211200},
                    {"lte"  , 1488297600}
                }},
                //{"source_user", "user_001"},  //按分润用户
                //{"source_no", "2017080088888"}, //  关联对象的商户订单号
                //{"min_amount", 1000},   //最小分润金额，汇总后金额小于最小分润金额时不会进入分润
                {"metadata", new Dictionary<string,object>{}}, //Metadata
                {"is_preview", false} ,//是否预览，选择预览不会真实创建分润结算对象，也不会修改分润对象的状态
            };
            Console.WriteLine("**** 创建royalty_settlement 对象 ****");
            Console.WriteLine(RoyaltySettlement.Create(createParam));
            Console.WriteLine();

            Console.WriteLine("**** 查询royalty_settlement 对象 ****");
            Console.WriteLine(RoyaltySettlement.Retrieve("431170321101800001"));
            Console.WriteLine();

            var updateParam = new Dictionary<string, object> {
                {"status", "canceled"}
            };
            Console.WriteLine("**** 更新royalty_settlement 对象 ****");
            Console.WriteLine(RoyaltySettlement.Update("431170321101800001", updateParam));
            Console.WriteLine();

            var listParam = new Dictionary<string, object> {
                {"payer_app", "app_LibTW1n1SOq9Pin1"}
            };
            Console.WriteLine("**** 查询royalty_settlement 对象列表 ****");
            Console.WriteLine(RoyaltySettlement.List(listParam));
            Console.WriteLine();
        }
    }
}
