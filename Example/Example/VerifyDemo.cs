using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Example.Example
{
    public class VerifyDemo
    {
        /// <summary>
        /// 本示例介绍如何验证 webhooks 签名。
        /// 需要注意的是 requestBody 必须是接收到的原始数据；
        /// 签名在 header 里的 x-pingplusplus-signature 字段里；
        /// 公钥在管理平台里面，需要登陆去获取。
        /// </summary>

        public static bool Example()
        {
            const string sig = "BX5sToHUzPSJvAfXqhtJicsuPjt3yvq804PguzLnMruCSvZ4C7xYS4trdg1blJPh26eeK/P2QfCCHpWKedsRS3bPKkjAvugnMKs+3Zs1k+PshAiZsET4sWPGNnf1E89Kh7/2XMa1mgbXtHt7zPNC4kamTqUL/QmEVI8LJNq7C9P3LR03kK2szJDhPzkWPgRyY2YpD2eq1aCJm0bkX9mBWTZdSYFhKt3vuM1Qjp5PWXk0tN5h9dNFqpisihK7XboB81poER2SmnZ8PIslzWu2iULM7VWxmEDA70JKBJFweqLCFBHRszA8Nt3AXF0z5qe61oH1oSUmtPwNhdQQ2G5X3g==";
            const string dataPath = @"data.txt";
            const string path = @"key.pem";

            var verified = VerifySignedHash(ReadFileToString(dataPath), sig, path);
            Console.WriteLine(verified ? "Verify Succeed" : "Verify Failed");

            return verified;
        }

        public static string ReadFileToString(string path)
        {
            using (var sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }

        public static bool VerifySignedHash(string strDataToVerify, string strSignedData, string strPublicKeyFilePath)
        {
            var signedData = Convert.FromBase64String(strSignedData);

            var byteConverter = new UTF8Encoding();
            var dataToVerify = byteConverter.GetBytes(strDataToVerify);
            try
            {
                var sPublicKeyPem = File.ReadAllText(strPublicKeyFilePath);
                var rsa = new RSACryptoServiceProvider { PersistKeyInCsp = false };

                rsa.LoadPublicKeyPem(sPublicKeyPem);

                return rsa.VerifyData(dataToVerify, "SHA256", signedData);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }

    }
}
