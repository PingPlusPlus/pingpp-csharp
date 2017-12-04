using System;
using System.Collections.Generic;
using System.Linq;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    /// <summary>
    /// 本示例介绍子商户创建、更新、删除，查询列表；
    /// </summary>
    public class SubAppDemo
    {
        public static void Example(string appId)
        {
            Console.WriteLine("****查询 sub_app 列表****");
            Console.WriteLine(SubApp.List(appId));
            Console.WriteLine();

            Console.WriteLine("**** 创建sub_app 对象 ****");
            var param = new Dictionary<string, object> {
                {"display_name", "sub_app_display_name"},
                {"user", "user_0003"},
                {"metadata", new Dictionary<string,object>{
                    {"key", "value"}
                }},
                {"description", "Your description"},
                //{"parent_app", "app_HC4yrTP44OGGLOyL"}
            };
            var subApp = SubApp.Create(appId, param);
            Console.WriteLine(subApp);
            Console.WriteLine();

            Console.WriteLine("**** 查询sub_app 对象 ****");
            Console.WriteLine(SubApp.Retrieve(appId, subApp.Id));

            Console.WriteLine("**** 更新sub_app 对象 ****");
            var upParam = new Dictionary<string, object> {
                {"display_name", "sub_app_display_name2"},
                {"metadata", new Dictionary<string,object>{
                    {"key", "value2"}
                }},
                {"description", "Your description2"},
                //{"parent_app", "app_HC4yrTP44OGGLOyL"}
            };

            Console.WriteLine(SubApp.Update(appId, subApp.Id, upParam));
            Console.WriteLine();

            Console.WriteLine("**** 删除sub_app 对象 ****");
            Console.WriteLine(SubApp.Delete(appId, subApp.Id));
            Console.WriteLine();
        }
    }
}
