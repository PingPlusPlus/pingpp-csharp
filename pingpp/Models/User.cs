using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;

namespace Pingpp.Models
{
    public class User : Pingpp
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("app")]
        public string App { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("related_app")]
        public string RelatedApp { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("available_coupons")]
        public int? AvailableCoupons { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("available_balance")]
        public long AvailableBalance { get; set; }
        [JsonProperty("withdrawable_balance")]
        public long WithdrawableBalance { get; set; }

        [JsonProperty("created")]
        public int? Created { get; set; }

        [JsonProperty("disabled")]
        public bool Disabled { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("identified")]
        public bool Identified { get; set; }

        [JsonProperty("livemode")]
        public bool Livemode { get; set; }

        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, object> Metadata { get; set; }
        [JsonProperty("settle_accounts")]
        public List<SettleAccount> SettleAccount { get; set; }

        private const string BaseUrl = "/v1/apps";

        public static User Create(string appId, Dictionary<string, object> uParams)
        {
            var url = string.Format("{0}/{1}/users", BaseUrl, appId);
            var user = Requestor.DoRequest(url, "POST", uParams);
            return Mapper<User>.MapFromJson(user);
        }

        public static User Retrieve(string appId, string uid)
        {
            var url = string.Format("{0}/{1}/users/{2}", BaseUrl, appId, uid);
            var user = Requestor.DoRequest(url, "GET");
            return Mapper<User>.MapFromJson(user);
        }

        public static User Update(string appId, string uid, Dictionary<string, object> uParams)
        {
            var url = string.Format("{0}/{1}/users/{2}", BaseUrl, appId, uid);
            var user = Requestor.DoRequest(url, "PUT", uParams);
            return Mapper<User>.MapFromJson(user);
        }

        public static User Disable(string appId, string uid)
        {
            var url = string.Format("{0}/{1}/users/{2}", BaseUrl, appId, uid);
            var user = Requestor.DoRequest(url, "PUT", new Dictionary<string, object>() { { "disabled", true } });
            return Mapper<User>.MapFromJson(user);
        }

        public static User Enable(string appId, string uid)
        {
            var url = string.Format("{0}/{1}/users/{2}", BaseUrl, appId, uid);
            var user = Requestor.DoRequest(url, "PUT", new Dictionary<string, object>() { { "disabled", false } });
            return Mapper<User>.MapFromJson(user);
        }

        public static UserList List(string appId, Dictionary<string, object> listParams = null)
        {
            var url = Requestor.FormatUrl(string.Format("{0}/{1}/users", BaseUrl, appId), Requestor.CreateQuery(listParams));
            var userList = Requestor.DoRequest(url, "GET");
            return Mapper<UserList>.MapFromJson(userList);
        }

    }
}
