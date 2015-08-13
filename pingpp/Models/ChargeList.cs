using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace pingpp.Models
{
    public class ChargeList : Pingpp
    {
        [JsonProperty("object")]
        public String Object { get; set; }
        [JsonProperty("url")]
        public String Url { get; set; }
        [JsonProperty("has_more")]
        public Boolean Has_more { get; set; }
        [JsonProperty("data")]
        public IEnumerable<Charge> Data { get; set; }
    }
}
