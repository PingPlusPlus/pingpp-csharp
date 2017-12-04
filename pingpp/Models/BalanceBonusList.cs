using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pingpp.Net;

namespace Pingpp.Models
{
    public class BalanceBonusList : Pingpp
    {
        [JsonProperty("object")]
        public string Object { set; get; }
        [JsonProperty("has_more")]
        public bool HasMore { set; get; }
        [JsonProperty("url")]
        public string Url { set; get; }
        [JsonProperty("data")]
        public IEnumerable<BalanceBonus> Data { get; set; }
    }
}
