using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;

namespace Pingpp.Models
{
    public class CardInfo : Pingpp
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("last4")]
        public string Last4 { get; set; }

        [JsonProperty("funding")]
        public string Funding { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("bank")]
        public string Bank { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }

        private const string BaseUrl = "/v1/card_info";

        public static CardInfo Retrieve(string cardNumber, string appId)
        {
            var cardNum = Requestor.DoRequest(BaseUrl, "POST", new Dictionary<string, object> { { "card_number", cardNumber }, { "app", appId } });
            return Mapper<CardInfo>.MapFromJson(cardNum);
        }
    }
}
