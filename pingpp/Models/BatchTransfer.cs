using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;


namespace Pingpp.Models
{
    /// <summary>
    /// batch_transfer
    /// </summary>
    public class BatchTransfer : Pingpp
    {
        [JsonProperty("id")]
        public string Id{ set; get; }
        [JsonProperty("object")]
        public string Object{ set; get; }
        [JsonProperty("app")]
        public string App{ set; get; }
        [JsonProperty("amount")]
        public int? Amount{ set; get; }
        [JsonProperty("batch_no")]
        public string BatchNo{ set; get; }
        [JsonProperty("channel")]
        public string Channel{ set; get; }
        [JsonProperty("currency")]
        public string currency { set; get; }
        [JsonProperty("created")]
        public int? Created{ set; get; }
        [JsonProperty("description")]
        public string Description { set; get; }
        [JsonProperty("extra")]
        public Dictionary<string, object> extra { set; get; }
        [JsonProperty("failure_msg")]
        public string FailureMsg;
        [JsonProperty("fee")]
        public int Fee { set; get; }
        [JsonProperty("livemode")]
        public bool Livemode { set; get; }
        [JsonProperty("metadata")]
        public Dictionary<string, object> MetaData { set; get; }
        [JsonProperty("recipients")]
        public List<RecipientsList> RecipientsList { set; get; }

        [JsonProperty("status")]
        public string Status { set; get; }
        [JsonProperty("time_succeeded")]
        public string TimeSucceeded;
        [JsonProperty("type")]
        public string Type { set; get; }

        private const string BaseUrl = "/v1/batch_transfers";
        /// <summary>
        /// 创建批量付款Object
        /// </summary>
        /// <param name="btParams"></param>
        /// <returns></returns>
        public static BatchTransfer Create(Dictionary<string, object> btParams)
        {
            var batchTranster = Requestor.DoRequest(BaseUrl, "POST", btParams, true);
            return Mapper<BatchTransfer>.MapFromJson(batchTranster);
        }

        /// <summary>
        /// 查询批量付款明细 Object
        /// </summary>
        /// <param name="batchTransferNo"></param>
        /// <returns></returns>
        public static BatchTransfer Retrieve(string batchTransferNo)
        {
            var url = string.Format("{0}/{1}", BaseUrl, batchTransferNo);
            var batchTranster = Requestor.DoRequest(url, "GET");
            return Mapper<BatchTransfer>.MapFromJson(batchTranster);
        }

        public static BatchTransferList List(Dictionary<string, object> btParams)
        {
            var url = Requestor.FormatUrl(BaseUrl, Requestor.CreateQuery(btParams));
            var batchTranster = Requestor.DoRequest(url, "GET");
            return Mapper<BatchTransferList>.MapFromJson(batchTranster);
        }

        public static BatchTransfer Cancel(String batchTransferNo)
        {
            var cancelParams = new Dictionary<string, object> {
                {"status", "canceled"}
            };
            var ch = Requestor.DoRequest(String.Format("{0}/{1}", BaseUrl, batchTransferNo), "PUT", cancelParams, true);
            return Mapper<BatchTransfer>.MapFromJson(ch);
        }
    }

    [Serializable]
    public class RecipientsList
    {
        [JsonProperty("account")]
        public string Account { set; get; }
        [JsonProperty("amount")]
        public string Amount { set; get; }
        [JsonProperty("name")]
        public string Name { set; get; }
        [JsonProperty("transfer")]
        public string Transfer { set; get; }
        [JsonProperty("open_bank", NullValueHandling = NullValueHandling.Ignore)]
        public string BankName { set; get; }
        [JsonProperty("open_bank_code", NullValueHandling = NullValueHandling.Ignore)]
        public string BankCode { set; get; }
        [JsonProperty("status")]
        public string Status { set; get; }
    }
}
