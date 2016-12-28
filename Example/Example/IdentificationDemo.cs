using System;
using System.Collections.Generic;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    internal class IdentificationDemo
    {
        /// <summary>
        /// 本示例介绍如何进行身份认证
        /// </summary>
        public static void Example(string appId)
        {
            var iParams = new Dictionary<string, object>
            {
                {"type", "bank_card"},
                {"app", appId},
                {"data", new Dictionary<string, object>
                {
                    {"id_name", "张三"}, // 姓名
                    {"id_number", "310181198910107641"}, // 身份证号
                    {"card_number", "6201111122223333"}, // 银行卡号
                    {"phone_number", "18623234545"} // 银行预留手机号，不支持 178 号段
                }
                }
            };

            Console.WriteLine("****发起身份认证请求****");
            Console.WriteLine(Identification.Identify(iParams));
            Console.WriteLine();
        }
    }
}
