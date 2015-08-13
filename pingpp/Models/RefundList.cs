using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace pingpp.Models
{
    public class RefundList : Pingpp
    {
        [JsonProperty("object")]
        public String Object { get; set; }
        [JsonProperty("url")]
        public String Url { get; set; }
        [JsonProperty("has_more")]
        public Boolean Has_more { get; set; }
        [JsonProperty("data")]
        public IEnumerable<Refund> Data { get; set; }
    }
}
