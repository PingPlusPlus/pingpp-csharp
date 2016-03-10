using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pingpp.Models;
using System.IO;

namespace Example.Example
{
    public class WebhooksDemo
    {
        public static Event Example()
        {
            var data = ReadFileToString(@"data.txt");
            var evt = Webhooks.ParseWebhook(data);
            Console.WriteLine(evt);

            return evt;
        }

        public static string ReadFileToString(string path)
        {
            using (var sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }

    }
}
