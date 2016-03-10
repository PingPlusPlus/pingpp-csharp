using System;
using System.Web.UI;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

namespace Demo
{
    public partial class Webhooks : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.RequestType.ToUpper().Equals("POST"))
            {
                //获取 post 的 event对象 
                var inputData = ReadStream(Request.InputStream);

                //获取 header 中的签名
                var sig = Request.Headers.Get("x-pingplusplus-signature");

                //string sig = "BX5sToHUzPSJvAfXqhtJicsuPjt3yvq804PguzLnMruCSvZ4C7xYS4trdg1blJPh26eeK/P2QfCCHpWKedsRS3bPKkjAvugnMKs+3Zs1k+PshAiZsET4sWPGNnf1E89Kh7/2XMa1mgbXtHt7zPNC4kamTqUL/QmEVI8LJNq7C9P3LR03kK2szJDhPzkWPgRyY2YpD2eq1aCJm0bkX9mBWTZdSYFhKt3vuM1Qjp5PWXk0tN5h9dNFqpisihK7XboB81poER2SmnZ8PIslzWu2iULM7VWxmEDA70JKBJFweqLCFBHRszA8Nt3AXF0z5qe61oH1oSUmtPwNhdQQ2G5X3g==";

                //公钥路径（请检查你的公钥 .pem 文件存放路径）
                var path = @"D:\workspace\csharpProject\demo\WebApplication1\WebApplication1\key.pem";

                //验证签名
                VerifySignedHash(inputData, sig, path);

                var jObject = JObject.Parse(inputData);
                var type = jObject.SelectToken("type");
                if (type.ToString() == "charge.succeeded" || type.ToString() == "refund.succeeded")
                {
                    // TODO what you need do
                    Response.StatusCode = 200;
                }
                else
                {
                    // TODO what you need do
                    Response.StatusCode = 500;
                }

            }

        }

        private static string ReadStream(Stream stream)
        {
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }


        public static string ReadFileToString(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }

        public static string VerifySignedHash(string strDataToVerify, string strSignedData, string strPublicKeyFilePath)
        {
            byte[] signedData = Convert.FromBase64String(strSignedData);

            UTF8Encoding ByteConverter = new UTF8Encoding();
            byte[] dataToVerify = ByteConverter.GetBytes(strDataToVerify);
            try
            {
                string sPublicKeyPem = File.ReadAllText(strPublicKeyFilePath);
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider {PersistKeyInCsp = false};

                rsa.LoadPublicKeyPEM(sPublicKeyPem);

                if (rsa.VerifyData(dataToVerify, "SHA256", signedData))
                {
                    return "verify success";
                }
                else
                {
                    return "verify fail";
                }

            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return "verify error";
            }

        }
    }
}