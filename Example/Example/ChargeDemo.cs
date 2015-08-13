using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pingpp;
using pingpp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Example
{
    class ChargeDemo
    {
        /// <summary>
        /// 本示例只介绍如何请求支付凭据（charge 对象），以及如何查询指定 charge 对象和 charge 列表，
        /// 至于如何将 charge 对象传递给客户端需要接入者自行处理
        /// </summary>

        static void Main(string[] args)
        {
            //设置 apikey
            Pingpp.apiKey = "sk_test_ibbTe5jLGCi5rzfH4OqPW9KC";

            //设置 appid
            Dictionary<string, string> app = new Dictionary<string, string>();
            app.Add("id", "app_1Gqj58ynP0mHeX1q");

            //交易请求参数，这里之列出必填参数，可选参数请参考 https://pingxx.com/document/api#api-c-new
            Dictionary<string, object> chargeParam = new Dictionary<string, object>();
            chargeParam.Add("order_no", "asdfgffgfddfdsfgfdsa");
            chargeParam.Add("amount", 1);
            chargeParam.Add("channel", "wx");
            chargeParam.Add("currency", "cny");
            chargeParam.Add("subject", "your subject");
            chargeParam.Add("body", "your body");
            chargeParam.Add("client_ip", "127.0.0.1");
            //将 appid 添加到发起交易的请求参数中
            chargeParam.Add("app", app);

            Charge charge = CreateCharge(chargeParam);
            Console.WriteLine("****发起交易请求创建 charge 对象****");
            Console.WriteLine(charge);
            Console.WriteLine();

            string id = charge.Id;
            Charge ch = RetrieveCharge(id);
            Console.WriteLine("****查询指定 charge 对象****");
            Console.WriteLine(ch);
            Console.WriteLine();

            Dictionary<String, Object> listmap = new Dictionary<String, Object>();
            listmap.Add("limit", 3);

            ChargeList list = ListCharge(listmap);
            Console.WriteLine("****查询 charge 列表****");
            Console.WriteLine(list);
            Console.WriteLine();



            Console.ReadKey();

        }

        public static Charge CreateCharge(Dictionary<String, Object> param)
        {
            //发起 charge 请求获取支付凭据
            Charge charge = Charge.create(param);
            return charge;
        }

        public static Charge RetrieveCharge(string chargeId)
        {
            //查询制定 chargeId 的 charge 对象
            Charge charge = Charge.retrieve(chargeId);
            return charge;
        }

        public static ChargeList ListCharge(Dictionary<String, Object> listParam)
        {
            //查询制定 charge 列表
            ChargeList list = Charge.list(listParam);
            return list;
        }
    }
}
