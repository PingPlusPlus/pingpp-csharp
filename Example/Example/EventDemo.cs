using System;
using System.Collections.Generic;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    public class EventDemo
    {
        public static Event Example()
        {
            //查询指定的 event
            var evt = Event.Retrieve("evt_sATiFAMSU7Loda9uCWKUxmgo");
            Console.WriteLine("****查询指定 Event 对象****");
            Console.WriteLine(evt);
            Console.WriteLine();

            //查询 event 列表
            var eventParam = new Dictionary<string, object> {{"limit", 3}};
            Console.WriteLine("****查询 Event 对象列表****");
            Console.WriteLine(Event.List(eventParam));
            Console.WriteLine();

            return evt;
        }
    }
}
