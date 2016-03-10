using System;
using System.Collections.Generic;
using Pingpp.Models;

namespace Example.Example
{
    internal class RedEnvelopeDemo
    {
        ///<summary>
        ///本示例只介绍如何发送红包请求，以及如何查询指定 RedEnvelope 对象和 RedEnvelope 列表，
        ///获取到了 RedEnvelope 对象后，不需要客户端做任何处理，指定的用户会在微信客户端收到红包消息
        ///</summary>
        public static RedEnvelope Example(string appId)
        {
            var redParams = new Dictionary<string, object>
            {
                {"order_no", new Random().Next(1, 999999999)},
                {"amount", 100},
                {"channel", "wx_pub"},
                {"currency", "cny"},
                {"subject", "Your Subject"},
                {"body", "Your Body"},
                {"recipient", "Your Recipient Id"},
                {"description", "Description"},
                {"extra",  new Dictionary<string, object> {{"nick_name", "nick name"}, {"send_name", "send name"}}},
                {"app", new Dictionary<string, string> {{"id", appId}}}
            };

            var red = RedEnvelope.Create(redParams);
            Console.WriteLine("****创建 RedEnvelope 对象****");
            Console.WriteLine(red);
            Console.WriteLine();


            Console.WriteLine("****查询指定 RedEnvelope 对象****");
            Console.WriteLine(RedEnvelope.Retrieve(red.Id));
            Console.WriteLine();

            Console.WriteLine("****查询 RedEnvelope 对象列表****");
            Console.WriteLine(RedEnvelope.List(new Dictionary<string, object> {{"limit", 3}}));
            Console.WriteLine();

            return red;
        }
    }
}
