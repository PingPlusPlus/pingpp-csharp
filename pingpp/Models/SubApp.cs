using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;

namespace Pingpp.Models
{
    /// <summary>
    /// 子商户应用
    /// </summary>
    public class SubApp : Pingpp
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("object")]
        public string Object { get; set; }
        [JsonProperty("created")]
        public int? Created { get; set; }
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        [JsonProperty("account")]
        public string Account { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, object> Metadata { get; set; }
        [JsonProperty("available_methods")]
        public List<string> AvailableMethods { get; set; }
        [JsonProperty("parent_app")]
        public String ParentApp { get; set; }
        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        private const string BaseUrl = "/v1/apps/{0}/sub_apps";

        /// <summary>
        /// 查询子商户应用列表
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="listParams"></param>
        /// <returns></returns>
        public static SubAppList List(string appId, Dictionary<string, object> listParams = null)
        {
            var url = Requestor.FormatUrl(string.Format(BaseUrl, appId), Requestor.CreateQuery(listParams));
            var subApp = Requestor.DoRequest(url, "GET");
            return Mapper<SubAppList>.MapFromJson(subApp);
        }

        /// <summary>
        /// 创建子商户对象
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static SubApp Create(string appId, Dictionary<string, object> param)
        {
            var url = Requestor.FormatUrl(string.Format(BaseUrl, appId), Requestor.CreateQuery(param));
            var subApp = Requestor.DoRequest(url, "POST");
            return Mapper<SubApp>.MapFromJson(subApp);
        }

        /// <summary>
        /// 查询子商户对象
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="subAppId"></param>
        /// <returns></returns>
        public static SubApp Retrieve(string appId, string subAppId) 
        {
            var url = string.Format("{0}/{1}", string.Format(BaseUrl, appId), subAppId);
            var subApp = Requestor.DoRequest(url, "GET");
            return Mapper<SubApp>.MapFromJson(subApp);
        }

        /// <summary>
        /// 更新子商户对象
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="subAppId"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static SubApp Update(string appId, string subAppId, Dictionary<string, object> param) 
        {
            var url = string.Format("{0}/{1}", string.Format(BaseUrl, appId), subAppId);
            var subApp = Requestor.DoRequest(url, "PUT", param);
            return Mapper<SubApp>.MapFromJson(subApp);
        }

        /// <summary>
        /// 删除子商户对象
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="subAppId"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static Deleted Delete(string appId, string subAppId)
        {
            var url = string.Format("{0}/{1}", string.Format(BaseUrl, appId), subAppId);
            var subApp = Requestor.DoRequest(url, "DELETE");
            return Mapper<Deleted>.MapFromJson(subApp);
        }
    }
}
