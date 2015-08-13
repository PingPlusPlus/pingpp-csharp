using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Collections;
using pingpp.Net;

namespace pingpp.Models
{
    public class Error
    {
        [JsonProperty("type")]
        public string ErrorType { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

    }
}
