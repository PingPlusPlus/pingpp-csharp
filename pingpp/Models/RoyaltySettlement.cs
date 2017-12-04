using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;


namespace Pingpp.Models
{
    /// <summary>
    /// 分润结算对象
    /// </summary>
    public class RoyaltySettlement:Pingpp
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("object")]
        public string Object { get; set; }
        [JsonProperty("payer_app")]
        public string PayerApp { get; set; }
        [JsonProperty("created")]
        public int? Created { get; set; }
        [JsonProperty("livemode")]
        public bool Livemode { get; set; }
        [JsonProperty("method")]
        public String Method { get; set; }
        [JsonProperty("amount")]
        public int Amount { get; set; }
        [JsonProperty("amount_succeeded")]
        public int AmountSucceeded { get; set; }
        [JsonProperty("amount_failed")]
        public int AmountFailed { get; set; }
        [JsonProperty("amount_canceled")]
        public int AmountCanceled { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("count_succeeded")]
        public int CountSucceeded { get; set; }
        [JsonProperty("count_failed")]
        public int CountFailed { get; set; }
        [JsonProperty("count_canceled")]
        public int CountCanceled { get; set; }
        [JsonProperty("time_finished")]
        public int? TimeFinished { get; set; }
        [JsonProperty("fee")]
        public int Fee { get; set; }
        [JsonProperty("metadata")]
        public Dictionary<string, object> Metadata { get; set; }
        [JsonProperty("operation_url")]
        public string OperationUrl { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("royalty_transactions")]
        public RoyaltyTransactionList RoyaltyTransaction { get; set; }

        public const string BaseUrl = "/v1/royalty_settlements";

        /// <summary>
        /// 创建分润结算对象
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static RoyaltySettlement Create(Dictionary<string, object> param) 
        {
            var royaltySettlement = Requestor.DoRequest(BaseUrl, "POST", param);
            return Mapper<RoyaltySettlement>.MapFromJson(royaltySettlement);
        }

        /// <summary>
        /// 查询单个分润结算对象
        /// </summary>
        /// <param name="royaltySettlementId"></param>
        /// <returns></returns>
        public static RoyaltySettlement Retrieve(string royaltySettlementId) 
        {
            var url = string.Format("{0}/{1}", BaseUrl, royaltySettlementId);
            var royaltySettlement = Requestor.DoRequest(url, "GET");
            return Mapper<RoyaltySettlement>.MapFromJson(royaltySettlement);
        }

        /// <summary>
        /// 更新分润结算对象
        /// </summary>
        /// <param name="royaltySettlementId"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static RoyaltySettlement Update(string royaltySettlementId, Dictionary<string, object> param) 
        {
            var url = string.Format("{0}/{1}", BaseUrl, royaltySettlementId);
            var royaltySettlement = Requestor.DoRequest(url, "PUT", param);
            return Mapper<RoyaltySettlement>.MapFromJson(royaltySettlement);
        }

        /// <summary>
        /// 查询分润结算对象列表
        /// </summary>
        /// <param name="listParam"></param>
        /// <returns></returns>
        public static RoyaltySettlementList List(Dictionary<string, object> listParam = null) 
        {
            var url = Requestor.FormatUrl(BaseUrl, Requestor.CreateQuery(listParam));
            var royaltySettlements = Requestor.DoRequest(url, "GET");
            return Mapper<RoyaltySettlementList>.MapFromJson(royaltySettlements);
        }
    }
}
