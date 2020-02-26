using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.Ali.Trade
{
    /// <summary>
    /// h5支付
    /// </summary>
    public class H5Payment
    {
        /// <summary>
        ///  应用ID,您的APPID(必填)
        /// </summary>
        public string AppId { get;}
        /// <summary>
        ///  商户私钥，您的原始格式RSA私钥(必填)
        /// </summary>
        public string PrivateKey { get;}
        /// <summary>
        /// 公钥
        /// </summary>
        public string PublicKey { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="privateKey"></param>
        /// <param name="publicKey"></param>
        public H5Payment(string appId, string privateKey, string publicKey)
        {
            this.AppId = appId;
            this.PrivateKey = privateKey;
            this.PublicKey = publicKey;
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public string Pay(H5PaymentParameter parameter)
        {
            DefaultAopClient client = new DefaultAopClient("https://openapi.alipay.com/gateway.do",
               AppId,
               PrivateKey,
               "json",
               "1.0",
               "RSA2",
               PublicKey,
               "utf-8",
               false);

            // 组装业务参数model
            AlipayTradeWapPayModel model = new AlipayTradeWapPayModel
            {
                Body = parameter.Body,
                Subject = parameter.Subject,
                TotalAmount = parameter.Amount.ToString(),
                OutTradeNo = parameter.TradeNo,
                ProductCode = "QUICK_WAP_WAY",
                QuitUrl = parameter.QuitUrl,
                PassbackParams = parameter.PassbackParams
            };

            // 请求
            AlipayTradeWapPayRequest request = new AlipayTradeWapPayRequest();
            // 设置支付完成同步回调地址
            request.SetReturnUrl(parameter.QuitUrl);
            // 设置支付完成异步通知接收地址
            request.SetNotifyUrl(parameter.NotifyUrl);
            // 将业务model载入到request
            request.SetBizModel(model);

            // 响应
            AlipayTradeWapPayResponse response = client.pageExecute(request, null, "post");
            return response.Body;
        }

    }
}
