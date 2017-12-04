using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pingpp.Models
{
    public class WithdrawalList : Pingpp
    {
        [JsonProperty("object")]
        public string Object { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("has_more")]
        public bool HasMore { get; set; }
        [JsonProperty("total_withdrawals_amount")]
        public int TotalWithdrawalsAmount;
        [JsonProperty("data")]
        public IEnumerable<Withdrawal> Data { get; set; }
    }
}
