using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Collections;
using pingpp.Net;

namespace pingpp.Models
{
    public class Refund : Pingpp
    {
        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("object")]
        public String Object { get; set; }

        [JsonProperty("order_no")]
        public String Oreder_no { get; set; }

        [JsonProperty("amount")]
        public int? Amount { get; set; }

        [JsonProperty("succeed")]
        public Boolean Succeed { get; set; }

        [JsonProperty("status")]
        public String Status { get; set; }

        [JsonProperty("created")]
        public int? Created { get; set; }

        [JsonProperty("time_succeed")]
        public int? Time_succeed { get; set; }

        [JsonProperty("description")]
        public String Description { get; set; }

        [JsonProperty("failure_code")]
        public String Failure_code { get; set; }

        [JsonProperty("failure_msg")]
        public String Failure_msg { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<String, Object> Metadata { get; set; }

        [JsonProperty("charge")]
        public String Charge { get; set; }





        private static volatile String url = "/v1/charges";

        public static Refund create(String id, Dictionary<String, Object> refundParam)
        {
            String urls = string.Format("{0}/{1}/refunds", url.ToString(), id.ToString());

            String refund = Requestor.DoRequest(urls, "POST", refundParam);
            return Mapper<Refund>.MapFromJson(refund);
        }

        public static Refund retrieve(String chId, String reId)
        {
            String urls = String.Format("/v1/charges/{0}/refunds/{1}", chId.ToString(), reId.ToString());
            String refund = Requestor.DoRequest(urls, "Get");
            return Mapper<Refund>.MapFromJson(refund);
        }

        public static RefundList list(String id, Dictionary<String, Object> listParam = null)
        {
            String urls = String.Format("/v1/charges/{0}/refunds", id.ToString());
            String query = Requestor.createQuery(listParam);
            urls = Requestor.formatURL(urls, query);
            String refundList = Requestor.DoRequest(urls, "Get");
            return Mapper<RefundList>.MapFromJson(refundList);
        }

    }
}
