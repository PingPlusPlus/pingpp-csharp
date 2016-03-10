using System;
using System.Collections.Generic;
using Pingpp.Models;

namespace Example.InAppExample
{
    public class CardInfoDemo
    {
        /// <summary>
        /// 本示例只介绍如何新建 Card，以及如何查询指定 Card 对象和 Card 列表，
        /// 至于如何将 Card 对象传递给客户端需要接入者自行处理
        /// </summary>
        public static CardInfo Example(string appId)
        {
            var cardInfo = CardInfo.Retrieve("6222022003008481261", appId);
            Console.WriteLine("****查询指定 Card Info 对象****");
            Console.WriteLine(cardInfo);
            Console.WriteLine();

            return cardInfo;
        }
    }
}
