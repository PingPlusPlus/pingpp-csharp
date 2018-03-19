using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;

namespace Pingpp.Models
{
    public class RoyaltyTemplate : Pingpp
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("app")]
        public string App { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("created")]
        public int Created { get; set; }
        [JsonProperty("rule")]
        public Dictionary<string, object> Rule { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("object")]
        public string Object { get; set; }

        private const string BaseUrl = "/v1/royalty_templates";

        /// <summary>
        /// 创建分润模板
        /// </summary>
        /// <param name="createParams"></param>
        /// <returns></returns>
        public static RoyaltyTemplate Create(Dictionary<string, object> createParams)
        {
            var royaltyTemplate = Requestor.DoRequest(BaseUrl, "POST", createParams);
            return Mapper<RoyaltyTemplate>.MapFromJson(royaltyTemplate);
        }

        /// <summary>
        /// 查询分润模板
        /// </summary>
        /// <param name="royaltyTemplateId"></param>
        /// <returns></returns>
        public static RoyaltyTemplate Retrieve(string royaltyTemplateId)
        {
            var royaltyTemplate = Requestor.DoRequest(string.Format("{0}/{1}", BaseUrl, royaltyTemplateId), "GET");
            return Mapper<RoyaltyTemplate>.MapFromJson(royaltyTemplate);
        }
        /// <summary>
        /// 更新分润模板
        /// </summary>
        /// <param name="royaltyTemplateId"></param>
        /// <param name="updateParams"></param>
        /// <returns></returns>
        public static RoyaltyTemplate Update(string royaltyTemplateId, Dictionary<string, object> updateParams)
        {
            var royaltyTemplate = Requestor.DoRequest(string.Format("{0}/{1}", BaseUrl, royaltyTemplateId), "PUT", updateParams);
            return Mapper<RoyaltyTemplate>.MapFromJson(royaltyTemplate);
        }

        /// <summary>
        /// 删除分润模板
        /// </summary>
        /// <param name="royaltyTemplateId"></param>
        /// <returns></returns>
        public static Deleted Delete(string royaltyTemplateId)
        {
            var royaltyTemplate = Requestor.DoRequest(string.Format("{0}/{1}", BaseUrl, royaltyTemplateId), "DELETE");
            return Mapper<Deleted>.MapFromJson(royaltyTemplate);
        }

        public static RoyaltyTemplateList List(Dictionary<string, object> listParams = null)
        {
            var royaltyTemplateList = Requestor.DoRequest(Requestor.FormatUrl(BaseUrl, Requestor.CreateQuery(listParams)), "GET");
            return Mapper<RoyaltyTemplateList>.MapFromJson(royaltyTemplateList);
        }
    }
}
