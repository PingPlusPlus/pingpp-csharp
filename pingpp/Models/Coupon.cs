using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;

namespace Pingpp.Models
{
    public class Coupon : Pingpp
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("app")]
        public string App { get; set; }

        [JsonProperty("actual_amount")]
        public int? ActualAmount { get; set; }

        [JsonProperty("coupon_template")]
        public CouponTemplate CouponTemplate { get; set; }

        [JsonProperty("created")]
        public int? Created { get; set; }

        [JsonProperty("livemode")]
        public bool Livemode { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, object> Metadata { get; set; }

        [JsonProperty("user_times_circulated")]
        public int UserTimesCirculated {get; set;}

        [JsonProperty("order")]
        public string Order { get; set; }

        [JsonProperty("redeemed")]
        public bool Redeemed { get; set; }

        [JsonProperty("time_end")]
        public int? TimeEnd { get; set; }

        [JsonProperty("time_start")]
        public int? TimeStart { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("valid")]
        public bool Valid { get; set; }

        private const string BaseUrl = "/v1/apps";

        public static Coupon Create(string appId, string uid, Dictionary<string, object> couParams)
        {
            var url = string.Format("{0}/{1}/users/{2}/coupons", BaseUrl, appId, uid);
            var cou = Requestor.DoRequest(url, "POST", couParams);
            return Mapper<Coupon>.MapFromJson(cou);
        }

        public static CouponList BatchCreate(string appId, string couTmplId, Dictionary<string, object> couParams)
        {
            var url = string.Format("{0}/{1}/coupon_templates/{2}/coupons", BaseUrl, appId, couTmplId);
            var couList = Requestor.DoRequest(url, "POST", couParams);
            return Mapper<CouponList>.MapFromJson(couList);
        }

        public static Coupon Retrieve(string appId, string uid, string couId)
        {
            var url = string.Format("{0}/{1}/users/{2}/coupons/{3}", BaseUrl, appId, uid, couId);
            var cou = Requestor.DoRequest(url, "GET");
            return Mapper<Coupon>.MapFromJson(cou);
        }

        public static Coupon Update(string appId, string uid, string couId, Dictionary<string, object> couParams)
        {
            var url = string.Format("{0}/{1}/users/{2}/coupons/{3}", BaseUrl, appId, uid, couId);
            var cou = Requestor.DoRequest(url, "PUT", couParams);
            return Mapper<Coupon>.MapFromJson(cou);
        }

        public static Deleted Delete(string appId, string uid, string couId)
        {
            var url = string.Format("{0}/{1}/users/{2}/coupons/{3}", BaseUrl, appId, uid, couId);
            var deletedMsg = Requestor.DoRequest(url, "DELETE");
            return Mapper<Deleted>.MapFromJson(deletedMsg);
        }

        public static CouponList List(string appId, string uid, Dictionary<string, object> listParams = null)
        {
            var url = Requestor.FormatUrl(string.Format("{0}/{1}/users/{2}/coupons", BaseUrl, appId, uid), Requestor.CreateQuery(listParams));
            var couList = Requestor.DoRequest(url, "GET");
            return Mapper<CouponList>.MapFromJson(couList);
        }

        public static CouponList ListInTemplate(string appId, string couTmplId, Dictionary<string, object> listParams = null)
        {
            var url = Requestor.FormatUrl(string.Format("{0}/{1}/coupon_templates/{2}/coupons", BaseUrl, appId, couTmplId), Requestor.CreateQuery(listParams));
            var couList = Requestor.DoRequest(url, "GET");
            return Mapper<CouponList>.MapFromJson(couList);
        }

    }
}
