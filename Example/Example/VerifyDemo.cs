//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Security.Cryptography;
//using System.Text;



//namespace Example
//{
//    class VerifyDemo
//    {
//        /// <summary>
//        /// 本示例介绍如何验证 webhooks 签名。
//        /// 需要注意的是 requestBody 必须是接收到的原始数据；
//        /// 签名在 header 里的 x-pingplusplus-signature 字段里；
//        /// 公钥在管理平台里面，需要登陆去获取。
//        /// </summary>

//        static void Main(string[] args)
//        {
//            string sig = "BX5sToHUzPSJvAfXqhtJicsuPjt3yvq804PguzLnMruCSvZ4C7xYS4trdg1blJPh26eeK/P2QfCCHpWKedsRS3bPKkjAvugnMKs+3Zs1k+PshAiZsET4sWPGNnf1E89Kh7/2XMa1mgbXtHt7zPNC4kamTqUL/QmEVI8LJNq7C9P3LR03kK2szJDhPzkWPgRyY2YpD2eq1aCJm0bkX9mBWTZdSYFhKt3vuM1Qjp5PWXk0tN5h9dNFqpisihK7XboB81poER2SmnZ8PIslzWu2iULM7VWxmEDA70JKBJFweqLCFBHRszA8Nt3AXF0z5qe61oH1oSUmtPwNhdQQ2G5X3g==";
//            string dataPath = @"../../Example/data.txt";
//            string data = ReadFileToString(dataPath);
//            string path = @"../../Example/key.pem";

//            Console.WriteLine(VerifySignedHash(data, sig, path));
//            Console.ReadKey();

//        }

//        public static string ReadFileToString(string path)
//        {
//            using (StreamReader sr = new StreamReader(path))
//            {
//                return sr.ReadToEnd();
//            }
//        }

//        public static string VerifySignedHash(string str_DataToVerify, string str_SignedData, string str_publicKeyFilePath)
//        {
//            byte[] SignedData = Convert.FromBase64String(str_SignedData);

//            ASCIIEncoding ByteConverter = new ASCIIEncoding();
//            byte[] DataToVerify = ByteConverter.GetBytes(str_DataToVerify);
//            try
//            {
//                string sPublicKeyPEM = File.ReadAllText(str_publicKeyFilePath);
//                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

//                rsa.PersistKeyInCsp = false;
//                rsa.LoadPublicKeyPEM(sPublicKeyPEM);

//                if (rsa.VerifyData(DataToVerify, "SHA256", SignedData))
//                {
//                    return "verify success";
//                }
//                else
//                {
//                    return "verify fail";
//                }

//            }
//            catch (CryptographicException e)
//            {
//                Console.WriteLine(e.Message);

//                return "verify error";
//            }
//        }

//    }
//}
