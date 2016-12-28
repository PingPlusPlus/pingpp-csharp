# Ping++ CSharp SDK

## 简介
## 版本要求
至少要求 .NET 3.5 以上，建议 .NET 4.0 以上。

## 注意
- namespace 由 pingpp 改为 Pingpp
- 所有方法名更改，首字母大写

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
ChargeList chs = Charge.List(,String appId,Dictionary<String, Object> listParam);
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
#### 更新Transter 对象
```C#
Transfer.Cancel(string Id);
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

#### 取消批量付款
```c#
BatchTransfer.Cancel(String btId)
```

### Event
#### 查询指定 Event 对象
```c#
Event evt = Event.Retrieve(String id);
```

详细信息请参考 [API 文档](https://pingxx.com/document/api)
