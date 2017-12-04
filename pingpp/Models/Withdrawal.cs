using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;

namespace Pingpp.Models
{
    public class Withdrawal : Pingpp
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("app")]
        public string App { get; set; }

        [JsonProperty("amount")]
        public int? Amount { get; set; }

        [JsonProperty("asset_transaction")]
        public string AssetTransaction { get; set; }

        [JsonProperty("balance_transaction")]
        public string BalanceTransaction { get; set; }

        [JsonProperty("created")]
        public int? Created { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("extra")]
        public Dictionary<string, object> Extra { get; set; }

        [JsonProperty("fee")]
        public int? Fee { get; set; }

        [JsonProperty("livemode")]
        public bool Livemode { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, object> Metadata { get; set; }

        [JsonProperty("order_no")]
        public string OrderNo { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("time_canceled")]
        public int? TimeCanceled { get; set; }

        [JsonProperty("time_succeeded")]
        public int? TimeSucceeded { get; set; }
        [JsonProperty("user")]
        public string User { get; set; }
        [JsonProperty("user_fee")]
        public int? UserFee { get; set; }
        [JsonProperty("channel")]
        public string Channel { set; get; }
        [JsonProperty("failure_msg")]
        public string FailureMsg { set; get; }
        [JsonProperty("operation_url")]
        public string OperationUrl { set; get; }
        [JsonProperty("settle_account")]
        public string SettleAccount { get; set; }

        private const string BaseUrl = "/v1/apps";

        /// <summary>
        /// 余额提现申请
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="uid"></param>
        /// <param name="wdParams"></param>
        /// <returns></returns>
        public static Withdrawal Request(string appId, Dictionary<string, object> wdParams)
        {
            var url = string.Format("{0}/{1}/withdrawals", BaseUrl, appId);
            var wd = Requestor.DoRequest(url, "POST", wdParams);
            return Mapper<Withdrawal>.MapFromJson(wd);
        }

        /// <summary>
        /// 余额提现取消
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="uid"></param>
        /// <param name="wdId"></param>
        /// <returns></returns>
        public static Withdrawal Cancel(string appId, string wdId)
        {
            var url = string.Format("{0}/{1}/withdrawals/{2}", BaseUrl, appId, wdId);
            var wd = Requestor.DoRequest(url, "PUT", new Dictionary<string, object> { { "status", "canceled" } });
            return Mapper<Withdrawal>.MapFromJson(wd);
        }

        /// <summary>
        /// 余额提现确认
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="uid"></param>
        /// <param name="wdId"></param>
        /// <returns></returns>
        public static Withdrawal Confirm(string appId, string wdId)
        {
            var url = string.Format("{0}/{1}/withdrawals/{2}", BaseUrl, appId, wdId);
            var wd = Requestor.DoRequest(url, "PUT", new Dictionary<string, object> { { "status", "pending" } });
            return Mapper<Withdrawal>.MapFromJson(wd);
        }

        /// <summary>
        /// 余额提现列表查询
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="listParams"></param>
        /// <returns></returns>
        public static WithdrawalList List(string appId, Dictionary<string, object> listParams)
        {
            var url = Requestor.FormatUrl(string.Format("{0}/{1}/withdrawals", BaseUrl, appId), Requestor.CreateQuery(listParams));
            var wd = Requestor.DoRequest(url, "GET");
            return Mapper<WithdrawalList>.MapFromJson(wd);
        }

        /// <summary>
        /// 余额提现查询
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="userId"></param>
        /// <param name="wdId"></param>
        /// <returns></returns>
        public static Withdrawal Retrieve(string appId, string wdId)
        {
            var url = string.Format("{0}/{1}/withdrawals/{2}", BaseUrl,appId, wdId);
            var wd = Requestor.DoRequest(url, "GET");
            return Mapper<Withdrawal>.MapFromJson(wd);
        }
    }
}
