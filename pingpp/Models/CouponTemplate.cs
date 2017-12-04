using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;

namespace Pingpp.Models
{
    public class CouponTemplate : Pingpp
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("app")]
        public string App { get; set; }

        [JsonProperty("amount_available")]
        public int? AmountAvailable { get; set; }

        [JsonProperty("amount_off")]
        public int? AmountOff { get; set; }

        [JsonProperty("created")]
        public int? Created { get; set; }

        [JsonProperty("expiration")]
        public object Expiration { get; set; }

        [JsonProperty("livemode")]
        public bool Livemode { get; set; }

        [JsonProperty("max_circulation")]
        public int? MaxCirculation { get; set; }
        [JsonProperty("max_user_circulation")]
        public int MaxUserCirculation { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, object> Metadata { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("percent_off")]
        public int? PercentOff { get; set; }
        [JsonProperty("refundable")]
        public bool Refundable{ get; set;}

        [JsonProperty("times_circulated")]
        public int? TimesCirculated { get; set; }

        [JsonProperty("times_redeemed")]
        public int? TimesRedeemed { get; set; }

        [JsonProperty("type")]
        public int? Type { get; set; }


        private const string BaseUrl = "/v1/apps";

        public static CouponTemplate Create(string appId, Dictionary<string, object> couTmplParams)
        {
            var url = string.Format("{0}/{1}/coupon_templates", BaseUrl, appId);
            var couTmpl = Requestor.DoRequest(url, "POST", couTmplParams);
            return Mapper<CouponTemplate>.MapFromJson(couTmpl);
        }

        public static CouponTemplate Retrieve(string appId, string couTmplId)
        {
            var url = string.Format("{0}/{1}/coupon_templates/{2}", BaseUrl, appId, couTmplId);
            var couTmpl = Requestor.DoRequest(url, "GET");
            return Mapper<CouponTemplate>.MapFromJson(couTmpl);
        }

        public static CouponTemplate Update(string appId, string couTmplId, Dictionary<string, object> couTmplParams)
        {
            var url = string.Format("{0}/{1}/coupon_templates/{2}", BaseUrl, appId, couTmplId);
            var couTmpl = Requestor.DoRequest(url, "PUT", couTmplParams);
            return Mapper<CouponTemplate>.MapFromJson(couTmpl);
        }

        public static Deleted Delete(string appId, string couTmplId)
        {
            var url = string.Format("{0}/{1}/coupon_templates/{2}", BaseUrl, appId, couTmplId);
            var deletedMsg = Requestor.DoRequest(url, "DELETE");
            return Mapper<Deleted>.MapFromJson(deletedMsg);
        }

        public static CouponTemplateList List(string appId, Dictionary<string, object> listParams = null)
        {
            var url = Requestor.FormatUrl(string.Format("{0}/{1}/coupon_templates", BaseUrl, appId), Requestor.CreateQuery(listParams));
            var couTmplList = Requestor.DoRequest(url, "GET");
            return Mapper<CouponTemplateList>.MapFromJson(couTmplList);
        }

    }
}
