using System;
using Newtonsoft.Json;

namespace Pingpp.Models
{
    /// <summary>
    /// 删除子商户应用支付渠道对象
    /// </summary>
    public class DeletedSubAppChannel : Pingpp
    {
        [JsonProperty("deleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }
    }
}
