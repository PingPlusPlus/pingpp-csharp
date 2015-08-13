# Ping++ CSharp SDK API 文档

## 概述

本文档简要概述 Ping++ CSharp SDK 部分常用类的使用方法，详细使用方法开发者可阅读源码以及示例程序。
 

## 设置 apiKey
```c#
Pingpp.apiKey = "sk_test_ibbTe5jLGCi5rzfH4OqPW9KC";
```
 
## Charge.cs

### 创建 Charge
    
**create(Dictionary<String, Object> param)**
  
    方法名：create
    类型：静态方法
    参数：Dictionary  
    返回：Charge
    
    示例：	
        Dictionary<String, Object> app = new Dictionary<String, Object>();
        app.Add("id", app_1Gqj58ynP0mHeX1q);
		Dictionary<String,Object> extra = new Dictionary<String,Object>();	
        Dictionary<String, Object> params = new Dictionary<String, Object>();
        params.Add("amount", 100);
        params.Add("currency", "cny");
        params.Add("subject", "Your Subject");
        params.Add("body", "Your Body");
        params.Add("order_no", "123456789");
        params.Add("channel", "upacp");
        params.Add("client_ip", "127.0.0.1");
        params.Add("app", app);     
        params.Add("extra", extra);
        try {
            //发起交易请求
            Charge ch = Charge.create(params);
            Console.WriteLine(ch);
        } catch (Exception e) {
            Console.WriteLine(e.Message.ToString());
        }
        
### 查询 Charge
#### 查询指定 Charge
**retrieve(String id)**
  
    方法名：retrieve
    类型：静态方法
    参数：String 类型的 Charge ID
    返回：Charge
    
    示例：
        try {
            Charge ch = Charge.retrieve(id);              
            Console.WriteLine(ch);
        } catch (Exception e) {
            Console.WriteLine(e.Message.ToString());
        }       

#### 查询 Charge 列表

**list(Dictionary<String, Object> params)**

    方法名：list
    类型：静态方法
    参数：Dictionary 
    返回：ChargeList
    
    示例：
        Dictionary<String, Object> chargeParams = new Dictionary<String, Object>();
        chargeParams.Add("limit", 3);
        try {
            ChargeList chs = Charge.list(chargeParams); 
            Console.WriteLine(chs);
        } catch (AuthenticationException e) {
            Console.WriteLine(e.Message.ToString());
        } 


## Refund.cs

### 创建 Refund
**create(String chId, Dictionary<String, Object> params)**
    
    方法名：create
    类型：静态方法
    参数：String ChargeId, Dictionary
    返回：Refund
    
    示例：
        Dictionary<String, Object> params = new Dictionary<String, Object>();
		params.Add("amount", 100);
        params.Add("description", "Your Description");
        try {
            Refund re = Refund.create(chId, reId);
			Console.WriteLine(re);
        } catch (Exception e) {
            Console.WriteLine(e.Message.ToString());
        }
 
 
### 查询 Refund
#### 查询指定的退款
**retrieve(String chId, String reId)**
    
    方法名：create
    类型：静态方法
    参数：String 类型的 Charge Id, Refund ID
    返回：Refund
    
    示例：
        try {
            Refund re = Refund.create(chId, reId);
            Console.WriteLine(re);
        } catch (AuthenticationException e) {
            Console.WriteLine(e.Message.ToString());
        } 

#### 查询退款列表      
**list(String chId, Dictionary<String, Object> params)**
    
    方法名：list
    类型：静态方法
    参数：Dictionary
    返回：RefundList
    
    示例：
        Dictionary<String, Object> refundParams = new Dictionary<String, Object>();
        refundParams.Add("limit", 3);
        try {
            RefundList res = Refund.list(chId, refundParams);
            Console.WriteLine(res);
        } catch (AuthenticationException e) {
            Console.WriteLine(e.Message.ToString());
        } 


##RedEnvelope.cs

### 创建 RedEnvelope
**create(Dictionary<String, Object> params)**
    
    方法名：create
    类型：静态方法
    参数：Dictionary
    返回：RedEnvelope
    
    示例：
		Dictionary<String, String> app = new Dictionary<String, String>();
        app.Add("id", "app_1Gqj58ynP0mHeX1q");
		Dictionary<String, String> extra = new Dictionary<String, String>();
    	extra.Add("nick_name", "Nick Name");
    	extra.Add("send_name", "Send Name");
        Dictionary<String, Object> params = new Dictionary<String, Object>();
        params.Add("amount", 100);
        params.Add("currency", "cny");
        params.Add("subject",  "Your Subject");
        params.Add("body",  "Your Body");
        params.Add("order_no",  "123456789");
        params.Add("channel",  "wx_pub");
        params.Add("recipient", "Your Openid");
        params.Add("description", "Your Description");
    	params.Add("app", app);
    	params.Add("extra", extra);
        try {
            RedEnvelope red = RedEnvelope.create(params);
            Console.WriteLine(red);
        } catch (Exception e) {
            Console.WriteLine(e.Message.ToString());
        } 


