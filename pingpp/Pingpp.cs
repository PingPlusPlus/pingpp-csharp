﻿using System;
using Newtonsoft.Json;
using System.IO;
using Pingpp.Exception;

namespace Pingpp
{
    public abstract class Pingpp
    {
        public static volatile string ApiVersion;
        public static volatile string AcceptLanguage = "zh-CN";
        public static volatile string ApiBase = "https://api.pingxx.com";
        public static volatile string Version = "1.5.0";
        public static volatile bool BadGateWayMatch = true;
        public static volatile int MaxNetworkRetries = 1;
        protected static volatile int MaxRetry = 0;
        public static int DefaultTimeout = 80000;
        public static int DefaultReadAndWriteTimeout = 20000;
        public static volatile string ApiKey;
        public static volatile byte[] PrivateKey;

        public static void SetMaxNetworkRetries(int maxNetworkRetries) 
        {
            MaxNetworkRetries = maxNetworkRetries;
        }

        public static void SetBadGateWayMatch(bool badGateWayMatch)
        {
            BadGateWayMatch = badGateWayMatch;
        }

        public static void SetApiBase(string newApiBase) 
        {
            ApiBase = newApiBase;
        }
        internal static string GetApiKey()
        {
            return ApiKey;
        }

        public static void SetApiKey(string newApiKey)
        {
            ApiKey = newApiKey;
        }

        internal static byte[] GetPrivateKey()
        {
            return PrivateKey;
        }

        public static void SetPrivateKey(string newPrivateKey)
        {
            PrivateKey = FormatPrivateKey(newPrivateKey);
        }

        public static void SetPrivateKeyPath(string newPrivateKeyPath)
        {
            try
            {
                var privateKeyFile = new FileStream(newPrivateKeyPath, FileMode.Open);
                PrivateKey = FormatPrivateKey((new StreamReader(privateKeyFile)).ReadToEnd());
                privateKeyFile.Close();
            }
            catch (IOException ex)
            {
                throw new PingppException("Private key read error. " + ex);
            }
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        private static byte[] FormatPrivateKey(string privateKeyContent)
        {
            privateKeyContent = privateKeyContent.Replace("\r", "").Replace("\n", "");
            if (privateKeyContent.StartsWith("-----BEGIN RSA PRIVATE KEY-----"))
            {
                privateKeyContent = privateKeyContent.Substring(31);
            }
            if (privateKeyContent.EndsWith("-----END RSA PRIVATE KEY-----"))
            {
                privateKeyContent = privateKeyContent.Substring(0, privateKeyContent.Length - 29);
            }
            var privateKeyData = Convert.FromBase64String(privateKeyContent);
            if (privateKeyData.Length < 162)
            {
                throw new PingppException("Private key content is incorrect.");
            }

            return privateKeyData;
        }
    }
}
