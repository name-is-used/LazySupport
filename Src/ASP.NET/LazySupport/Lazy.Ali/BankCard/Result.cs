/*
* ==============================================================================
*
* Filename: Result.cs
* Description: 
*
* Version: 1.0
* Created: 2020/2/28 0:19:01
* Compiler: Visual Studio 2010
*
* Author: Your name
* Company: Your company name
*
* ==============================================================================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.Ali.BankCard
{
    /// <summary>
    /// 校验状态
    /// </summary>
    public enum CheckStatus
    {
        /// <summary>
        /// 成功
        /// </summary>
        Success,
        /// <summary>
        /// 失败
        /// </summary>
        Failed,
        /// <summary>
        /// 没有次数
        /// </summary>
        Notimes
    }

    public class SuccessBody
    {
        public int code { get; set; }
        public string msg { get; set; }
        public int ret_code { get; set; }
        public string error { get; set; }
        public SuccessBelong belong { get; set; }
    }

    public class SuccessBelong
    {
        /// <summary>
        /// 地区
        /// </summary>
        public string area { get; set; }
        /// <summary>
        /// 银行客服
        /// </summary>
        public string tel { get; set; }
        /// <summary>
        /// 银行卡产品名称
        /// </summary>
        public string brand { get; set; }
        /// <summary>
        /// 银行名称
        /// </summary>
        public string bankName { get; set; }
        /// <summary>
        /// 银行卡种
        /// </summary>
        public string cardType { get; set; }
        /// <summary>
        /// 银行官网
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 银行卡
        /// </summary>
        public string cardNum { get; set; }
    }


    /// <summary>
    /// 成功信息
    /// </summary>
    public class SuccessInfo
    {
        public int showapi_res_code { get; set; }
        public string showapi_res_error { get; set; }
        public SuccessBody showapi_res_body { get; set; }
    }



    public class FailedBody
    {
        public int ret_code { get; set; }
        public string error { get; set; }
        public int code { get; set; }
        public string msg { get; set; }
        public int nameCount { get; set; }
        public int bankCount { get; set; }
        public int idCardCount { get; set; }
        public int phoneCount { get; set; }
    }


    /// <summary>
    /// 失败信息
    /// </summary>
    public class FailedInfo
    {
        public int showapi_res_code { get; set; }
        public string showapi_res_error { get; set; }
        public string showapi_res_id { get; set; }
        public FailedInfo showapi_res_body { get; set; }
    }




    /// <summary>
    /// 核验结果
    /// </summary>
    public class CheckResult
    {
        /// <summary>
        /// 状态
        /// </summary>
        public CheckStatus Status { get; set; }
        /// <summary>
        /// 信息
        /// </summary>
        public object Info { get; set; }
    }
}
