using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Net;

namespace Pingpp.Models
{
    public class OrderRefund : Pingpp
    {
        private const string BaseUrl = "/v1/orders";

        /// <summary>
        /// 创建订单退款
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reParams"></param>
        /// <returns></returns>
        public static RefundList Create(string id, Dictionary<string, object> reParams)
        {
            var url = string.Format("{0}/{1}/order_refunds", BaseUrl, id);
            var re = Requestor.DoRequest(url, "POST", reParams);
            return Mapper<RefundList>.MapFromJson(re);
        }

        /// <summary>
        /// 查询订单退款
        /// </summary>
        /// <param name="orId"></param>
        /// <param name="reId"></param>
        /// <returns></returns>
        public static Refund Retrieve(string orId, string reId)
        {
            var url = string.Format("/v1/orders/{0}/order_refunds/{1}", orId, reId);
            var re = Requestor.DoRequest(url, "Get");
            return Mapper<Refund>.MapFromJson(re);
        }

        /// <summary>
        /// 查询订单退款列表
        /// </summary>
        /// <param name="orId"></param>
        /// <param name="listParams"></param>
        /// <returns></returns>
        public static RefundList List(string orId, Dictionary<string, object> listParams = null)
        {
            var refundList = Requestor.DoRequest(Requestor.FormatUrl(string.Format("/v1/orders/{0}/order_refunds", orId), Requestor.CreateQuery(listParams)), "Get");
            return Mapper<RefundList>.MapFromJson(refundList);
        }

    }
}
