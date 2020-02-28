/*
* ==============================================================================
*
* Filename:Verification.cs
* Description: 阿里云四元素核验
* 文档:https://market.aliyun.com/products/57000002/cmapi013074.html?spm=5176.2020520132.101.1.22c57218FHQn4O#sku=yuncode707400008
* Version: 1.0
* Created: 2020/2/27 18:52:17
* Compiler: Visual Studio 2010
*
* Author: liwei
* Company: Your company name
*
* ==============================================================================
*/

using Lazy.Util;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.Ali.BankCard
{
    /// <summary>
    /// 银行卡四元素核验
    /// </summary>
    public class BankCard
    {
        public string Appcode { get; }
        public BankCard(string appcode)
        {
            this.Appcode = appcode;
        }

        /// <summary>
        /// 校验
        /// </summary>
        /// <param name="acctName">持卡人姓名</param>
        /// <param name="acctNo">银行卡帐号</param>
        /// <param name="idCard">开户身份证号</param>
        /// <param name="phoneNum">绑定手机号</param>
        /// <returns></returns>
        public string Check(string acctName, string acctNo, string idCard, string phoneNum)
        {
            string url = "https://ali-bankcard4.showapi.com/bank4";
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "APPCODE " + this.Appcode);
            request.AddParameter("acct_name", acctName);
            request.AddParameter("acct_pan", acctNo);
            request.AddParameter("cert_id", idCard);
            request.AddParameter("cert_type", "01");
            request.AddParameter("needBelongArea", "true");
            request.AddParameter("bankPreMobile", phoneNum);
            var response = client.Execute(request);
            return response.Content;
        }

        /// <summary>
        /// 获取校验结果
        /// </summary>
        /// <param name="acctName">持卡人姓名</param>
        /// <param name="acctNo">银行卡帐号</param>
        /// <param name="idCard">开户身份证号</param>
        /// <param name="phoneNum">绑定手机号</param>
        /// <returns></returns>
        public CheckResult GetResult(string acctName, string acctNo, string idCard, string phoneNum)
        {
            string content = Check(acctName, acctNo, idCard, phoneNum);
            CheckResult result = new CheckResult();
            if (string.IsNullOrWhiteSpace(content))
            {
                result.Status = CheckStatus.Notimes;
                result.Info = "times limit";
                return result;
            }

            if (content.IndexOf("showapi_res_id") == -1)
            {
                result.Status = CheckStatus.Success;
                result.Info = JsonHelper.Deserialize<SuccessInfo>(content);
            }
            else
            {
                result.Status = CheckStatus.Failed;
                result.Info = JsonHelper.Deserialize<FailedInfo>(content);
            }

            return result;
        }
    }
}
