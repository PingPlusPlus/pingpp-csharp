using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;


namespace Pingpp.Models
{
    public class Order : Pingpp
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("created")]
        public int? Created { get; set; }

        [JsonProperty("livemode")]
        public bool Livemode { get; set; }

        [JsonProperty("refunded")]
        public bool Refunded { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("paid")]
        public bool Paid;

        [JsonProperty("app")]
        public string App { get; set; }

        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("merchant_order_no")]
        public string MerchantOrderNo { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set ;}

        [JsonProperty("coupon_amount")]
        public int? CouponAmount { get; set; }

        [JsonProperty("amount_refunded")]
        public int? AmountRefunded { get; set; }

        [JsonProperty("actual_amount")]
        public int ActualAmount { set; get; }
        [JsonProperty("amount_paid")]
        public int AmountPaid { set; get; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("client_ip")]
        public string ClientIp { get; set; }

        [JsonProperty("time_paid")]
        public int? TimePaid { get; set; }

        [JsonProperty("time_expire")]
        public int? TimeExpire { get; set; }

        [JsonProperty("charge")]
        public string Charge { get; set; }

        [JsonProperty("coupon")]
        public string Coupon { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, object> Metadata { get; set; }

        [JsonProperty("charge_essentials")]
        public Dictionary<string,object> ChargeEssentials { get; set; }

        [JsonProperty("available_balance")]
        public long AvailableBalance { set; get; }

        [JsonProperty("receipt_app")]
        public string ReceiptApp { get; set; }
        [JsonProperty("service_app")]
        public string ServiceApp { get; set; }
        [JsonProperty("available_methods")]
        public List<string> AvailableMethods { get; set; }
        [JsonProperty("charges")]
        public ChargeList Charges { set; get; }

        private const string BaseUrl = "/v1/orders";

        /// <summary>
        /// 创建商品订单订单
        /// </summary>
        /// <param name="orParams"></param>
        /// <returns></returns>
        public static Order Create(Dictionary<string, object> orParams)
        {
            var or = Requestor.DoRequest(BaseUrl, "POST", orParams);
            return Mapper<Order>.MapFromJson(or);
        }

        /// <summary>
        /// 查询商品订单订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Order Retrieve(string id)
        {
            var url = string.Format("{0}/{1}", BaseUrl, id);
            var or = Requestor.DoRequest(url, "GET");
            return Mapper<Order>.MapFromJson(or);
        }

        /// <summary>
        /// 消费商品订单支付
        /// </summary>
        /// <param name="id"></param>
        /// <param name="payParams"></param>
        /// <returns></returns>
        public static Order Pay(string id, Dictionary<string, object> payParams = null)
        {
            var url = string.Format("{0}/{1}/pay", BaseUrl, id);
            var or = Requestor.DoRequest(url, "POST", payParams);
            return Mapper<Order>.MapFromJson(or);
        }

        /// <summary>
        /// 取消商品订单订单
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancelParams"></param>
        /// <returns></returns>
        public static Order Cancel(string id, Dictionary<string,object> cancelParams = null)
        {
            var url = string.Format("{0}/{1}", BaseUrl, id);
            if (cancelParams == null)
            {
                cancelParams = new Dictionary<string, object> { { "status", "canceled" } };
            }
            if (!cancelParams.ContainsKey("status")) {
                cancelParams.Add("status", "canceled");
            }
            var or = Requestor.DoRequest(url, "PUT", cancelParams);
            return Mapper<Order>.MapFromJson(or);
        }

        /// <summary>
        /// 查询商品订单列表
        /// </summary>
        /// <param name="listParams"></param>
        /// <returns></returns>
        public static OrderList List(Dictionary<string, object> listParams = null)
        {
            var url = Requestor.FormatUrl(BaseUrl, Requestor.CreateQuery(listParams));
            var or = Requestor.DoRequest(url, "GET");
            return Mapper<OrderList>.MapFromJson(or);
        }

        /// <summary>
        /// 查询order中的charge对象列表
        /// </summary>
        /// <param name="id"></param>
        /// <param name="listParams"></param>
        /// <returns></returns>
        public static ChargeList ChargeList(string id,Dictionary<string ,object> listParams = null)
        {
            var url = Requestor.FormatUrl(string.Format("{0}/{1}/charges", BaseUrl, id), Requestor.CreateQuery(listParams));
            var charges = Requestor.DoRequest(url, "GET");
            return Mapper<ChargeList>.MapFromJson(charges);
        }

        /// <summary>
        /// 查询order中的charge对象
        /// </summary>
        /// <param name="id"></param>
        /// <param name="chargeId"></param>
        /// <returns></returns>
        public static Charge ChargeRetrieve(string id, string chargeId)
        {
            var url = string.Format("{0}/{1}/charges/{2}", BaseUrl, id, chargeId);
            var charge = Requestor.DoRequest(url, "GET");
            return Mapper<Charge>.MapFromJson(charge);
        }
    }

}
