using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;

namespace Pingpp.Models
{
    /// <summary>
    /// 结算账户对象
    /// </summary>
    public class SettleAccount : Pingpp
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("object")]
        public string Object { get; set; }
        [JsonProperty("created")]
        public int Created { get; set; }
        [JsonProperty("livemode")]
        public bool Livemode { get; set; }
        [JsonProperty("channel")]
        public string Channel { get; set; }
        [JsonProperty("recipient")]
        public Dictionary<string, object> recipient { get; set; }

        public const string BaseUrl = "/v1/apps/{0}/users/{1}/settle_accounts";

        /// <summary>
        /// 创建结算账户对象
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="userId"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static SettleAccount Create(string appId, string userId, Dictionary<string, object> param) 
        {
            var url = string.Format(BaseUrl, appId, userId);
            var settleAccount = Requestor.DoRequest(url, "POST", param);
            return Mapper<SettleAccount>.MapFromJson(settleAccount);
        }

        /// <summary>
        /// 查询结算账户对象
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="userId"></param>
        /// <param name="settleAccountId"></param>
        /// <returns></returns>
        public static SettleAccount Retrieve(string appId, string userId, string settleAccountId)
        {
            var url = string.Format("{0}/{1}", string.Format(BaseUrl, appId, userId), settleAccountId);
            var settleAccount = Requestor.DoRequest(url, "GET");
            return Mapper<SettleAccount>.MapFromJson(settleAccount);
        }

        /// <summary>
        /// 删除结算账户对象
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="userId"></param>
        /// <param name="settleAccountId"></param>
        /// <returns></returns>
        public static Deleted Delete(string appId, string userId, string settleAccountId) 
        {
            var url = string.Format("{0}/{1}", string.Format(BaseUrl, appId, userId), settleAccountId);
            var settleAccount = Requestor.DoRequest(url, "DELETE");
            return Mapper<Deleted>.MapFromJson(settleAccount);
        }

        /// <summary>
        /// 查询结算账户对象列表
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="userId"></param>
        /// <param name="listParams"></param>
        /// <returns></returns>
        public static SettleAccountList List(string appId, string userId, Dictionary<string, object> listParams = null) 
        {
            var url = Requestor.FormatUrl(string.Format(BaseUrl, appId, userId), Requestor.CreateQuery(listParams));
            var setList = Requestor.DoRequest(url, "GET");
            return Mapper<SettleAccountList>.MapFromJson(setList);
        }
    }
}
