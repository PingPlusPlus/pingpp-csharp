using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using pingpp;
using pingpp.Models;
using System.Security.Cryptography;

namespace Demo
{
    public partial class Charges : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.RequestType.ToUpper() == "POST")
            {
                //获取 post 的 data 
                string inputData = ReadStream(Request.InputStream);
                var jObject = JObject.Parse(inputData);
                var amount = jObject.SelectToken("amount");
                var channel = jObject.SelectToken("channel");
                var orderNo = jObject.SelectToken("order_no");

                Pingpp.apiKey = "sk_test_ibbTe5jLGCi5rzfH4OqPW9KC";




                Dictionary<string, object> extra = new Dictionary<string, object>();
                if (channel.ToString().Equals("alipay_wap"))
                {
                    extra.Add("success_url", "http://www.yourdomain.com/success");
                    extra.Add("cancel_url", "http://www.yourdomain.com/cancel");
                }
                else if (channel.ToString().Equals("wx_pub"))
                {
                    extra.Add("open_id", "asdfasdfsadfasdf");
                }
                else if (channel.ToString().Equals("upacp_wap"))
                {
                    extra.Add("result_url", "http://www.yourdomain.com/result");
                }
                else if (channel.ToString().Equals("upmp_wap"))
                {
                    extra.Add("result_url", "http://www.yourdomain.com/result?code=");
                }
                else if (channel.ToString().Equals("bfb_wap"))
                {
                    extra.Add("result_url", "http://www.yourdomain.com/result");
                    extra.Add("bfb_login", true);
                }
                else if (channel.ToString().Equals("wx_pub_qr"))
                {
                    extra.Add("product_id", "asdfsadfadsf");
                }
                else if (channel.ToString().Equals("yeepay_wap"))
                {
                    extra.Add("product_category", "1");
                    extra.Add("identity_id", "sadfsdaf");
                    extra.Add("identity_type", 1);
                    extra.Add("terminal_type", 1);
                    extra.Add("terminal_id", "sadfsadf");
                    extra.Add("user_ua", "sadfsdaf");
                    extra.Add("result_url", "http://www.yourdomain.com/result");
                }
                else if (channel.ToString().Equals("jdpay_wap"))
                {
                    extra.Add("success_url", "http://www.yourdomain.com/success");
                    extra.Add("fail_url", "http://www.yourdomain.com/fail");
                    extra.Add("token", "fjdilkkydoqlpiunchdysiqkanczxude");//32 位字符串
                }


                Dictionary<string, string> app = new Dictionary<string, string>();
                app.Add("id", "app_1Gqj58ynP0mHeX1q");

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("order_no", orderNo);
                param.Add("amount", amount);
                param.Add("channel", channel);
                param.Add("currency", "cny");
                param.Add("subject", "test");
                param.Add("body", "tests");
                param.Add("client_ip", "127.0.0.1");
                param.Add("app", app);
                param.Add("extra", extra);

                try
                {
                    Charge charge = Charge.create(param);
                    Response.Write(charge);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                }
            }
        }

        private static string ReadStream(Stream stream)
        {
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}