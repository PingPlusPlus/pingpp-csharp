//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using pingpp;
//using pingpp.Models;

//namespace Example
//{
//    class RefundDemo
//    {
//        /// <summary>
//        /// 本示例只介绍如何发起退款，以及如何查询指定 refund 对象和 refund 列表，
//        /// </summary>
//        static void Main(string[] args)
//        {
//            //设置 apikey
//            Pingpp.apiKey = "sk_test_ibbTe5jLGCi5rzfH4OqPW9KC";
//            string chId = "ch_ivTaDKb1qv90yTa5uTWffLmP";
//            //退款请求参数，这里之列出必填参数，可选参数请参考 https://pingxx.com/document/api#api-r-new
//            Dictionary<string, object> param = new Dictionary<string, object>();
//            param.Add("amount", 1);
//            param.Add("description", "test refund");

//            Refund refund = CreateRefund(chId, param);
//            Console.WriteLine("****发起交易请求创建 refund 对象****");
//            Console.WriteLine(refund);
//            Console.WriteLine();

//            string reId = refund.Id;
//            Refund re = RetrieveRefund(chId, reId);
//            Console.WriteLine("****查询指定 refund 对象****");
//            Console.WriteLine(re);
//            Console.WriteLine();

//            Dictionary<String, Object> listmap = new Dictionary<String, Object>();
//            listmap.Add("limit", 3);

//            RefundList relist = ListRefund(chId, listmap);
//            Console.WriteLine("****查询 refund 列表****");
//            //Console.WriteLine(string.Join(",\n", relist)); //.Net 4.0 及以上版本可用此打印列表值
//            Console.WriteLine(relist); //3.5 版本这里需要接入者自行遍历取列表里的每一个 Refund
//            Console.WriteLine();

//            Console.ReadKey();

//        }

//        public static Refund CreateRefund(String chId, Dictionary<String, Object> param)
//        {
//            //发起 refund 请求
//            Refund refund = Refund.create(chId, param);
//            return refund;
//        }

//        public static Refund RetrieveRefund(string chId, string reId)
//        {
//            //查询制定 refundId 的 Refund 对象
//            Refund refund = Refund.retrieve(chId, reId);
//            return refund;
//        }

//        public static RefundList ListRefund(string chId, Dictionary<String, Object> listParam)
//        {
//            //查询制定 Refund 列表
//            RefundList refundList = Refund.list(chId, listParam);
//            return refundList;
//        }
//    }
//}
