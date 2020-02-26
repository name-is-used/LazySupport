using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.Ali.Trade
{
    /// <summary>
    /// app支付参数
    /// </summary>
    public class AppPaymentParameter
    {
        /// <summary>
        /// 名称,显示在支付页面上,一般是项目名
        /// 非必填(建议填上)
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 说明,显示在支付页面上,一般是订单号
        /// 非必填(建议填上)
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 交易号
        /// 必填
        /// 退款,查询订单都要用到
        /// </summary>
        public string TradeNo { get; set; }

        /// <summary>
        /// 付款金额(分)
        /// 必填
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 通知地址
        /// 必填
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>
        /// 这个参数会回传
        /// 非必填
        /// </summary>
        public string PassbackParams { get; set; }
    }
}
