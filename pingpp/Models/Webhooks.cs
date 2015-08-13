using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pingpp.Net;
using pingpp.Exception;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace pingpp.Models
{
    public class Webhooks : Pingpp
    {
        public static Event parseWebhook(string events)
        {
            var eve = JObject.Parse(events);
            var obj = eve.SelectToken("object");
            if (events.Contains("object") && obj.ToString().Equals("event"))
            {
                return Mapper<Event>.MapFromJson(events);       
            }
            else
            {
                throw new PingppException("It isn't a json string of event object");
            }
            
        }
    }
}
