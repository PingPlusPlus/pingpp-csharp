using System;
using System.Collections.Generic;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    internal class ProfitTransactionDemo
    {
        public static void Example(string appId)
        {
            Console.WriteLine("****查询 profit_transaction 列表****");
            Dictionary<string,object> listParams = new Dictionary<string, object> { 
                {"app", appId},
                {"page", 1}
            };
            Console.WriteLine(ProfitTransaction.List(listParams));
            Console.WriteLine();

            Console.WriteLine("****查询 profit_transaction ****");
            Console.WriteLine(ProfitTransaction.Retrieve("ptxn_1m3xtoBMRqu2qC"));
            Console.WriteLine();
        }
    }
}
