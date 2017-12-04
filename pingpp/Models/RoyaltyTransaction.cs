using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;

namespace Pingpp.Models
{
    /// <summary>
    /// 分润结算明细
    /// </summary>
    public class RoyaltyTransaction : Pingpp
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("object")]
        public string Object{get;set;}
        [JsonProperty("amount")]
        public int Amount{get;set;}
        [JsonProperty("status")]
        public string Status{get;set;}
        [JsonProperty("settle_account")]
        public string SettleAccount{get;set;}
        [JsonProperty("source_user")]
        public string SourceUser{get;set;}
        [JsonProperty("recipient_app")]
        public string RecipientApp { get; set; }
        [JsonProperty("royalty_settlement")]
        public string RoyaltySettlement { get; set; }
        [JsonProperty("created")]
        public int? Created { get; set; }
        [JsonProperty("failure_msg")]
        public string FailureMsg { get; set; }
        [JsonProperty("transfer")]
        public string Transfer { get; set; }

        public const string BaseUrl = "/v1/royalty_transactions";
        
        /// <summary>
        /// 查询单个分润结算明细对象
        /// </summary>
        /// <param name="royaltyTransactionId"></param>
        /// <returns></returns>
        public static RoyaltyTransaction Retrieve(string royaltyTransactionId) 
        {
            var url = string.Format("{0}/{1}", BaseUrl, royaltyTransactionId);
            var roTransaction = Requestor.DoRequest(url, "GET");
            return Mapper<RoyaltyTransaction>.MapFromJson(roTransaction);
        }

        /// <summary>
        /// 查询分润结算明细对象列表
        /// </summary>
        /// <param name="listParam"></param>
        /// <returns></returns>
        public static RoyaltyTransactionList List(Dictionary<string, object> listParam = null) 
        {
            var url = Requestor.FormatUrl(BaseUrl, Requestor.CreateQuery(listParam));
            var roTransaction = Requestor.DoRequest(url, "GET");
            return Mapper<RoyaltyTransactionList>.MapFromJson(roTransaction);
        }
    }
}
