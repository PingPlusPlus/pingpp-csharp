using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;
using Pingpp.Exception;

namespace Pingpp.Models
{
    public class BalanceTransfer : Pingpp
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
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("amount")]
        public int Amount { get; set; }
        [JsonProperty("user")]
        public string User { get; set; }
        [JsonProperty("user_fee")]
        public int UserFee { get; set; }
        [JsonProperty("recipient")]
        public string Recipient { get; set; }
        [JsonProperty("user_balance_transaction")]
        public string UserBalanceTransaction { get; set; }
        [JsonProperty("recipient_balance_transaction")]
        public string RecipientBalanceTransaction { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("metadata")]
        public Dictionary<string, object> Metadata { get; set; }
        private const string BaseUrl = "/v1/apps/{0}/balance_transfers";

        /// <summary>
        /// 创建余额转账
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="btParams"></param>
        /// <returns></returns>
        public static BalanceTransfer Create(string appId, Dictionary<string, object> btParams)
        {
            var balanceTransfer = Requestor.DoRequest(string.Format(BaseUrl, appId), "POST", btParams);
            return Mapper<BalanceTransfer>.MapFromJson(balanceTransfer);
        }
        /// <summary>
        /// 查询余额转账对象
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="balanceTransferId"></param>
        /// <returns></returns>
        public static BalanceTransfer Retrieve(string appId, string balanceTransferId)
        {
            var balanceTransfer = Requestor.DoRequest(string.Format("{0}/{1}", string.Format(BaseUrl, appId), balanceTransferId), "GET");
            return Mapper<BalanceTransfer>.MapFromJson(balanceTransfer);
        }
        /// <summary>
        /// 查询余额转账对象列表
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="listParams"></param>
        /// <returns></returns>
        public static BalanceTransferList List(string appId, Dictionary<string, object> listParams = null)
        {
            var balanceTransferList = Requestor.DoRequest(Requestor.FormatUrl(String.Format(BaseUrl, appId), Requestor.CreateQuery(listParams)), "GET");
            return Mapper<BalanceTransferList>.MapFromJson(balanceTransferList);
        }
    }
}
