using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Collections;
using pingpp.Net;


namespace pingpp.Models
{
    public class Charge : Pingpp
    {
        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("object")]
        public String Object { get; set; }

        [JsonProperty("created")]
        public int? Created { get; set; }

        [JsonProperty("livemode")]
        public bool Livemode { get; set; }

        [JsonProperty("paid")]
        public bool Paid { get; set; }

        [JsonProperty("refunded")]
        public bool Refunded { get; set; }

        [JsonProperty("app")]
        public String App { get; set; }

        [JsonProperty("channel")]
        public String Channel { get; set; }

        [JsonProperty("order_no")]
        public String Order_no { get; set; }

        [JsonProperty("client_ip")]
        public String Client_ip { get; set; }

        [JsonProperty("amount")]
        public int? Amount { get; set; }

        [JsonProperty("amount_settle")]
        public int? Amount_settle { get; set; }

        [JsonProperty("currency")]
        public String Currency { get; set; }

        [JsonProperty("subject")]
        public String Subject { get; set; }

        [JsonProperty("body")]
        public String Body { get; set; }

        [JsonProperty("extra")]
        public Dictionary<String, Object> Extra { get; set; }

        [JsonProperty("time_paid")]
        public int? Time_paid { get; set; }

        [JsonProperty("time_expire")]
        public int? Time_expire { get; set; }

        [JsonProperty("time_settle")]
        public int? Time_settle { get; set; }

        [JsonProperty("transaction_no")]
        public String Transaction_no { get; set; }

        [JsonProperty("refunds")]
        public RefundList Refunds { get; set; }

        [JsonProperty("amount_refunded")]
        public int? Amount_refunded { get; set; }

        [JsonProperty("failure_code")]
        public String Failure_code { get; set; }

        [JsonProperty("failure_msg")]
        public String Failure_msg { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<String, Object> Metadata { get; set; }

        [JsonProperty("credential")]
        public Object Credential { get; set; }

        [JsonProperty("description")]
        public String Description { get; set; }


        private static volatile String url = "/v1/charges";
        public static Charge create(Dictionary<String, Object> chargeParam)
        {
            String charge = Requestor.DoRequest(url, "POST", chargeParam);
            return Mapper<Charge>.MapFromJson(charge);
        }

        public static Charge retrieve(String id)
        {
            String urls = String.Format("{0}/{1}", url.ToString(), id.ToString());
            String charge = Requestor.DoRequest(urls, "Get");
            return Mapper<Charge>.MapFromJson(charge);
        }

            

        public static ChargeList list(Dictionary<String, Object> listParam = null)
        {
            String query = Requestor.createQuery(listParam);
            String urls = Requestor.formatURL(url, query);
            String charge = Requestor.DoRequest(urls, "Get");
            return Mapper<ChargeList>.MapFromJson(charge);
        }

    }

}
