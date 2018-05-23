using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;
using Pingpp.Exception;

namespace Pingpp.Models
{
    /// <summary>
    /// 签约对象
    /// </summary>
    public class Agreement :Pingpp
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("object")]
        public string Object { get; set; }
        [JsonProperty("livemode")]
        public bool Livemode { get; set; }
        [JsonProperty("app")]
        public string App { get; set; }
        [JsonProperty("created")]
        public int? Created { get; set; }
        [JsonProperty("channel")]
        public string Channel { get; set; }
        [JsonProperty("contract_no")]
        public string ContractNo { get; set; }
        [JsonProperty("contract_id")]
        public string ContractId { get; set; }
        [JsonProperty("credential")]
        public Dictionary<string, object> Credential { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("time_succeeded")]
        public int? TimeSucceeded { get; set; }
        [JsonProperty("time_canceled")]
        public int? TImeCanceled { get; set; }
        [JsonProperty("failure_code")]
        public string FailureCode { get; set; }
        [JsonProperty("failure_msg")]
        public string FailureMsg { get; set; }
        [JsonProperty("metadata")]
        public Dictionary<string, object> Metadata { get; set; }
        [JsonProperty("extra")]
        public Dictionary<string, object> Extra { get; set; }

        private const string BaseUrl = "/v1/agreements";

        /// <summary>
        /// 创建签约接口
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static Agreement Create(Dictionary<string, object> param)
        {
            var agreement = Requestor.DoRequest(BaseUrl, "POST", param);
            return Mapper<Agreement>.MapFromJson(agreement);
        }

        /// <summary>
        /// 查询签约对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Agreement Retrieve(string Id) 
        {
            var agreement = Requestor.DoRequest(string.Format("{0}/{1}", BaseUrl, Id), "GET");
            return Mapper<Agreement>.MapFromJson(agreement);
        }

        /// <summary>
        /// 解除签约
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Agreement Cancel(string Id) 
        {
            Dictionary<string, object> param = new Dictionary<string, object> {{ "status", "canceled" }};
            var agreement = Requestor.DoRequest(string.Format("{0}/{1}", BaseUrl, Id), "PUT", param);
            return Mapper<Agreement>.MapFromJson(agreement);
        }

        /// <summary>
        /// 查询签约对象列表
        /// </summary>
        /// <param name="listParams"></param>
        /// <returns></returns>
        public static AgreementList List(Dictionary<string, object> listParams) 
        {
            var agreementList = Requestor.DoRequest(Requestor.FormatUrl(BaseUrl, Requestor.CreateQuery(listParams)), "GET");
            return Mapper<AgreementList>.MapFromJson(agreementList);
        }
    }
}
