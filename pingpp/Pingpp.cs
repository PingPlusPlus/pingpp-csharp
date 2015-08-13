using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace pingpp
{
    public abstract class Pingpp
    {
        public static volatile string apiVersion = "2015-08-13";
        public static volatile string acceptLanguage = "zh-CN";
        public static volatile String apiBase = "https://api.pingxx.com";
        public static volatile String VERSION = "1.0.0";
        public static int defaultTimeout = 80000;
        public static int defaultReadAndWriteTimeout = 20000;
        public static volatile String apiKey;
        internal static string GetApiKey()
        {
            return apiKey;
        }

        public static void SetApiKey(string newApiKey)
        {
            apiKey = newApiKey;
        }


        public override String ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
