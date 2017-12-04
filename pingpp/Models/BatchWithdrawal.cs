using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pingpp.Net;


namespace Pingpp.Models
{
    /// <summary>
    /// 批量提现确认
    /// </summary>
    public class BatchWithdrawal : Pingpp
    {
        [JsonProperty("id")]
        public string Id { set; get; }
        [JsonProperty("object")]
        public string Object { set; get; }
        [JsonProperty("app")]
        public string App { set; get; }
        [JsonProperty("created")]
        public int? Created { set; get; }
        [JsonProperty("livemode")]
        public bool Livemode { set; get; }
        [JsonProperty("amount")]
        public int? Amount { set; get; }
        [JsonProperty("amount_succeeded")]
        public int? AmountSucceeded { set; get; }
        [JsonProperty("amount_failed")]
        public int? AmountFailed { set; get; }
        [JsonProperty("amount_canceled")]
        public int? AmountCanceled { set; get; }
        public int Count { set; get; }
        [JsonProperty("count_succeeded")]
        public int CountSucceeded { set; get; }
        [JsonProperty("count_failed")]
        public int CountFailed { set; get; }
        [JsonProperty("count_canceled")]
        public int CountCanceled { set; get; }
        [JsonProperty("fee")]
        public int? Fee { set; get; }
        [JsonProperty("metadata")]
        public Dictionary<string, object> Metadata { set; get; }
        [JsonProperty("operation_url")]
        public string OperationUrl { set; get; }
        [JsonProperty("source")]
        public string Source { set; get; }
        [JsonProperty("status")]
        public string Status { set; get; }
        [JsonProperty("user_fee")]
        public int? UserFee { set; get; }
        [JsonProperty("withdrawals")]
        public WithdrawalList Withdrawals { set; get; }
        [JsonProperty("time_finished")]
        public string TimeFinished { set; get; }

        private const string BaseUrl = "/v1/apps";

        /// <summary>
        /// 创建批量提现确认
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="batchwrParams"></param>
        /// <returns></returns>
        public static BatchWithdrawal Create(string appId, Dictionary<string, object> batchwrParams)
        {
            var url = string.Format("{0}/{1}/batch_withdrawals", BaseUrl, appId);
            var batchWithdrawal = Requestor.DoRequest(url, "POST", batchwrParams);
            return Mapper<BatchWithdrawal>.MapFromJson(batchWithdrawal);
        }

        /// <summary>
        /// 批量提现查询
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="batchWithdrawalId"></param>
        /// <returns></returns>
        public static BatchWithdrawal Retrieve(string appId, string batchWithdrawalId)
        {
            var url = string.Format("{0}/{1}/batch_withdrawals/{2}", BaseUrl, appId, batchWithdrawalId);
            var batchWithdrawal = Requestor.DoRequest(url, "GET");
            return Mapper<BatchWithdrawal>.MapFromJson(batchWithdrawal);
        }

        /// <summary>
        /// 批量提现列表查询
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="listParams"></param>
        /// <returns></returns>
        public static BatchWithdrawalList List(string appId, Dictionary<string, object> listParams = null)
        {
            var url = Requestor.FormatUrl(string.Format("{0}/{1}/batch_withdrawals", BaseUrl, appId), Requestor.CreateQuery(listParams));
            var batchWithdrawalList = Requestor.DoRequest(url, "GET", listParams);
            return Mapper<BatchWithdrawalList>.MapFromJson(batchWithdrawalList);
        }
    }
}