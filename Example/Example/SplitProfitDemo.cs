using System;
using System.Collections.Generic;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    internal class SplitProfitDemo
    {
        public static void Example(string appId)
        {
            Console.WriteLine("****创建 split_profit　分账示例　****");
            Dictionary<string, object> createParams = new Dictionary<string, object> { 
                {"app", appId},
                {"charge", "ch_DqfvDSTSif1SjnTiP41KqbrH"},
                {"order_no", "190001001"},
                {"type", "split_normal"},
                {"recipients", new List<Dictionary<string,object>>{
                    new Dictionary<string,object>{
                        {"split_receiver", "recv_1fRbIszZftTGPa"}, //只有type为 split_normal 时支持填写
                        {"amount", 6},
                        //{"name", "示例商户全称"}, //可选参数;只有type为split_normal时支持填写；如果商家传递该字段则 Pingxx 需校验 name 与 split_receiver 是否对应
                        {"description", "Your Description"}
                    }
                }}
            };
            Console.WriteLine(SplitProfit.Create(createParams));
            Console.WriteLine();

            Console.WriteLine("****查询 split_profit 列表****");
            Dictionary<string, object> listParams = new Dictionary<string, object> { 
                {"app", appId},
                {"page", 1}
            };
            Console.WriteLine(SplitProfit.List(listParams));
            Console.WriteLine();

            Console.WriteLine("****查询 split_profit ****");
            Console.WriteLine(SplitProfit.Retrieve("recv_1fRbIszF3tAuPy"));
            Console.WriteLine();
        }
    }
}
