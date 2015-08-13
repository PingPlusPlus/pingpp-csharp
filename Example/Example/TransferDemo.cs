//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using pingpp;
//using pingpp.Models;

//namespace Example
//{
//    class TransferDemo
//    {
//        ///<summary>
//        ///本示例只介绍如何发送企业付款请求，以及如何查询指定 Transfer 对象和 Transfer 列表，
//        ///获取到了 Transfer 对象后，不需要客户端做任何处理，指定的用户会在微信客户端收到企业付款消息
//        /// </summary>

//        static void Main(string[] args)
//        {
//            // 设置 apikey
//            Pingpp.apiKey = "sk_test_ibbTe5jLGCi5rzfH4OqPW9KC";

//            // 设置 appid
//            Dictionary<string, string> app = new Dictionary<string, string>();
//            app.Add("id", "app_1Gqj58ynP0mHeX1q");

//            // 设置  extra
//            Dictionary<string, object> extra = new Dictionary<string, object>();
//            extra.Add("user_name", "user name");
//            extra.Add("force_check", false);


//            Dictionary<string, object> param = new Dictionary<string, object>();
//            //demo 里没有生成随机字符串，接入者使用 Demo 时如果报错说 order_no 已经使用过，请更换 order_no 后再试。
//            param.Add("order_no", "asd45fgsdfsasadfsdgdfsdafsd");
//            param.Add("amount", 100);
//            param.Add("channel", "wx_pub");
//            param.Add("currency", "cny");
//            param.Add("type", "b2c");
//            param.Add("recipient", "sadfdsagadsfd");
//            param.Add("description", "description");
//            param.Add("app", app);
//            param.Add("extra", extra);

//            Transfer transfer = CreateTransfer(param);
//            Console.WriteLine("****创建 Transfer 对象****");
//            Console.WriteLine(transfer);
//            Console.WriteLine();

//            String id = transfer.Id;
//            Transfer tra = RetrieveTransfer(id);
//            Console.WriteLine("****查询指定 Transfer 对象****");
//            Console.WriteLine(tra);
//            Console.WriteLine();


//            Dictionary<String, Object> listmap = new Dictionary<String, Object>();
//            listmap.Add("limit", 3);
//            TransferList transferList = ListTransfer(listmap);
//            Console.WriteLine("****查询 Transfer 对象列表****");
//            //Console.WriteLine(string.Join(",\n", transferList)); //.Net 4.0 及以上版本可用此打印列表值
//            Console.WriteLine(transferList); //3.5 版本这里需要接入者自行遍历取列表里的每一个 Transfer

//            Console.WriteLine();

//            Console.ReadKey();
//        }


//        public static Transfer CreateTransfer(Dictionary<String, Object> param)
//        {
//            //发起 Transfer 请求
//            Transfer transfer = Transfer.create(param);
//            return transfer;
//        }

//        public static Transfer RetrieveTransfer(string transferId)
//        {
//            //查询制定 traId 的 Transfer 对象
//            Transfer transfer = Transfer.retrieve(transferId);
//            return transfer;
//        }

//        public static TransferList ListTransfer(Dictionary<String, Object> listParam)
//        {
//            //查询制定 Transfer 列表
//            TransferList list = Transfer.list(listParam);
//            return list;
//        }
//    }

//}
