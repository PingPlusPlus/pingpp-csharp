//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using pingpp.Models;
//using System.IO;

//namespace Example.Example
//{
//    class WebhooksDemo
//    {
//        static void Main(string[] args)
//        {
//            string dataPath = @"../../Example/data.txt";
//            string data = ReadFileToString(dataPath);
//            try
//            {
//                Event events = Webhooks.parseWebhook(data);
//                Console.WriteLine(events);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message.ToString());
//            }

//            Console.ReadKey();
//        }

//        public static string ReadFileToString(string path)
//        {
//            using (StreamReader sr = new StreamReader(path))
//            {
//                return sr.ReadToEnd();
//            }
//        }

//    }
//}
