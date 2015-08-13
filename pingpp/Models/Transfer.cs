using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Collections;
using pingpp.Net;

namespace pingpp.Models
{
    public class Transfer : Pingpp
    {
        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("object")]
        public String Object { get; set; }

        [JsonProperty("type")]
        public String Type { get; set; }

        [JsonProperty("created")]
        public int? Created { get; set; }

        [JsonProperty("time_transferred")]
        public int? Time_transferred { get; set; }

        [JsonProperty("livemode")]
        public bool Livemode { get; set; }

        [JsonProperty("status")]
        public String Status { get; set; }

        [JsonProperty("app")]
        public String App { get; set; }

        [JsonProperty("channel")]
        public String Channel { get; set; }

        [JsonProperty("order_no")]
        public String Order_no { get; set; }

        [JsonProperty("amount")]
        public int? Amount { get; set; }

        [JsonProperty("currency")]
        public String Currency { get; set; }

        [JsonProperty("recipient")]
        public String Recipient { get; set; }

        [JsonProperty("description")]
        public String Description { get; set; }

        [JsonProperty("transaction_no")]
        public String Transaction_no { get; set; }

        [JsonProperty("extra")]
        public Dictionary<String, Object> Extra { get; set; }



        private static volatile String url = "/v1/transfers";
        public static Transfer create(Dictionary<String, Object> transferParam)
        {
            String transfer = Requestor.DoRequest(url, "POST", transferParam);
            return Mapper<Transfer>.MapFromJson(transfer);
        }

        public static Transfer retrieve(String redId)
        {
            String urls = String.Format("{0}/{1}", url.ToString(), redId.ToString());
            String transfer = Requestor.DoRequest(urls, "Get");
            return Mapper<Transfer>.MapFromJson(transfer);
        }

        public static TransferList list(Dictionary<String, Object> listParam = null)
        {
            String query = Requestor.createQuery(listParam);
            String urls = Requestor.formatURL(url, query);
            String transferList = Requestor.DoRequest(urls, "Get");
            return Mapper<TransferList>.MapFromJson(transferList);
        }   
    }
}
