using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using pingpp.Models;

namespace pingpp.Exception
{
    [Serializable]
    public class PingppException : ApplicationException
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public Error Error { get; set; }

        public PingppException()
        {
        }

        public PingppException(string message)
            : base(message)
        {
        }


        public PingppException(Error pingppError, HttpStatusCode httpStatusCode, string type = null, string message = null)
            : base(message)
        {
            HttpStatusCode = httpStatusCode;
            Error = pingppError;
        }

    }
}
