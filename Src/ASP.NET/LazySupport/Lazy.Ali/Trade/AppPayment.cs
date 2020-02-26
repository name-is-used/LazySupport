using Lazy.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.Ali.Trade
{
    /// <summary>
    /// app支付
    /// </summary>
    public class AppPayment
    {
        /// <summary>
        ///  应用ID,您的APPID(必填)
        /// </summary>
        public string AppId { get; }
        /// <summary>
        ///  商户私钥，您的原始格式RSA私钥(必填)
        /// </summary>
        public string PrivateKey { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="privateKey"></param>
        /// <param name="publicKey"></param>
        public AppPayment(string appId, string privateKey)
        {
            this.AppId = appId;
            this.PrivateKey = privateKey;
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="parameter">支付参数</param>
        /// <returns>返回响应值</returns>
        public string Pay(AppPaymentParameter parameter)
        {
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "body", parameter.Body },
                { "subject", parameter.Subject },
                { "out_trade_no", parameter.TradeNo },
                { "total_amount", parameter.Amount.ToString() },
                { "product_code", "QUICK_MSECURITY_PAY" }
            };
            string bizContent = JsonHelper.Serialize(body);

            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "app_id", AppId },
                { "method", "alipay.trade.app.pay" },
                { "format", "json" },
                { "charset", "utf-8" },
                { "sign_type", "RSA2" },
                { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "version", "1.0" },
                { "notify_url", parameter.NotifyUrl },
                { "biz_content", bizContent },
                { "passback_params", parameter.PassbackParams }
            };

            // 签名
            string sign = Aop.Api.Util.AlipaySignature.RSASign(param, PrivateKey, "utf-8", false, "RSA2");
            StringBuilder sb = new StringBuilder();
            foreach (var kv in param)
            {
                sb.Append(kv.Key)
                    .Append("=")
                    .Append(Uri.EscapeDataString(kv.Value))
                    .Append("&");
            }
            sb.Append("sign=");
            sb.Append(Uri.EscapeDataString(sign));
            return sb.ToString();
        }

    }
}
