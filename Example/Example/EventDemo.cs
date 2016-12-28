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
            
            return evt;
        }
    }
}
