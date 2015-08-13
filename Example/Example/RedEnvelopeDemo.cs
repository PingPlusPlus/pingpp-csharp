//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using pingpp;
//using pingpp.Models;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//namespace Example
//{
//    class RedEnvelopeDemo
//    {
//        ///<summary>
//        ///本示例只介绍如何发送红包请求，以及如何查询指定 RedEnvelope 对象和 RedEnvelope 列表，
//        ///获取到了 RedEnvelope 对象后，不需要客户端做任何处理，指定的用户会在微信客户端收到红包消息
//        ///</summary>
//        static void Main(string[] args)
//        {
//            // 设置 apikey
//            Pingpp.apiKey = "sk_test_ibbTe5jLGCi5rzfH4OqPW9KC";

//            // 设置 appid
//            Dictionary<string, string> app = new Dictionary<string, string>();
//            app.Add("id", "app_1Gqj58ynP0mHeX1q");

//            // 设置  extra
//            Dictionary<string, object> extra = new Dictionary<string, object>();
//            extra.Add("nick_name", "nick name");
//            extra.Add("send_name", "send name");

//            Random ra = new Random();
//            Dictionary<string, object> redenvelopeParam = new Dictionary<string, object>();
//            redenvelopeParam.Add("order_no", ra.Next(1, 999999999));
//            redenvelopeParam.Add("amount", 100);
//            redenvelopeParam.Add("channel", "wx_pub");
//            redenvelopeParam.Add("currency", "cny");
//            redenvelopeParam.Add("subject", "your subject");
//            redenvelopeParam.Add("body", "your body");
//            redenvelopeParam.Add("recipient", "asdfsdjhfuhasdfjdhsfhfhj");
//            redenvelopeParam.Add("description", "your description");


//            // 将 extra 添加到请求参数中
//            redenvelopeParam.Add("extra", extra);
//            // 将 app 添加到请求参数中
//            redenvelopeParam.Add("app", app);

//            RedEnvelope redEnvelope = CreateRedEnvelope(redenvelopeParam);
//            Console.WriteLine("****创建 RedEnvelope 对象****");
//            Console.WriteLine(redEnvelope);
//            Console.WriteLine();


//            String id = redEnvelope.Id;
//            RedEnvelope red = RetrieveRedEnvelope(id);
//            Console.WriteLine("****查询指定 RedEnvelope 对象****");
//            Console.WriteLine(redEnvelope);
//            Console.WriteLine();

//            Dictionary<String, Object> listmap = new Dictionary<String, Object>();
//            listmap.Add("limit", 3);

//            RedEnvelopeList redlist = ListRedEnvelope(listmap);
//            Console.WriteLine("****查询 RedEnvelope 对象列表****");
//            //Console.WriteLine(string.Join(",\n", redlist)); //.Net 4.0 及以上版本可用此打印列表值
//            Console.WriteLine(redlist); //3.5 版本这里需要接入者自行遍历取列表里的每一个 RedEnvelope

//            Console.ReadKey();

//        }

//        public static RedEnvelope CreateRedEnvelope(Dictionary<String, Object> param)
//        {
//            //发起 charge 请求获取支付凭据
//            RedEnvelope redEnvelope = RedEnvelope.create(param);
//            return redEnvelope;
//        }

//        public static RedEnvelope RetrieveRedEnvelope(string redEnvelopeId)
//        {
//            //查询制定 chargeId 的 charge 对象
//            RedEnvelope redEnvelope = RedEnvelope.retrieve(redEnvelopeId);
//            return redEnvelope;
//        }

//        public static RedEnvelopeList ListRedEnvelope(Dictionary<String, Object> listParam)
//        {
//            //查询制定 charge 列表
//            RedEnvelopeList redEnvelopeList = RedEnvelope.list(listParam);
//            return redEnvelopeList;
//        }
//    }
//}
