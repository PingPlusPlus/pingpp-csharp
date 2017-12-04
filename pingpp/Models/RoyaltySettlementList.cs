using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;


namespace Pingpp.Models
{
    /// <summary>
    /// 分润结算对象列表
    /// </summary>
    public class RoyaltySettlementList : Pingpp
    {
        [JsonProperty("object")]
        public string Object { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("has_more")]
        public bool HasMore { get; set; }
        [JsonProperty("data")]
        public IEnumerable<RoyaltySettlement> Data { get; set; }
    }
}
