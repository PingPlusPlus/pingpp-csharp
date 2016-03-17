using System;
using System.Collections.Generic;
using Pingpp.Models;

namespace Example.InAppExample
{
    public class CardDemo
    {
        /// <summary>
        /// 本示例只介绍如何新建 Card，以及如何查询指定 Card 对象和 Card 列表，
        /// 至于如何将 Card 对象传递给客户端需要接入者自行处理
        /// </summary>
        public static Card Example(string cusId)
        {
            var cardParams = new Dictionary<string, object> {
                {"source", "tok_xxxxxxxxxxxx"},
                {"sms_id", "sms_xxxxxxxxxx"},
                {"sms_code", "123456"}
            };

            var card = Card.Create(cusId, cardParams);
            Console.WriteLine("****创建 Card 对象****");
            Console.WriteLine(card);
            Console.WriteLine();

            Console.WriteLine("****查询指定 Card 对象****");
            Console.WriteLine(Card.Retrieve(cusId, card.Id));
            Console.WriteLine();

            Console.WriteLine("****查询 Card 列表****");
            Console.WriteLine(Card.List(cusId,  new Dictionary<string, object> {{"limit", 3}}));
            Console.WriteLine();

            // Console.WriteLine("****删除 Card 对象****");
            // Console.WriteLine(Card.Delete(cusId, card.Id));
            // Console.WriteLine();

            return card;
        }
    }
}
