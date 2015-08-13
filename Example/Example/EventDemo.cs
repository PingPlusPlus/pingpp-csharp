//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using pingpp;
//using pingpp.Models;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//namespace Example
//{
//    class EventDemo
//    {
//        static void Main(string[] args)
//        {
//            //设置 apikey
//            Pingpp.apiKey = "sk_test_ibbTe5jLGCi5rzfH4OqPW9KC";

//            //查询指定的 event
//            Event events = Event.retrieve("evt_sATiFAMSU7Loda9uCWKUxmgo");
//            Console.WriteLine("****查询指定 Event 对象****");
//            Console.WriteLine(events);
//            Console.WriteLine();

//            //查询 event 列表
//            Dictionary<string, object> eventParam = new Dictionary<string, object>();
//            eventParam.Add("limit", 3);
//            EventList eveList = Event.list(eventParam);
//            Console.WriteLine("****查询 Event 对象列表****");
//            Console.WriteLine(eveList); 
//            Console.ReadKey();
//        }
//    }
//}
