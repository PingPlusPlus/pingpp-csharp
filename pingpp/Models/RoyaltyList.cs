using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pingpp.Models
{
    /// <summary>
    /// 分润对象列表对象
    /// </summary>
    public class RoyaltyList :Pingpp
    {
        [JsonProperty("object")]
        public string Object { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("has_more")]
        public bool HasMore { get; set; }
        [JsonProperty("data")]
        public IEnumerable<Royalty> Data { get; set; }
    }
}
