# ChangeLog

### 1.4.2
- 新增
    - 支付宝/微信跨境渠道创建charge支付示例
    - 优惠券模板对象新增 user_times_circulated 字段

### 1.4.1
- 新增
    - 分润(royalty)对象返回新增royalty_settlement字段
    - 分润结算明细(royalty_transaction)对象新增failure_msg,transfer字段
    - 优惠券模板(coupon_template)对象创建请求新增max_user_circulation参数
- 修改
    - 自动重试机制
    - order对象添加charge字段

### 1.4.0
- 新增
	- 新增订单退款接口
	- 新增余额转账balance_transfers接口
	- 新增余额赠送接口 balance_bonuses
	- 新增用户余额充值接口 /v1/apps/APP_ID/recharges
	- 新增分润模板接口
- 修改
	- 子商户对象新增level,parent_app 字段,创建参数新增 parent_app 参数
	- 提现创建接口新增settle_account 参数, channel,extra 参数由必填修改为选填.
	- order退款列表order_refund变更为refund对象
	- 原order退款创建、查询列表返回的order_refund变更为refund对象.
	- order对象新增charge对象列表，actual_amount参数;
	- 订单支付接口支持传商户订单号,此时支付的商户订单号不等于订单的商户订单号;
	- 原/v1/recharge 接口废弃,请使用新用户余额充值接口
	- 原用户余额转账transfers 接口废弃请使用 balance_transfers 接口
	- 原余额提现withdrawals废弃 请使用/v1/apps/APP_ID/withdrawals 接口
	- 原余额收款接口 receipts 废弃,请使用 balance_bonus 接口
	- 原 asset_transactions transaction_statistics接口下线.

### 1.3.0
- 新增
	- 子商户应用（SubApp）及渠道参数（Channel）接口
	- 分润相关接口（Royalty，RoyaltySettlement，RoyaltyTransaction）
	- 用户新增结算账户（SettleAccount）
- 修改
	- AssetTransaction 字段删除及增加
	- Order 增加字段
	- TransactionStatistics 增加字段
	- User 增加字段

### 1.2.1（2016-12-26）
- 新增
    - withdrawal对象 添加 failure_msg,operation_url字段
    - batch_withdrawal列表 添加 time_finished字段
    - user 对象 balance 字段改成 available_balance
    - balance_transaction 对象 balance 字段改成 available_balance。
    - 新增用户收款接口
### 1.2.0
- 新增：
    - 企业付款SDK更新接口  
    - 请求认证接口接口  
    - 报关接口接口  
    - 批量退款接口  
    - 订单创建更新查询删除支付接口  
    - 用户充值接口接口  
    - 企业清算账户交易明细接口  
    - 用户接口    
    - 余额转账接口  
    - 优惠券及优惠券模板接口  
    - 企业清算账户额度统计,批量提现确认新增和查询接口

- 修改
    - 示例代码 Demo、Example 的修改  
    - 修改接口请求签名

### 1.1.0
- 新增：  
    - 添加请求签名
- 修改：  
    - namespace 由 pingpp 改为 Pingpp  
    - 方法名更改，首字母大写  
    - 一些细节以及 bug 的改进和修正  
    - 示例代码 Demo、Example 的修改