### 查询 RedEnvelope
#### 查询指定 RedEnvelope
**retrieve(String id)**
    
    方法名：create
    类型：静态方法
    参数：String 类型的 RedEnvelope ID
    返回：RedEnvelope
    
    示例：
        try {
            RedEnvelope red = RedEnvelope.retrieve(id);              
            Console.WriteLine(red);
        } catch (Exception e) {
            Console.WriteLine(e.Message.ToString());
        }

#### 查询 RedEnvelope 列表
**list(Dictionary<String, Object> params)**
    
    方法名：list
    类型：静态方法
    参数：Dictionary 
    返回：RedEnvelopeList
    
    示例：
        Dictionary<String, Object> params = new Dictionary<String, Object>();
        chargeParams.Add("limit", 3);
        try {
            RedEnvelopeList reds = RedEnvelope.list(params);
            Console.WriteLine(reds);
        } catch (Exception e) {
            Console.WriteLine(e.Message.ToString());
        } 


##Transfer.cs

### 创建 Transfer
**create(Dictionary<String, Object> params)**
    
    方法名：create
    类型：静态方法
    参数：Dictionary
    返回：Transfer
    
    示例：
		Dictionary<String, String> app = new Dictionary<String, String>();
        app.Add("id", "app_1Gqj58ynP0mHeX1q");
		Dictionary<String, String> extra = new Dictionary<String, String>();
        extra.Add("user_name", "user name");
        extra.Add("force_check", false);
        Dictionary<String, Object> params = new Dictionary<String, Object>();
   		params.Add("order_no", "1234567890");
        params.Add("amount", 100);
        params.Add("channel", "wx_pub");
        params.Add("currency", "cny");
        params.Add("type", "b2c");
        params.Add("recipient", "Your OpenId");
        params.Add("description", "Your Description");
   		params.Add("app", app);
    	params.Add("extra", extra);
        try {
            Transfer tra = Transfer.create(params);
            Console.WriteLine(tra);
        } catch (Exception e) {
            Console.WriteLine(e.Message.ToString());
        } 

### 查询 Transfer
#### 查询指定 Transfer
**retrieve(String id)**
    
    方法名：create
    类型：静态方法
    参数：String 类型的 Transfer ID
    返回：Transfer
    
    示例：
        try {
            Transfer tr = Transfer.retrieve(id);              
            Console.WriteLine(tr);
        } catch (Exception e) {
            Console.WriteLine(e.Message.ToString());
        }

#### 查询 Transfer 列表
**list(Dictionary<String, Object> params)**
    
    方法名：list
    类型：静态方法
    参数：Dictionary 
    返回：TransferList
    
    示例：
        Dictionary<String, Object> params = new Dictionary<String, Object>();
        params.Add("limit", 3);
        try {
            TransferList trs = Transfer.list(params);
            Console.WriteLine(trs);
        } catch (Exception e) {
            Console.WriteLine(e.Message.ToString());
        } 


## Event.cs

### 查询 Event
#### 查询指定 Event 
**retrieve(String id)**
 
    方法名：retrieve
    类型：静态方法
    参数：String 类型的 Event ID
    返回：Event
    
    示例：
        try {
            Event evt = Event.retrieve(id);
			Console.WriteLine(evt);
        } catch (Exception e) {
            Console.WriteLine(e.Message.ToString());
        } 

#### 查询 Event 列表     
**list(Dictionary<String, Object> params)**
 
    list
    类型：静态方法
    参数：String 类型的 Event ID
    返回：EventList
    
    示例：
        Dictionary<String, Object> params = new Dictionary<String, Object>();
        params.Add("limit", 3);
        try {
            EventList evts = Event.list(params);
            Console.WriteLine(evts);
        } catch (Exception e) {
            Console.WriteLine(e.Message.ToString());
        } 


## Webhooks.cs

### 解析 Webhooks

**parseEvent(String event)**
 
    方法名：parseEvent
    类型：静态方法
    参数：json 类型的 Event 字符串
    返回：Event
    
    示例：
        try {
            Event evt = Webhooks.parseWebhook(data);
            Console.WriteLine(evt);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message.ToString());
        }


 




















