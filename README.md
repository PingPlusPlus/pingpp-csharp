# Ping++ CSharp SDK 

## 简介
## 版本要求
至少要求 .NET 3.5 以上，建议 .NET 4.0 以上。

## 安装

## 接入方法
### 初始化
```c#
// 设置 API-KEY
Pingpp.apiKey = "sk_test_ibbTe5jLGCi5rzfH4OqPW9KC";
```

### 支付
#### 发起支付请求
```c#
Charge ch = Charge.create(Dictionary<String, Object> param);
```

#### 查询指定 charge 对象
```c#
Charge ch = Charge.retrieve(String id);
```

#### 查询 charge 列表
```c#
ChargeList chs = Charge.list(Dictionary<String, Object> listParam);
```

### 退款
#### 发起 refund
```c#
Refund re = Refund.create(String chId, Dictionary<String, Object> param);
```

#### 查询指定 refund
```c#
Refund re = Refund.retrieve(String chId, String reId);
```

#### 查询 refund 列表
```c#
RefundList res = Refund.list(String chId, Dictionary<String, Object> listParam);
```

### 微信红包
#### 发送红包请求
```c#
RedEnvelope red = RedEnvelope.create(Dictionary<String, Object> param);
```

#### 查询指定 RedEnvelope 对象
```c#
RedEnvelope red = RedEnvelope.retrieve(String id);
```

#### 查询 RedEnvelope 列表
```c#
RedEnvelopeList reds = RedEnvelope.list(Dictionary<String, Object> listParam);
```


### 企业付款
#### 发送企业付款请求
```c#
Transfer tr = Transfer.create(Dictionary<String, Object> param);
```

#### 查询指定 Transfer 对象
```c#
Transfer tr = Transfer.retrieve(String id);
```

#### 查询 Transfer 列表
```c#
TransferList trs = Transfer.list(Dictionary<String, Object> listParam);
```

### Event
#### 查询指定 Event 对象
```c#
Event evt = Event.retrieve(String id);
```

#### 查询 Event 列表
```c#
EventList evts = Event.list(Dictionary<String, Object> listParam);
```

详细信息请参考 [API 文档](https://pingxx.com/document/api)