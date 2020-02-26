using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lazy.Test.Controllers
{
    public class PayController : ApiController
    {
        /// <summary>
        /// 支付宝h5支付
        /// </summary>
        /// <returns></returns>
        public string AliH5Pay()
        {
            Lazy.Ali.Trade.H5Payment payment = new Ali.Trade.H5Payment("2019072265978183", "", "");
            string payResult = payment.Pay(new Ali.Trade.H5PaymentParameter(){
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
            string payResult = payment.Pay(new Ali.Trade.AppPaymentParameter(){
                Amount = 0,
                Body = "",
                NotifyUrl = "",
                PassbackParams = "",
                Subject = "",
                TradeNo = ""
            });
            return payResult;
        }



    }
}
