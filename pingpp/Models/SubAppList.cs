using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;

namespace Pingpp.Models
{
    /// <summary>
    /// 子商户列表对象
    /// </summary>
    public class SubAppList :Pingpp
    {
        [JsonProperty("object")]
        public string Object { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("has_more")]
        public bool HasMore { get; set; }
        [JsonProperty("data")]
        public IEnumerable<SubApp> Data { get; set; }
    }
}
