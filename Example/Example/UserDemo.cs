using System;
using System.Collections.Generic;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    internal class UserDemo
    {
        /// <summary>
        /// 本示例介绍如何创建用户（User 对象）、更新 User 对象、禁用/启用 User 对象、查询指定 User 对象和 User 列表
        /// </summary>
        public static User Example(string appId)
        {
            var uParams = new Dictionary<string, object>
            {
                {"id", "test_user_001"}, // 如果 ID 已使用，可以换成别的 ID，注意测试模式下最大用户数量限制
                {"email", "test_user@test.com"},
                {"gender", "MALE"},
                {"name", "Test Name"},
            };

            var user = User.Create(appId, uParams);
            Console.WriteLine("****发起交易请求创建 User 对象****");
            Console.WriteLine(user);
            Console.WriteLine();

            Console.WriteLine("****查询指定 User 对象****");
            Console.WriteLine(User.Retrieve(appId, user.Id));
            Console.WriteLine();

            Console.WriteLine("****更新指定 User 对象****");
            Console.WriteLine(User.Update(appId, user.Id, new Dictionary<string, object> { { "email", "test_user_001@test.com" } }));
            Console.WriteLine();

            Console.WriteLine("****禁用指定 User 对象****");
            Console.WriteLine(User.Disable(appId, user.Id));
            Console.WriteLine();

            Console.WriteLine("****启用指定 User 对象****");
            Console.WriteLine(User.Enable(appId, user.Id));
            Console.WriteLine();

            Console.WriteLine("****查询 User 列表****");
            Console.WriteLine(User.List(appId));
            Console.WriteLine();

            return null;
        }
    }
}
