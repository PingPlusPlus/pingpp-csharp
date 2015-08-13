using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using System.Collections;
using System.Web;
using pingpp.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using pingpp.Models;
using pingpp.Exception;
using System.Net;
using System.IO;



namespace pingpp.Utils
{
    /// <summary>
    /// 用于微信公众号OAuth2.0鉴权，用户授权后获取授权用户唯一标识openid
    ///WxpubOAuth中的方法都是可选的，开发者也可根据实际情况自行开发相关功能，
    ///详细内容可参考http://mp.weixin.qq.com/wiki/17/c0f37d5704f0b64713d5d2c37b468d75.html
    /// </summary>
    public class WxPubUtils
    {


        /// <summary>
        /// 用于生成获取授权 code 的 URL 地址，此地址用于用户身份鉴权，获取用户身份信息，同时重定向到 redirect_url
        /// </summary>
        /// <param name="appId">微信公众号应用唯一标识</param>
        /// <param name="redirectUrl">
        /// 授权后重定向的回调链接地址，重定向后此地址将带有授权code参数，该地址的域名需在微信公众号平台上进行设置，
        /// 步骤为：登陆微信公众号平台  开发者中心  网页授权获取用户基本信息 修改
        /// </param>
        /// <param name="moreInfo">
        /// FALSE 不弹出授权页面,直接跳转,这个只能拿到用户openid
        /// TRUE 弹出授权页面,这个可以通过 openid 拿到昵称、性别、所在地
        /// </param>
        /// <returns>用于获取授权 code 的 URL 地址</returns>
        public static String createOauthUrlForCode(String appId, String redirectUrl, Boolean moreInfo)
        {
            Dictionary<String, String> data = new Dictionary<String, String>();
            data.Add("appid", appId);
            data.Add("redirect_uri", redirectUrl);
            data.Add("response_type", "code");
            data.Add("scope", moreInfo ? "snsapi_userinfo" : "snsapi_base");
            data.Add("state", "STATE#wechat_redirect");
            String queryString = WxPubUtils.httpBuildQuery(data);

            return "https://open.weixin.qq.com/connect/oauth2/authorize?" + queryString;
        }



        /// <summary>
        /// 生成获取 openid 的 URL 地址
        /// </summary>
        /// <param name="appId">微信公众号应用唯一标识</param>
        /// <param name="appSecret">微信公众号应用密钥（注意保密）</param>
        /// <param name="code">获取到的 code</param>
        /// <returns>获取 openid 的 URL 地址</returns>
        private static String createOauthUrlForOpenid(String appId, String appSecret, String code)
        {
            Dictionary<String, String> data = new Dictionary<String, String>();
            data.Add("appid", appId);
            data.Add("secret", appSecret);
            data.Add("code", code);
            data.Add("grant_type", "authorization_code");
            String queryString = WxPubUtils.httpBuildQuery(data);

            return string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?{0}", queryString);
        }




        /// <summary>
        /// 获取 openid
        /// </summary>
        /// <param name="appId">微信公众号应用唯一标识</param>
        /// <param name="appSecret">微信公众号应用密钥（注意保密）</param>
        /// <param name="code">获取到的 code</param>
        /// <returns>openid</returns>
        public static String getOpenId(String appId, String appSecret, String code)
        {
            String url = WxPubUtils.createOauthUrlForOpenid(appId, appSecret, code);
            String ret = GetRequest(url);
            OAuthResult oAuthResult = Mapper<OAuthResult>.MapFromJson(ret);
            return oAuthResult.Openid.ToString();
        }


        private static String httpBuildQuery(Dictionary<String, String> queryString)
        {
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<String, String> kvp in queryString)
            {
                if (sb.Length > 0)
                {
                    sb.Append('&');
                }
                sb.Append(Requestor.urlEncodePair(kvp.Key, kvp.Value));
            }

            return sb.ToString();
        }



        //读取 response 流
        private static string ReadStream(Stream stream)
        {
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }


        /// <summary>
        /// 发起 get 请求
        /// </summary>
        /// <param name="url">请求的 url</param>
        /// <returns>response</returns>
        internal static string GetRequest(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            try
            {
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    return ReadStream(response.GetResponseStream());

                }
            }
            catch (WebException e)
            {
                throw new WebException(e.Message.ToString());
            }

        }

        /// <summary>
        /// 生成微信公众号 jsapi_ticket
        /// </summary>
        /// <param name="appId">微;\信公众号应用唯一标识</param>
        /// <param name="appSecret">微信公众号应用密钥（注意保密）</param>
        /// <returns>Ticket</returns>
        public static String getJsapiTicket(String appId, String appSecret)
        {
            Dictionary<String, String> data = new Dictionary<String, String>();
            data.Add("appid", appId);
            data.Add("secret", appSecret);
            data.Add("grant_type", "client_credential");
            String queryString = WxPubUtils.httpBuildQuery(data);
            String accessTokenUrl = "https://api.weixin.qq.com/cgi-bin/token?" + queryString;
            String resp = GetRequest(accessTokenUrl);
            var jObject = JObject.Parse(resp);
            data.Clear();
            data.Add("access_token", jObject.GetValue("access_token").ToString());
            data.Add("type", "jsapi");
            queryString = WxPubUtils.httpBuildQuery(data);
            String jsapiTicketUrl = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?" + queryString;
            resp = GetRequest(jsapiTicketUrl);
            var ticket = JObject.Parse(resp);
            return ticket.GetValue("ticket").ToString();
        }


        /// <summary>
        /// 生成微信公众号 js sdk signature
        /// </summary>
        /// <param name="charge">charge 字符串</param>
        /// <param name="jsapiTicket">获取到的 ticket</param>
        /// <param name="url">url</param>
        /// <returns>signature</returns>

        public static String getSignature(String charge, String jsapiTicket, String url)
        {
            string signature = null;
            if (null == charge || null == jsapiTicket || string.IsNullOrEmpty(charge) || string.IsNullOrEmpty(jsapiTicket))
                return null;

            Charge chargeJson = JsonConvert.DeserializeObject<Charge>(charge);
            var credential = chargeJson.Credential.ToString();
            if (string.IsNullOrEmpty(credential) || !chargeJson.ToString().Contains("credential"))
            {
                return null;
            }

            if (!credential.Contains("wx_pub"))
            {
                return null;
            }


            var wxPub = JObject.Parse(credential);

            if (credential.Contains("wx_pub"))
            {

                var cre = wxPub.SelectToken("wx_pub");
                var noceStr = cre.SelectToken("timeStamp");

                // 注意这里参数名必须全部小写，且必须有序
                String string1 = "jsapi_ticket=" + jsapiTicket +
                    "&noncestr=" + cre.SelectToken("nonceStr").ToString() +
                    "&timestamp=" + cre.SelectToken("timeStamp").ToString() +
                    "&url=" + url;


                signature = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(string1, "SHA1");
                return signature;
            }
            else
            {
                throw new PingppException("credential doesn't contain key wx_pub");

            }
        }

    }

    class OAuthResult
    {
        [JsonProperty("access_token")]
        public String Access_token { get; set; }

        [JsonProperty("expires_in")]
        public int? Expires_in { get; set; }

        [JsonProperty("refresh_token")]
        public String Refresh_token { get; set; }

        [JsonProperty("openid")]
        public String Openid { get; set; }

        [JsonProperty("scope")]
        public String Scope { get; set; }

    }
}
