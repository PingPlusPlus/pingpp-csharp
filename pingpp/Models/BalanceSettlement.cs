using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;


namespace Pingpp.Models
{
    /// <summary>
    /// balance_settlement 余额结算对象
    /// </summary>
    public class BalanceSettlement : Pingpp
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("app")]
        public string App { get; set; }
        
        [JsonProperty("amount")]
        public int Amount { get; set; }
        
        [JsonProperty("amount_refunded")]
        public int AmountRefunded { get; set; }
        
        [JsonProperty("created")]
        public int Created { get; set; }
        
        [JsonProperty("charge")]
        public string Charge { get; set; }
        
        [JsonProperty("livemode")]
        public bool Livemode { get; set; }
        
        [JsonProperty("failure_msg")]
        public string FailureMsg { get; set; }
        
        [JsonProperty("refunded")]
        public bool Refunded { get; set; }
        
        [JsonProperty("order_no")]
        public string OrderNo { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("time_credited")]
        public int TimeCredited { get; set; }
        
        [JsonProperty("time_succeeded")]
        public int TimeSucceeded { get; set; }
        
        [JsonProperty("transaction_no")]
        public string TransactionNo { get; set; }
        
        [JsonProperty("user")]
        public string User { get; set; }
        
        [JsonProperty("user_fee")]
        public int UserFee { get; set; }
        private const string BaseUrl = "/v1/apps/{0}/balance_settlements";

        /// <summary>
        /// 查询余额结算对象
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="balanceSettlementId"></param>
        /// <returns></returns>
        public static BalanceSettlement Retrieve(string appId, string balanceSettlementId)
        {

            var balanceSettlement = Requestor.DoRequest(string.Format("{0}/{1}", string.Format(BaseUrl, appId), balanceSettlementId), "GET");
            return Mapper<BalanceSettlement>.MapFromJson(balanceSettlement);
        }
        
        /// <summary>
        /// 查询余额结算对象列表
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="listParams"></param>
        /// <returns></returns>
        public static BalanceSettlementList List (string appId, Dictionary<string, object> listParams = null)
        {
            var balanceTransferList = Requestor.DoRequest(Requestor.FormatUrl(string.Format(BaseUrl, appId), Requestor.CreateQuery(listParams)), "GET");
            return Mapper<BalanceSettlementList>.MapFromJson(balanceTransferList);
        }
    }
}
