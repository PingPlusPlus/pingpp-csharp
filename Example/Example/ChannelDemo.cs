using System;
using System.Collections.Generic;
using System.Linq;
using Pingpp;
using Pingpp.Models;


namespace Example.Example
{
    /// <summary>
    /// 本示例介绍子商户应用支付渠道创建，更新，查询，删除
    /// </summary>
    class ChannelDemo
    {
        public static void Example(string appId, string subAppId) 
        {
            Console.WriteLine("**** 创建sub_app channel 对象 ****");
            var param = new Dictionary<string, object> { 
                {"channel", "bfb"},
                {"banned", false},
                {"banned_msg", null},
                {"description", "The description for bfb"},
                {"params", new Dictionary<string,object>{
                    {"bfb_sp", "百度钱包合作密钥"},
                    {"fee_rate", 30},
                    {"bfb_key", "百度钱包合作密钥"}
                }}

            };
            Console.WriteLine(SubAppChannel.Create(appId, subAppId, param));
            Console.WriteLine();

            Console.WriteLine("****查询 sub_app channel ****");
            Console.WriteLine(SubAppChannel.Retrieve(appId, subAppId, "bfb"));
            Console.WriteLine();

            Console.WriteLine("**** 更新sub_app channel 对象 ****");
            var upParam = new Dictionary<string, object> {
                {"banned", false},
                {"banned_msg", null},
                {"description", "The new description for bfb"},
                {"params", new Dictionary<string,object>{
                    {"bfb_sp", "百度钱包合作密钥"},
                    {"fee_rate", 35},
                    {"bfb_key", "百度钱包合作密钥"}
                }}
                
            };
            Console.WriteLine(SubAppChannel.Update(appId, subAppId, "bfb", upParam));
            Console.WriteLine();

            Console.WriteLine("**** 删除sub_app channel 对象 ****");
            Console.WriteLine(SubAppChannel.Delete(appId, subAppId, "bfb"));
            Console.WriteLine();
        }
    }
}
