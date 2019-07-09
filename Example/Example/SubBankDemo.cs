using System;
using Pingpp;
using Pingpp.Models;
using System.Collections.Generic;

namespace Example.Example
{
    internal class SubBankDemo
    {
        public static void Example(string appId)
        {
            var listParams = new Dictionary<string, object> {
                {"app", appId},
                {"channel", "chanpay"},
                {"open_bank_code", "0308"},
                {"prov", "浙江省"},
                {"city","宁波市"}
            };

            Console.WriteLine("**** 银行支行列表查询 ****");
            Console.WriteLine(SubBank.List(listParams));
            Console.WriteLine();
        }
    }
}
