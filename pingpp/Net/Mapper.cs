using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using pingpp.Exception;

namespace pingpp.Net
{
    static class Mapper<T>
    {
        public static List<T> MapCollectionFromJson(string json, string data = "data")
        {
            var list = new List<T>();
            if (string.IsNullOrEmpty(json))
            {
                throw new PingppException("No List json received");
            }

            var jObject = JObject.Parse(json);

            var allTokens = jObject.SelectToken(data);

            foreach (var tkn in allTokens)
                list.Add(Mapper<T>.MapFromJson(tkn.ToString()));

            return list;
        }

        public static T MapFromJson(string json, string parentToken = null)
        {
            var jsonToParse = string.IsNullOrEmpty(parentToken) ? json : JObject.Parse(json).SelectToken(parentToken).ToString();
            return JsonConvert.DeserializeObject<T>(jsonToParse);
        }
    }
}
