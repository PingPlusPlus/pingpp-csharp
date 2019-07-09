using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;
using Pingpp.Exception;

namespace Pingpp.Models
{
    public class SubBank : Pingpp
    {
        [JsonProperty("object")]
        public string Object { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("prov")]
        public string Prov { get; set; }
        [JsonProperty("sub_bank")]
        public string SubBankName { get; set; }
        [JsonProperty("sub_bank_code")]
        public string SubBankCode { get; set; }

        private const string BaseUrl = "/v1/sub_banks";

        public static SubBankList List(Dictionary<string, object> listParam) 
        {

            var subBankList = Requestor.DoRequest(Requestor.FormatUrl(BaseUrl, Requestor.CreateQuery(listParam)), "GET");
            return Mapper<SubBankList>.MapFromJson(subBankList);
        }
    }
}
