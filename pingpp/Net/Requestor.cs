using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Web;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Specialized;
using System.Reflection;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Globalization;
using pingpp.Models;
using pingpp.Exception;
using System.Timers;




namespace pingpp.Net
{
    internal class Requestor : Pingpp
    {
        private static string getAuthenrization(string apiKey)
        {
            return string.Format("Bearer {0}", apiKey);
        }

        internal static HttpWebRequest GetRequest(string path, string method, string key)
        {
            string url = apiBase + path;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Authorization", getAuthenrization(key));
            request.Headers.Add("Pingplusplus-Version", apiVersion);
            request.Headers.Add("Accept-Language", acceptLanguage);
            request.UserAgent = "Pingpp C# SDK version" + VERSION;
            request.ContentType = "application/json;charset=utf-8";
            request.Timeout = defaultTimeout;
            request.ReadWriteTimeout = defaultReadAndWriteTimeout;
            request.Method = method;
            return request;
        }


        internal static string DoRequest(string path, string method, Dictionary<String, Object> param = null)
        {

            string result = null;
            string body = null;
            string key = apiKey;
            HttpWebResponse response;
            HttpWebRequest webRequest = GetRequest(path, method, key);

            if ("POST".Equals(method.ToUpper()))
            {
                if (param != null)
                {
                    body = JsonConvert.SerializeObject(param, Formatting.Indented);
                }
                else
                {
                    throw new PingppException("request params for request is empty");
                }

                try
                {
                    using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
                    {
                        streamWriter.Write(body);
                        streamWriter.Flush();
                        streamWriter.Close();

                        using (response = webRequest.GetResponse() as HttpWebResponse)
                        {

                            return ReadStream(response.GetResponseStream());
                        }
                    }
                }


                catch (WebException e)
                {

                    if (e.Response != null)
                    {
                        var statusCode = ((HttpWebResponse)e.Response).StatusCode;

                        var errors = new Error();


                        errors = Mapper<Error>.MapFromJson(ReadStream(e.Response.GetResponseStream()), "error");

                        throw new PingppException(errors, statusCode, errors.ErrorType, errors.Message);
                    }
                    else
                    {
                        throw new PingppException(e.Message.ToString());
                    }


                }
            }
            else if ("GET".Equals(method.ToUpper()))
            {
                try
                {
                    using (response = webRequest.GetResponse() as HttpWebResponse)
                    {
                        return ReadStream(response.GetResponseStream());
                    }
                }
                catch (WebException e)
                {
                    if (e.Response != null)
                    {
                        var statusCode = ((HttpWebResponse)e.Response).StatusCode;

                        var errors = new Error();


                        errors = Mapper<Error>.MapFromJson(ReadStream(e.Response.GetResponseStream()), "error");

                        throw new PingppException(errors, statusCode, errors.ErrorType, errors.Message);
                    }
                    else
                    {
                        throw new WebException(e.Message.ToString());
                    }
                }
            }

            return result;
        }

        //读取 response 流
        private static string ReadStream(Stream stream)
        {
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }


        internal static Dictionary<String, String> FormatParam(Dictionary<String, Object> param)
        {
            if (param == null)
            {
                return new Dictionary<String, String>();
            }
            Dictionary<String, String> formattedParam = new Dictionary<string, string>();
            foreach (KeyValuePair<String, Object> dic in param)
            {
                String key = dic.Key;
                Object value = dic.Value;
                if (value is Dictionary<String, String>)
                {

                    Dictionary<String, Object> formatNestedDic = new Dictionary<String, Object>();

                    foreach (KeyValuePair<String, String> nestedDict in (Dictionary<String, String>)value)
                    {
                        formatNestedDic.Add(String.Format("{0}[{1}]", key, nestedDict.Key), nestedDict.Value.ToString());
                    }

                    foreach (KeyValuePair<String, String> nestedDict in FormatParam(formatNestedDic))
                    {
                        formattedParam.Add(nestedDict.Key, nestedDict.Value);
                    }
                }
                else if (value is Dictionary<String, Object>)
                {
                    Dictionary<string, Object> formatNestedDic = new Dictionary<string, Object>();

                    foreach (KeyValuePair<String, Object> nestedDict in (Dictionary<String, Object>)value)
                    {
                        formatNestedDic.Add(String.Format("{0}[{1}]", key, nestedDict.Key), nestedDict.Value.ToString());
                    }

                    foreach (KeyValuePair<String, String> nestedDict in FormatParam(formatNestedDic))
                    {
                        formattedParam.Add(nestedDict.Key, nestedDict.Value);
                    }
                }
                else if (value is IList)
                {
                    List<Object> li = (List<Object>)value;
                    Dictionary<string, Object> formatNestedDic = new Dictionary<string, Object>();
                    int size = li.Count();
                    for (int i = 0; i < size; i++)
                    {
                        formatNestedDic.Add(String.Format("{0}[{1}]", key, i), li[i]);
                    }
                    foreach (KeyValuePair<string, string> nestedDict in FormatParam(formatNestedDic))
                    {
                        formattedParam.Add(nestedDict.Key, nestedDict.Value);
                    }
                }
                else if ("".Equals(value))
                {
                    throw new PingppException("You cannot set '" + key + "' to an empty string. " +
                        "We interpret empty strings as null in requests. " +
                        "You may set '" + key + "' to null to delete the property.");
                }
                else if (value == null)
                {
                    formattedParam.Add(key, "");
                }
                else
                {
                    formattedParam.Add(key, value.ToString());
                }

            }
            return formattedParam;
        }

        internal static String createQuery(Dictionary<String, Object> param)
        {
            Dictionary<String, String> flatParams = FormatParam(param);
            StringBuilder queryStringBuffer = new StringBuilder();
            foreach (KeyValuePair<String, String> entry in flatParams)
            {
                if (queryStringBuffer.Length > 0)
                {
                    queryStringBuffer.Append("&");
                }

                queryStringBuffer.Append(urlEncodePair(entry.Key, entry.Value));
            }
            return queryStringBuffer.ToString();
        }





        internal static String urlEncodePair(String k, String v)
        {
            return String.Format("{0}={1}", urlEncode(k), urlEncode(v));
        }


        private static String urlEncode(String str)
        {
            if (str == null)
            {
                return null;
            }
            else
            {
                HttpUtility.UrlEncode(str, Encoding.UTF8);
                return HttpUtility.UrlEncode(str);
            }
        }

        internal static String formatURL(String url, String query)
        {
            if (query == null || string.IsNullOrEmpty(query))
            {
                return url;
            }
            else
            {
                // In some cases, URL can already contain a question mark (eg, upcoming invoice lines)
                String separator = url.Contains("?") ? "&" : "?";
                return String.Format("{0}{1}{2}", url, separator, query);
            }
        }



    }
}
