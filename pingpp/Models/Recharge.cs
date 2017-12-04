using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pingpp.Net;
using Pingpp.Models;


namespace Pingpp.Models
{
    /// <summary>
    /// 用户余额充值 接口
    /// </summary>
    public class Recharge : Pingpp
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
        [JsonProperty("amount")]
        public int Amount { get; set; }
        [JsonProperty("succeeded")]
        public bool Succeeded { get; set; }
        [JsonProperty("time_succeeded")]
        public int? TimeSucceeded { get; set; }
        [JsonProperty("refunded")]
        public bool Refunded { get; set; }
        [JsonProperty("user")]
        public string User { get; set; }
        [JsonProperty("from_user")]
        public string FromUser { get; set; }
        [JsonProperty("user_fee")]
        public int UserFee { get; set; }
        [JsonProperty("charge")]
        public Charge Charge { get; set; }
        [JsonProperty("balance_bonus")]
        public BalanceBonus BalanceBonus { get; set; }
        [JsonProperty("balance_transaction")]
        public string BalanceTransaction { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("metadata")]
        public Dictionary<string, object> Metadata { get; set; }

        private const string BaseUrl = "/v1/apps/{0}/recharges";

        /// <summary>
        /// 创建 recharge
        /// </summary>
        /// <returns></returns>
        public static Recharge Create(string appId, Dictionary<string, object> createParams)
        {
            var recharge = Requestor.DoRequest(string.Format(BaseUrl, appId), "POST", createParams);
            return Mapper<Recharge>.MapFromJson(recharge);
        }

        public static Recharge Retrieve(string appId, string id)
        {
            var recharge = Requestor.DoRequest(string.Format("{0}/{1}", string.Format(BaseUrl, appId), id), "GET");
            return Mapper<Recharge>.MapFromJson(recharge);
        }
        public static RechargeList List(string appId, Dictionary<string, object> listParams = null)
        {
            var rechargeList = Requestor.DoRequest(Requestor.FormatUrl(string.Format(BaseUrl, appId), Requestor.CreateQuery(listParams)), "GET");
            return Mapper<RechargeList>.MapFromJson(rechargeList);
        }
    }
}
