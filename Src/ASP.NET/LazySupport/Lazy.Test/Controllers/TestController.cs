using Lazy.Ali.BankCard;
using Lazy.WeChat;
using Lazy.WeChat.MiniProgram;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lazy.Test.Controllers
{
    public class TestController : ApiController
    {
        /// <summary>
        /// 支付宝h5支付
        /// </summary>
        /// <returns></returns>
        public string AliH5Pay()
        {
            Lazy.Ali.Trade.H5Payment payment = new Ali.Trade.H5Payment("2019072265978183", "", "");
            string payResult = payment.Pay(new Ali.Trade.H5PaymentParameter()
            {
                Amount = 0,
                Body = "",
                NotifyUrl = "",
                PassbackParams = "",
                QuitUrl = "",
                Subject = "",
                TradeNo = ""
            });
            return payResult;
        }


        /// <summary>
        /// 支付宝app支付
        /// </summary>
        /// <returns></returns>
        public string AliAppPay()
        {
            Lazy.Ali.Trade.AppPayment payment = new Ali.Trade.AppPayment("2019072265978183", "");
            string payResult = payment.Pay(new Ali.Trade.AppPaymentParameter()
            {
                Amount = 0,
                Body = "",
                NotifyUrl = "",
                PassbackParams = "",
                Subject = "",
                TradeNo = ""
            });
            return payResult;
        }


        /// <summary>
        /// 核验银行卡
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object CheckBankCard()
        {
            BankCard checker = new BankCard("e064e35a9b6b4944a1866f910a874228");
            var response = checker.GetResult("李伟", "62284809385785843878", "362422199707056732", "18870214696");
            return response;
        }


        /// <summary>
        /// 获取token
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetAccessToken()
        {
            AccessToken accessToken = new AccessToken("wx29f3bc26447a5652", "2772c2e64cee873e47b906120680379e");
            var result = accessToken.GetResult();
            return result;
        }


        /// <summary>
        /// 获取token
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetQR()
        {
            AccessToken accessToken = new AccessToken("wx29f3bc26447a5652", "2772c2e64cee873e47b906120680379e");
            var result = accessToken.GetResult();
            if (result.errcode == 0)
            {
                QRCode qrcode = new QRCode();
                string picInfo = qrcode.Create(result.access_token, "123");
            }



            return result;
        }

    }
}
