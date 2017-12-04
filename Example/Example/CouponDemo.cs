using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Pingpp;
using Pingpp.Models;

namespace Example.Example
{
    internal class CouponDemo
    {
        /// <summary>
        /// 
        /// 本示例介绍优惠券模板创建、更新、删除；优惠券创建、批量创建、删除、查询、用户下列表查询、模板下列表查询
        /// 优惠券使用请查看 OrderDemo 示例
        /// 查看用户当前可用优惠券数量请使用查看 User 对象接口
        /// 
        /// </summary>
        public static void Example(string appId)
        {
            var couTmplParams = new Dictionary<string, object>
            {
                {"name", "20-percent-off"},
                {"type", 2}, // 1：现金券 2：折扣券
                {"percent_off", 20},
                {"amount_available", 50000}, // 满减属性：满 500 可用
                {"max_circulation", 100}, // 优惠券最大生成数量
                {"expiration", new Dictionary<string, object>
                {
                    {"duration", 604800}    
                }
                }
            };

            var couTmpl = CouponTemplate.Create(appId, couTmplParams);
            Console.WriteLine("****创建 Coupon Template 对象****");
            Console.WriteLine(couTmpl);
            Console.WriteLine();

            Console.WriteLine("****查询 Coupon Template 对象****");
            Console.WriteLine(CouponTemplate.Retrieve(appId, couTmpl.Id));
            Console.WriteLine();
            
            Console.WriteLine("****查询 Coupon Template 对象列表****");
            Console.WriteLine(CouponTemplate.List(appId));
            Console.WriteLine();

            Console.WriteLine("****查询 Coupon Template 对象的优惠券列表****");
            Console.WriteLine(CouponTemplate.List(appId));
            Console.WriteLine();

            Console.WriteLine("****更新 Coupon Template 对象****");
            Console.WriteLine(CouponTemplate.Update(appId, couTmpl.Id, new Dictionary<string, object>{{"metadata", new Dictionary<string, string> {{"品类", "数码家电类"}}}}));
            Console.WriteLine();

            Console.WriteLine("****删除 Coupon Template 对象****");
            Console.WriteLine(CouponTemplate.Delete(appId, couTmpl.Id));
            Console.WriteLine();

            var uid = "test_user_001";
            var uid2 = "test_user_002";
            var uid3 = "test_user_003";
            var cou = Coupon.Create(appId, uid, new Dictionary<string, object>{{"coupon_template", couTmpl.Id}});
            Console.WriteLine("****创建 Coupon Template 对象****");
            Console.WriteLine(cou);
            Console.WriteLine();

            Console.WriteLine("****批量创建 Coupon 对象****");
            Console.WriteLine(Coupon.BatchCreate(appId, couTmpl.Id, new Dictionary<string, object> { { "users", new ArrayList() { uid2, uid3 } } }));
            Console.WriteLine();

            Console.WriteLine("****更新 Coupon 对象****");
            Console.WriteLine(Coupon.Update(appId, uid, cou.Id, new Dictionary<string, object> { { "metadata", new Dictionary<string, string> { { "xxx", "xxx" } } } }));
            Console.WriteLine();

            Console.WriteLine("****查询 Coupon 对象****");
            Console.WriteLine(Coupon.Retrieve(appId, uid, cou.Id));
            Console.WriteLine();

            Console.WriteLine("****查询用户的 Coupon 对象列表****");
            Console.WriteLine(Coupon.List(appId, uid));
            Console.WriteLine();

            Console.WriteLine("****查询模板下的 Coupon 对象列表****");
            Console.WriteLine(Coupon.ListInTemplate(appId, cou.Id));
            Console.WriteLine();

            Console.WriteLine("****删除 Coupon 对象****");
            Console.WriteLine(Coupon.Delete(appId, uid, cou.Id));
            Console.WriteLine();
        }
    }
}
