using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;

namespace Pingpp.Models
{
    public class BalanceTransaction : Pingpp
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("app")]
        public string App { get; set; }

        [JsonProperty("amount")]
        public int? Amount { get; set; }

        [JsonProperty("available_balance")]
        public int? AvailableBalance { get; set; }

        [JsonProperty("created")]
        public int? Created { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("livemode")]
        public bool Livemode { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        private const string BaseUrl = "/v1/apps";

        /// <summary>
        /// 企业清算账户交易明细-查询
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="txnId"></param>
        /// <returns></returns>
        public static BalanceTransaction Retrieve(string appId, string txnId)
        {
            var url = string.Format("{0}/{1}/balance_transactions/{2}", BaseUrl, appId, txnId);
            var txn = Requestor.DoRequest(url, "GET");
            return Mapper<BalanceTransaction>.MapFromJson(txn);
        }

        /// <summary>
        /// 企业清算账户交易明细-查询列表
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="listParams"></param>
        /// <returns></returns>
        public static BalanceTransactionList List(string appId, Dictionary<string, object> listParams = null)
        {
            var url = Requestor.FormatUrl(string.Format("{0}/{1}/balance_transactions", BaseUrl, appId), Requestor.CreateQuery(listParams));
            var txnList = Requestor.DoRequest(url, "GET");
            return Mapper<BalanceTransactionList>.MapFromJson(txnList);
        }
    }
}
