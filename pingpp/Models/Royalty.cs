using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;

namespace Pingpp.Models
{
    /// <summary>
    /// 分润对象
    /// </summary>
    public class Royalty :Pingpp
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("object")]
        public string Object { get; set; }
        [JsonProperty("payer_app")]
        public string PayerApp { get; set; }
        [JsonProperty("amount")]
        public int Amount { get; set; }
        [JsonProperty("created")]
        public int Created { get; set; }
        [JsonProperty("livemode")]
        public bool Livemode { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("method")]
        public string Method { get; set; }
        [JsonProperty("recipient_app")]
        public string RecipientApp { get; set; }
        [JsonProperty("royalty_transaction")]
        public string RoyaltyTransaction { get; set; }
        [JsonProperty("time_settled")]
        public int? TimeSettled { get; set; }
        [JsonProperty("settle_account")]
        public string SettleAccount { get; set; }
        [JsonProperty("source_app")]
        public string SourceApp { get; set; }
        [JsonProperty("source_url")]
        public string SourceUrl { get; set; }
        [JsonProperty("source_no")]
        public string SourceNo { get; set; }
        [JsonProperty("source_user")]
        public string SourceUser { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("metadata")]
        public Dictionary<string, object> Metadata { get; set; }
        [JsonProperty("royalty_settlement")]
        public string RoyaltySettlement { get; set; }

        public const string BaseUrl = "/v1/royalties";

        /// <summary>
        /// 批量更新分润对象
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static RoyaltyList Update(Dictionary<string, object> param) 
        {
            var royalty = Requestor.DoRequest(BaseUrl, "PUT", param);
            return Mapper<RoyaltyList>.MapFromJson(royalty);
        }

        /// <summary>
        /// 查询分润对象列表
        /// </summary>
        /// <param name="listParam"></param>
        /// <returns></returns>
        public static RoyaltyList List(Dictionary<string, object> listParam = null) 
        {
            var url = Requestor.FormatUrl(BaseUrl, Requestor.CreateQuery(listParam));
            var royalty = Requestor.DoRequest(url, "GET");
            return Mapper<RoyaltyList>.MapFromJson(royalty);
        }

        /// <summary>
        /// 查询分润对象
        /// </summary>
        /// <param name="royaltyId"></param>
        /// <returns></returns>
        public static Royalty Retrieve(string royaltyId) 
        {
            var url = string.Format("{0}/{1}", BaseUrl, royaltyId);
            var royalty = Requestor.DoRequest(url, "GET");
            return Mapper<Royalty>.MapFromJson(royalty);
        }
    }
}
