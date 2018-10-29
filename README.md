# Ping++ CSharp SDK 

## 简介
## 版本要求
至少要求　.NET　4.6　及以上。

## 注意
- namespace 由 pingpp 改为 Pingpp
- 所有方法名更改，首字母大写
- 如果您的项目中 .NET　Framework版本低于 4.6，请切换至 1.4.5 版本

## 安装

## 接入方法
### 初始化
```c#
// 设置 API-KEY
Pingpp.Pingpp.SetApiKey("sk_test_ibbTe5jLGCi5rzfH4OqPW9KC");
```

### 设置请求签名密钥
密钥需要你自己生成，公钥请填写到 [Ping++ Dashboard](https://dashboard.pingxx.com)
```c#
Pingpp.Pingpp.SetPrivateKeyPath(@"你生成的私钥文件的路径");
```

### 设置重试
设置重试次数，`0` 表示不重试，默认为 `1`。
```c#
Pingpp.Pingpp.SetMaxNetworkRetries(1);
```

当服务端返回 `502` 时，是否根据返回内容(阿里高防返回)来判断是否重试。`true` 表示只要是 `502`，全部重试,`false` 关闭重试功能。默认为 `true`。
```c#
Pingpp.Pingpp.SetBadGateWayMatch(true);
```

### 支付
#### 发起支付请求
```c#
Charge ch = Charge.Create(Dictionary<String, Object> param);
```

#### 查询指定 charge 对象
```c#
Charge ch = Charge.Retrieve(String id);
```

#### 查询 charge 列表
```c#
ChargeList chs = Charge.List(Dictionary<String, Object> listParam);
```

#### 撤销 charge对象
```c#
Charge ch = Charge.Reverse(String chargeId);
```

### 退款
#### 发起 refund
```c#
Refund re = Refund.Create(String chId, Dictionary<String, Object> param);
```

#### 查询指定 refund
```c#
Refund re = Refund.Retrieve(String chId, String reId);
```

#### 查询 refund 列表
```c#
RefundList res = Refund.List(String chId, Dictionary<String, Object> listParam);
```

### 微信红包
#### 发送红包请求
```c#
RedEnvelope red = RedEnvelope.Create(Dictionary<String, Object> param);
```

#### 查询指定 RedEnvelope 对象
```c#
RedEnvelope red = RedEnvelope.Retrieve(String id);
```

#### 查询 RedEnvelope 列表
```c#
RedEnvelopeList reds = RedEnvelope.List(Dictionary<String, Object> listParam);
```

### 企业付款
#### 发送企业付款请求
```c#
Transfer tr = Transfer.Create(Dictionary<String, Object> param);
```

#### 查询指定 Transfer 对象
```c#
Transfer tr = Transfer.Retrieve(String id);
```

#### 查询 Transfer 列表
```c#
TransferList trs = Transfer.List(Dictionary<String, Object> listParam);
```

### 身份认证请求
#### 创建身份认证请求
```c#
Identification.Identify(new Dictionary<string, object> iParams);
```

### 报关接口
#### 请求报关接口
```c#
Customs.Create(Dictionary<string, object> cuParams);
```

#### 查询报关接口
```c#
Customs.Retrieve(string Id);
```

### 批量退款
#### 创建 Batch refund 对象
```c#
BatchRefund.Create(Dictionary<string, object> btParams);
```

#### 查询 Batch refund 列表
```c#
BatchRefund.List(Dictionary<string, object> listParams)
```

#### 查询 Batch refund 对象
```c#
BatchRefund.Retrieve(string Id)
```
### 批量付款
#### 创建批量付款
```c#
BatchTransfer.Create(Dictionary<string, object> btParams);
```

#### 获取批量付款
```c#
BatchTransfer.Retrieve(string batchTransterId)
```
#### 获取批量付款列表
```c#
BatchTransfer.List(Dictionary<string, object> btParams)
```

### Event
#### 查询指定 Event 对象
```c#
Event evt = Event.Retrieve(string id);
```

### 批量退款
#### 创建 Batch refund 对象
```c#
BatchTransfer.Create(Dictionary<string, object> btParams);
```

#### 查询 Batch refund 列表
```c#
BatchTransfer.List(Dictionary<string, object> listParams)
```

#### 查询 Batch refund 对象
```c#
BatchTransfer.Retrieve(string Id)
```

### 商品订单
#### 创建商品订单接口
```c#
Order.Create(Dictionary<string, object> orParams);
```

#### 商品订单取消接口
```c#
Order.Cancel(string Id);
```

#### 商品订单查询接口
```c#
Order.Retrieve(string Id);
```

#### 商品订单列表接口
```c#
Order.List(Dictionary<string, object> orParams});
```

#### 商品订单支付接口
```c#
Order.Pay(or.Id, Dictionary<string, object> payParams);
```
#### 商品订单charge列表接口
```c#
Order.ChargeList(or.Id);
```

#### 商品订单charge查询接口
```c#
Order.ChargeRetrieve(or.Id, string chargeId);
```

#### 商品订单退款接口
```c#
OrderRefund.Create(string orderId, Dictionary<string, object> reParams);
```

#### 商品订单退款查询接口
```c#
OrderRefund.Retrieve(string orderId, string refundId)
```

#### 商品订单退款列表查询接口
```c#
OrderRefund.List(string orderId)
```

### 余额充值
##### 用户余额充值创建
```c#
Recharge.Create(appId, Dictionary<string, object> createParams);
```

#### 用户余额充值查询
```c#
Recharge.Retrieve(appId, string Id)
```

#### 用户余额充值列表
```c#
Recharge.List(appId)
```
#### 用户余额充值退款
```c#
RechargeRefund.Create(appId, string Id, Dictionary<string, object> refundParams)
```

#### 用户余额充值退款查询
```c#
RechargeRefund.Create(appId, string Id, string refundId)
```

#### 用户余额充值退款列表
```c#
RechargeRefund.List(appId, string Id));
```

### 用户
##### 创建用户对象
```c#
User.Create(string appId, Dictionary<string, object> uParams);
```
#### 查询用户对象列表
```c#
User.List(string appId);
```

#### 查询用户 user 对象
```c#
User.Retrieve(string appId, string userId);
```
#### 更新用户 user 对象
```c#
User.Update(string appId, string userId, Dictionary<string, object>);
```
#### 启用用户对象
```c#
User.Enable(string appId, string userId);
```
#### 禁用用户对象
```c#
User.Disable(string appId, string userId)
```

#### 查询用户账户交易明细列表
```c#
BalanceTransaction.List(string  appId, string userId, Dictionary<string, object>  listParams);
```
#### 用户账户交易明细
```c#
BalanceTransaction.Retrieve(string appId, string uid, string txnId);
```

#### 余额提现申请
```c#
Withdrawal.Request(string appId, string uid, Dictionary<string, object> wdParams);

```
#### 余额提现列表查询
```c#
Withdrawal.List(string appId, string uid, Dictionary<string, object> wdParams);
```
#### 余额提现对象查询
```c#
Withdrawal.Retrieve(string appId, string uid, string wrId);
```
#### 余额提现取消
```c#
Withdrawal.Cancel(string appId, string  uid, string  withDramalsId)
```
#### 余额提现确认
```c#
Withdrawal.Confirm(string  appId, string  uid, string withDramalsId)
```

### 优惠券
#### 创建单个优惠券
```c#
Coupon.Create(string appId, string uid, Dictionary<string, object> couponParams);
```

#### 查询优惠券对象
```c#
Coupon.Retrieve(string  appId, string uid, string couId)
```

#### 更新优惠券
```c#
Coupon.Update(string appId, string uid, string couId, Dictionary<string, object> { { "metadata", Dictionary<string, string> couponParams)
```

#### 删除优惠券
```c#
Coupon.Delete(string appId, string uid, string couId)
```

### 优惠券模板
#### 创建优惠券模板
```c#
CouponTemplate.Create(string  appId, Dictionary<string, object>  couTmplParams);
```
#### 获取优惠券模板列表
```c#
CouponTemplate.List(string appId)
```

#### 获取优惠券模板明细
```c#
CouponTemplate.Retrieve(string appId, string couTmplId)
```

#### 更新优惠券模板信息
```c#
CouponTemplate.Update(string appId, string couTmplId,Dictionary<string, object> ctplParams)
```

#### 删除优惠券模板
```c#
CouponTemplate.Delete(string appId, string couTmplId)
```
#### 批量创建优惠券
```c#
Coupon.BatchCreate(string appId, string couTmplId, Dictionary<string, object> couponParams)
```
#### 查询优惠券模板下的优惠券列表
```c#
Coupon.ListInTemplate(string appId, string couId)
```

### 批量付款
#### 创建批量付款
```c#
BatchTransfer.Create(Dictionary<string, object> btParams);
```

#### 获取批量付款
```c#
BatchTransfer.Retrieve(string batchTransterId)
```

### 批量提现确认
#### 创建批量提现确认
```c#
BatchWithdrawal.Create(string appId, Dictionary<string, object>  batchwrParams);
```

#### 查询批量提现确认对象
```c#
BatchWithdrawal.Create(string appId, string batchWithdrawalId);
```

### 子商户
#### 子商户创建
```c#
var param = new Dictionary<string, object> {
    {"display_name", "sub_app_display_name"},
    {"user", "user_006"},
    {"metadata", new Dictionary<string,object>{
        {"key", "value"}
    }},
    {"description", "Your description"},
};
SubApp.Create(appId, param)

```
#### 子商户查询

```c#
SubApp.Retrieve(appId, "app_L0GyTKKqfnnPynD4")
```

#### 子商户更新
```c#
var upParam = new Dictionary<string, object> {
    {"display_name", "sub_app_display_name2"},
    {"metadata", new Dictionary<string,object>{
        {"key", "value2"}
    }},
    {"description", "Your description2"},
};
SubApp.Update(appId, "app_L0GyTKKqfnnPynD4", upParam)
```
#### 删除子商户
```c#
SubApp.Delete(appId, "app_L0GyTKKqfnnPynD4")
````

#### 查询子商户列表
```c#
SubApp.List(appId)
```

### 子商户渠道
#### 配置子商户渠道参数
```c#
var param = new Dictionary<string, object> {
    {"channel", "bfb"},
    {"banned", false},
    {"banned_msg", null},
    {"description", "The description for bfb"},
    {"params", new Dictionary<string,object>{
        {"bfb_sp", "bfb sp"},
        {"fee_rate", 30},
        {"bfb_key", "Your key"}
    }}

};
SubAppChannel.Create(appId, subAppId, param)
```

#### 更新子商户渠道参数
```c#
var upParam = new Dictionary<string, object> {
    {"banned", false},
    {"banned_msg", null},
    {"description", "The new description for bfb"},
    {"params", new Dictionary<string,object>{
        {"bfb_sp", "1500300006"},
        {"fee_rate", 35},
        {"bfb_key", "w837cG3xQk2KMQ3EZVdByEryJpTN7MzC"}
    }}

};
SubAppChannel.Update(appId, subAppId, "bfb", upParam)
```

#### 删除子商户渠道参数
```c#
SubAppChannel.Delete(appId, subAppId, "bfb")
```

#### 查询子商户渠道参数
```c#
SubAppChannel.Retrieve(appId, subAppId, "bfb")
```

### 结算账户
#### 创建结算账户
```c#
var paramUnionPay = new Dictionary<string, object> {
    {"channel","unionpay"},
    {"recipient", new Dictionary<string,object>{
        {"account", "6214666666666666"},
        {"name", "张三"},
        {"type", "b2c"},    //转账类型。b2c：企业向个人付款，b2b：企业向企业付款。
        {"open_bank", "招商银行"},
        {"open_bank_code", "0308"}
    }}
};
SettleAccount.Create(appId, "test_user_002", paramUnionPay))
```

#### 查询结算账户
```c#
SettleAccount.Retrieve(appId, "test_user_002", "320217032111554400000901")
```

#### 删除结算账户
```c#
SettleAccount.Delete(appId, "test_user_002", "320217032111554400000901")
```

#### 查询结算账户列表
```c#
SettleAccount.List(appId, "test_user_002")
```

### 分润
#### 批量更新分润对象
```c#
var updateParam = new Dictionary<string, object> {
    {"ids", new List<string>{
        "170301124238000111",
        "170301124238000211"
    }},
    {"method", "manual"},
    {"description", "Your description"}
};
Royaltie.Update(updateParam)
```

#### 查询分润对象
```c#
Royaltie.Retrieve("421170321093600003")
```

#### 查询分润对象列表
```c#
var listParams = new Dictionary<string, object>{
    {"payer_app", "app_LibTW1n1SOq9Pin1"},
    {"source_app","app_LibTW1n1SOq9Pin1"},
    {"page", 1},
    {"per_page", 1}
};
Royaltie.List(listParams)
```

### 分润结算
#### 创建分润结算对象
```c#
var createParam = new Dictionary<string, object> {
    {"payer_app", "app_LibTW1n1SOq9Pin1"},
    {"method", "alipay"},
    {"recipient_app", "app_1Gqj58ynP0mHeX1q"},
    {"created", new Dictionary<string,object>{
        {"gt"   , 1488211200},
        {"lte"  , 1488297600}
    }}
};
RoyaltySettlement.Create(createParam)
```

#### 查询分润结算对象
```c#
RoyaltySettlement.Retrieve("431170321101800001")
```

#### 更新分润结算对象
```c#
var updateParam = new Dictionary<string, object> {
    {"status", "canceled"}
};
Console.("**** 更新royalty_settlement 对象 ****");
RoyaltySettlement.Update("431170321101800001", updateParam)
```

#### 查询分润结算对象列表
```c#
var listParam = new Dictionary<string, object> {
    {"payer_app", "app_LibTW1n1SOq9Pin1"}
};
RoyaltySettlement.List(listParam)
```

### 分润结算明细
#### 查询分润结算明细
```c#
RoyaltyTransaction.Retrieve("441170321101800003")
```

#### 查询分润结算明细列表
```c#
var listParam = new Dictionary<string, object> {
    {"page", 1},
    {"per_page", 10}
};
RoyaltyTransaction.List(listParam)
```
### 分润模板
#### 分润模板创建
```c#
RoyaltyTemplate.Create(Dictionary<string, object> createParam)
```

#### 分润模板查询
```c#
RoyaltyTemplate.Retrieve(string Id)
```

#### 分润模板更新
```c#
RoyaltyTemplate.Update("451170814105500001", Dictionary<string, object> updateParam)
```

#### 分润模板删除
```c#
RoyaltyTemplate.Delete(string Id);
```

#### 分润模板列表
```c#
RoyaltyTemplate.List();
```

### 用户余额转账
#### 用户余额转账创建
```c#
BalanceTransfer.Create(appId, Dictionary<string, object> createParams);
```

#### 用户余额转账查询
```c#
BalanceTransfer.Retrieve(appId, string balanceTransferId);
```

#### 用户余额转账列表
```c#
BalanceTransfer.List(appId);
```

### 用户余额赠送
#### 用户余额赠送创建
```c#
BalanceBonus.Create(appId, Dictionary<string, object> createParams));
```

#### 用户余额赠送查询
```c#
BalanceBonus.Retrieve(appId, string balanceBonusId)
```

#### 用户余额赠送列表
```c#
BalanceBonus.List(appId);
```

#### 用户余额结算列表
```c#
BalanceSettlement.List(appId)
```

#### 用户余额结算查询
```c#
BalanceSettlement.Retrieve(appId, string balaneSettlementId)
```

### card_bin查询
```c#
CardInfo.Query(List<string> params)
```

详细信息请参考 [API 文档](https://pingxx.com/document/api)

### 创建签约
```c#
Agreement.Create( Dictionary<string, object> createParams)
```

### 查询签约状态
```c#
Agreement.Retrieve(string Id)
```

### 解除签约
```c#
Agreement.Cancel(string Id)
```

### 查询签约列表
```c#
Agreement.List( Dictionary<string, object> listParams)
```

### 微信公众号获取openid
```c#
WxPubUtils.GetOpenId(string appId, string appSecret, string code)
```

### 微信小程序获取openid
```c#
WxPubUtils.GetWxLiteOpenId(string appId, string appSecret, string code)
```
