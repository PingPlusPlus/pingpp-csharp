using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;
using Pingpp.Exception;

namespace Pingpp.Models
{
    /// <summary>
    /// 分账明细
    /// </summary>
    public class ProfitTransaction:Pingpp
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("object")]
        public string Object { get; set; }
        [JsonProperty("livemode")]
        public bool Livemode { get; set; }
        [JsonProperty("app")]
        public string App { get; set; }
        [JsonProperty("amount")]
        public int? Amount { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("split_receiver")]
        public string SplitReceiver { get; set; }
        [JsonProperty("split_profit")]
        public string SplitProfit { get; set; }
        [JsonProperty("created")]
        public int? Created { get; set; }
        [JsonProperty("time_finished")]
        public int? TimeFinished { get; set; }
        [JsonProperty("failure_msg")]
        public string FailureMsg { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        private const string BaseUrl = "/v1/profit_transactions";
        /// <summary>
        /// 分账明细查询
        /// </summary>
        /// <param name="ptxnId"></param>
        /// <returns></returns>
        public static ProfitTransaction Retrieve(string ptxnId) 
        {
            var ptxn = Requestor.DoRequest(string.Format("{0}/{1}", BaseUrl, ptxnId), "GET");
            return Mapper<ProfitTransaction>.MapFromJson(ptxn);
        }

        /// <summary>
        /// 分账明细列表查询
        /// </summary>
        /// <param name="listParams"></param>
        /// <returns></returns>
        public static ProfitTransactionList List(Dictionary<string, object> listParams) 
        {
            var ptxns = Requestor.DoRequest(Requestor.FormatUrl(BaseUrl, Requestor.CreateQuery(listParams)), "GET");
            return Mapper<ProfitTransactionList>.MapFromJson(ptxns);
        }
    }
}
