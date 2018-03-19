using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;

namespace Pingpp.Models
{
    public class CardInfo : Pingpp
    {
        [JsonProperty("app")]
        public string App { get; set; }

        [JsonProperty("card_bin")]
        public string CardBin { get; set; }

        [JsonProperty("card_type")]
        public int CardType { get; set; }

        [JsonProperty("open_bank_code")]
        public string OpenBankCode { get; set; }

        [JsonProperty("open_bank")]
        public string OpenBank { get; set; }
        
        [JsonProperty("support_channels")]
        public List<string> SupportChannels { get; set; }
        
        private const string BaseUrl = "/v1/card_info";

        /// <summary>
        /// 银行卡信息查询
        /// </summary>
        /// <param name="Params"></param>
        /// <returns></returns>
        public static CardInfo Query(Dictionary<string, object> Params)
        {
            var cardInfo = Requestor.DoRequest(BaseUrl, "POST", Params);
            return Mapper<CardInfo>.MapFromJson(cardInfo);
        }
    }
}
