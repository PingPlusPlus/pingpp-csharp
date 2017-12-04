using System;
using System.Collections.Generic;
using System.Linq;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    internal class RoyaltyTemplateDemo
    {
        /// <summary>
        /// 本示例介绍分润模板`创建,查询,删除,查询对象列表
        /// </summary>
        public static void Example(string appId)
        {
            var createParams = new Dictionary<string, object> 
            {
                {"app", appId},
                {"name", "Your Royalty Template Name"}, //模板名称，允许中英文等常用字符
                {"rule", new Dictionary<string,object>{
                    {"royalty_mode","rate"},            //分润模式。分为按订单金额（包含优惠券金额）的比例 rate 和固定金额 fixed
                    {"refund_mode", "full_refund"},     //退分润模式。分为退款时不退分润 no_refund、按比例退分润 proportional 和一旦退款分润全退 full_refund
                    {"allocation_mode", "receipt_reserved"},    //分配模式。指当订单确定的层级如果少于模板配置层级时，模板中多余的分润金额是归属于收款方 receipt_reserved 还是服务方 service_reserved。
                    {"data", new List<Dictionary<string,object>>{
                        new Dictionary<string,object>{
                            {"level", 1},                   //子商户层级值，0 表示平台， 1 表示一级子商户，取值范围 >=0
                            {"value", 20}                   //分润数值。rate 下取值为 0 - 10000，单位为 0.01 %，fixed 下取值为 0 - 1000000，单位为分
                        },
                        new Dictionary<string,object>{
                            {"level", 2},
                            {"value", 10}
                        }
                    }}
                }}
            };
            Console.WriteLine("**** 创建分润模板 ****");
            Console.WriteLine(RoyaltyTemplate.Create(createParams));

            Console.WriteLine("**** 查询分润模板列表 ****");
            Console.WriteLine(RoyaltyTemplate.List(new Dictionary<string, object> {
                {"page", 1},
                {"per_page",10}
            }));

            Console.WriteLine("**** 查询分润模板 ****");
            Console.WriteLine(RoyaltyTemplate.Retrieve("451170814105500001"));

            var updateParams = new Dictionary<string, object> 
            {
                {"name", "Your New Royalty Template Name"},
                {"rule", new Dictionary<string,object>{
                    {"royalty_mode","fixed"},
                    {"refund_mode", "no_refund"},
                    {"allocation_mode", "service_reserved"},
                    {"data", new List<Dictionary<string,object>>{
                        new Dictionary<string,object>{
                            {"level", 1},
                            {"value", 21}
                        },
                        new Dictionary<string,object>{
                            {"level", 2},
                            {"value", 11}
                        }
                    }}
                }}
            };
            Console.WriteLine("**** 更新分润模板 ****");
            Console.WriteLine(RoyaltyTemplate.Update("451170814105500001", updateParams));
            Console.WriteLine("**** 删除分润模板 ****");
            Console.WriteLine(RoyaltyTemplate.Delete("451170814105500001"));
        }
    }
}
