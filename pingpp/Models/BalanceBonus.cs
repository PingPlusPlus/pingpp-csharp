using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;
using Pingpp.Exception;

namespace Pingpp.Models
{
    public class BalanceBonus : Pingpp
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("object")]
        public string Object { get; set; }
        [JsonProperty("app")]
        public string App { get; set; }
        [JsonProperty("created")]
        public int Created { get; set; }

        [JsonProperty("livemode")]
        public bool Livemode { get; set; }
        [JsonProperty("paid")]
        public bool Paid { get; set; }

        [JsonProperty("refunded")]
        public bool Refunded { get; set; }
        [JsonProperty("amount")]
        public int Amount { get; set; }
        [JsonProperty("amount_refunded")]
        public int AmountRefunded { get; set; }
        [JsonProperty("order_no")]
        public string OrderNo { get; set; }
        [JsonProperty("time_paid")]
        public int? TimePaid { get; set; }
        [JsonProperty("user")]
        public string User { get; set; }
        [JsonProperty("balance_transaction")]
        public string BalanceTransaction { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("metadata")]
        public Dictionary<string, object> Metadata { get; set; }

        private const string BaseUrl = "/v1/apps/{0}/balance_bonuses";

        /// <summary>
        /// 创建余额赠送
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="bonusParams"></param>
        /// <returns></returns>
        public static BalanceBonus Create(string appId, Dictionary<string, object> bonusParams) 
        {
            var balanceBonus = Requestor.DoRequest(string.Format(BaseUrl, appId), "POST", bonusParams);
            return Mapper<BalanceBonus>.MapFromJson(balanceBonus);
        }

        /// <summary>
        /// 查询余额赠送
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="balanceBonusId"></param>
        /// <returns></returns>
        public static BalanceBonus Retrieve(string appId, string balanceBonusId) 
        {
            var balanceBonus = Requestor.DoRequest(string.Format("{0}/{1}",string.Format(BaseUrl,appId),balanceBonusId), "GET");
            return Mapper<BalanceBonus>.MapFromJson(balanceBonus);
        }

        /// <summary>
        /// 查询余额赠送列表
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="listParams"></param>
        /// <returns></returns>
        public static BalanceBonusList List(string appId, Dictionary<string, object> listParams = null) 
        {
            var balanceBonusList = Requestor.DoRequest(Requestor.FormatUrl(String.Format(BaseUrl,appId), Requestor.CreateQuery(listParams)),"GET");
            return Mapper<BalanceBonusList>.MapFromJson(balanceBonusList);
        }

    }
}
