using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;

namespace Pingpp.Models
{
    /// <summary>
    /// 子商户应用渠道对象
    /// </summary>
    public class SubAppChannel : Pingpp
    {
        [JsonProperty("object")]
        public string Object { get; set; }
        [JsonProperty("created")]
        public int? Created { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }
        [JsonProperty("banned")]
        public bool Banned { get; set; }
        [JsonProperty("banned_msg")]
        public string BannedMsg { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("params")]
        public Dictionary<string,object> Params;


        public const string BaseUrl = "/v1/apps/{0}/sub_apps/{1}/channels";

        /// <summary>
        /// 创建子商户应用支付渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="subAppId"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static SubAppChannel Create(string appId, string subAppId, Dictionary<string, object> param) 
        {
            var url = string.Format(BaseUrl, appId, subAppId);
            var chl = Requestor.DoRequest(url, "POST", param);
            return Mapper<SubAppChannel>.MapFromJson(chl);
        }

        /// <summary>
        /// 更新子商户应用支付渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="subAppId"></param>
        /// <param name="channel"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static SubAppChannel Update(string appId, string subAppId, string channel, Dictionary<string, object> param) 
        {
            var url = string.Format("{0}/{1}", string.Format(BaseUrl, appId, subAppId), channel);
            var chl = Requestor.DoRequest(url, "PUT", param);
            return Mapper<SubAppChannel>.MapFromJson(chl);
        }

        /// <summary>
        /// 查询子商户应用支付渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="subAppId"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        public static SubAppChannel Retrieve(string appId, string subAppId, string channel) 
        {
            var url = string.Format("{0}/{1}", string.Format(BaseUrl, appId, subAppId), channel);
            var chl = Requestor.DoRequest(url, "GET");
            return Mapper<SubAppChannel>.MapFromJson(chl);
        }

        /// <summary>
        /// 删除子商户应用支付渠道
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="subAppId"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        public static DeletedSubAppChannel Delete(string appId, string subAppId, string channel) 
        {
            var url = string.Format("{0}/{1}", string.Format(BaseUrl, appId, subAppId), channel);
            var res = Requestor.DoRequest(url, "DELETE");
            return Mapper<DeletedSubAppChannel>.MapFromJson(res);
        }
    }
}
