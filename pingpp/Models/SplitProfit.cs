using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;
using Pingpp.Exception;

namespace Pingpp.Models
{
    /// <summary>
    /// 分账对象
    /// </summary>
    public class SplitProfit : Pingpp
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("object")]
        public string Object { get; set; }
        [JsonProperty("livemode")]
        public bool Livemode { get; set; }
        [JsonProperty("app")]
        public string App { get; set; }
        [JsonProperty("charge")]
        public string Charge { get; set; }
        [JsonProperty("channel")]
        public string Channel { get; set; }
        [JsonProperty("order_no")]
        public string OrderNo { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("recipients")]
        public List<Dictionary<string, object>> Recipients { set; get; }
        [JsonProperty("created")]
        public int? Created { get; set; }
        [JsonProperty("transaction_no")]
        public string TransactionNo { get; set; }
        [JsonProperty("failure_code")]
        public string FailureCode { get; set; }
        [JsonProperty("failure_msg")]
        public string FailureMsg { get; set; }
        [JsonProperty("extra")]
        public Dictionary<string, object> Extra { get; set; }
        [JsonProperty("metadata")]
        public Dictionary<string, object> Metadata { get; set; }

        private const string BaseUrl = "/v1/split_profits";
        /// <summary>
        /// 分账
        /// </summary>
        /// <param name="reqParams"></param>
        /// <returns></returns>
        public static SplitProfit Create(Dictionary<string, object> reqParams)
        {
            var ch = Requestor.DoRequest(BaseUrl, "POST", reqParams);
            return Mapper<SplitProfit>.MapFromJson(ch);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SplitProfit Retrieve(string id)
        {
            var sp = Requestor.DoRequest(string.Format("{0}/{1}", BaseUrl, id), "GET");
            return Mapper<SplitProfit>.MapFromJson(sp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listParams"></param>
        /// <returns></returns>
        public static SplitProfitList List(Dictionary<string, object> listParams)
        {
            var spList = Requestor.DoRequest(Requestor.FormatUrl(BaseUrl, Requestor.CreateQuery(listParams)), "GET");
            return Mapper<SplitProfitList>.MapFromJson(spList);
        }

    }
}
