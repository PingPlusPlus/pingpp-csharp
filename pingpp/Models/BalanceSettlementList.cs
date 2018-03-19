using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pingpp.Models
{
    public class BalanceSettlementList :Pingpp
    {
        [JsonProperty("object")]
        public string Object { set; get; }
        [JsonProperty("has_more")]
        public bool HasMore { set; get; }
        [JsonProperty("url")]
        public string Url { set; get; }
        [JsonProperty("data")]
        public IEnumerable<BalanceSettlement> Data { get; set; }
    }
}
