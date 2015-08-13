using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Collections;
using pingpp.Net;

namespace pingpp.Models
{
    public class Event : Pingpp
    {
        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("object")]
        public String Object { get; set; }

        [JsonProperty("livemode")]
        public bool Livemode { get; set; }

        [JsonProperty("created")]
        public int? Created { get; set; }

        [JsonProperty("data")]
        public Dictionary<String, Object> Data { get; set; }

        [JsonProperty("pending_webhooks")]
        public int? Pending_webhooks { get; set; }

        [JsonProperty("type")]
        public String Type { get; set; }

        [JsonProperty("request")]
        public String Request { get; set; }

        private static volatile String url = "/v1/events";
        public static Event retrieve(String id)
        {
            String urls = String.Format("{0}/{1}", url.ToString(), id.ToString());
            String events = Requestor.DoRequest(urls, "Get");
            return Mapper<Event>.MapFromJson(events);
        }

        public static EventList list(Dictionary<String, Object> listParam = null)
        {
            String query = Requestor.createQuery(listParam);
            String urls = Requestor.formatURL(url, query);
            String eventList = Requestor.DoRequest(urls, "Get");
            return Mapper<EventList>.MapFromJson(eventList);
        }     
    }
    

}
