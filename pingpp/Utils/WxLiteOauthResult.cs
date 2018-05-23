using Newtonsoft.Json;

namespace Pingpp.Utils
{
    /// <summary>
    /// 微信小程序登录凭证校验返回对象
    /// </summary>
    internal class WxLiteOauthResult
    {
        [JsonProperty("openid")]
        public string Openid { get; set; }
        [JsonProperty("session_key")]
        public string SessionKey { get; set; }
        [JsonProperty("unionid")]
        public string Unionid { get; set; }
    }
}
