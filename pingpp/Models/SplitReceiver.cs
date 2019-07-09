using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;
using Pingpp.Exception;

namespace Pingpp.Models
{
    /// <summary>
    /// 分账接收方
    /// </summary>
    public class SplitReceiver:Pingpp
    {
        [JsonProperty("id")]
        public string Id{set;get;}
        [JsonProperty("object")]
        public string Object { set; get; }
        [JsonProperty("created")]
        public Int64 Created { set; get; }
        [JsonProperty("livemode")]
        public bool Livemode { set; get; }
        [JsonProperty("app")]
        public string App { set; get; }
        [JsonProperty("type")]
        public string Type { set; get; }
        [JsonProperty("account")]
        public string Account { set; get; }
        [JsonProperty("name")]
        public string Name { set; get; }
        [JsonProperty("channel")]
        public string Channel { set; get; }
        [JsonProperty("extra")]
        public Dictionary<string, object> Extra { get; set; }
        [JsonProperty("metadata")]
        public Dictionary<string, object> Metadata { get; set; }

        private const string BaseUrl = "/v1/split_receivers";
        
        /// <summary>
        /// 添加分账接收方
        /// </summary>
        /// <param name="reqParams"></param>
        /// <returns></returns>
        public static SplitReceiver Create(Dictionary<string,object> reqParams)
        {
            var recv = Requestor.DoRequest(BaseUrl, "POST", reqParams);
            return Mapper<SplitReceiver>.MapFromJson(recv);
        }

        /// <summary>
        /// 删除分账接收方
        /// </summary>
        /// <param name="recvId"></param>
        /// <returns></returns>
        public static Deleted Delete(string recvId) 
        {
            var deleted = Requestor.DoRequest(string.Format("{0}/{1}", BaseUrl, recvId), "DELETE");
            return Mapper<Deleted>.MapFromJson(deleted);
        }

        /// <summary>
        /// 查询分账接收方
        /// </summary>
        /// <param name="recvId"></param>
        /// <returns></returns>
        public static SplitReceiver Retrieve(string recvId) 
        {
            var recv = Requestor.DoRequest(string.Format("{0}/{1}", BaseUrl, recvId), "GET");
            return Mapper<SplitReceiver>.MapFromJson(recv);
        }

        /// <summary>
        /// 查询分账接收方列表
        /// </summary>
        /// <param name="reqParams"></param>
        /// <returns></returns>
        public static SplitReceiverList List(Dictionary<string, object> reqParams) 
        {
            var url = Requestor.FormatUrl(BaseUrl, Requestor.CreateQuery(reqParams));
            var recvs = Requestor.DoRequest(url, "GET");
            return Mapper<SplitReceiverList>.MapFromJson(recvs);
        }
    }
}
