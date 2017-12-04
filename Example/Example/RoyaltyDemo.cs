using System;
using System.Collections.Generic;
using System.Linq;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    /// <summary>
    /// 本示例介绍分润对象批量更新、查询、查询列表接口
    /// </summary>
    class RoyaltyDemo
    {
        public static void Example() 
        {
            Console.WriteLine("**** 查询royalty 对象 ****");
            var listParams = new Dictionary<string, object>{
                {"payer_app", "app_LibTW1n1SOq9Pin1"},
                {"source_app","app_LibTW1n1SOq9Pin1"},
                {"status", "created"},    //分润状态
                {"page", 1},
                {"per_page", 1}
            };
            Console.WriteLine(Royalty.List(listParams));


            Console.WriteLine("**** 查询royalty 列表 ****");
            Console.WriteLine(Royalty.Retrieve("421170321093600003"));
            Console.WriteLine();

            Console.WriteLine("**** 批量更新 royalty  ****");
            var updateParam = new Dictionary<string, object> {
                {"ids", new List<string>{
                    "170301124238000111",
                    "170301124238000211"
                }},
                {"method", "manual"},
                {"description", "Your description"}
            };
            Console.WriteLine(Royalty.Update(updateParam));
            Console.WriteLine();
        }
    }
}
