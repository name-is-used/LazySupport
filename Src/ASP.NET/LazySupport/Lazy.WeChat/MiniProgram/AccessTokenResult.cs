/*
* ==============================================================================
*
* Filename: AccessTokenResult
* Description: 
*
* Version: 1.0
* Created: 2020/2/28 14:40:51
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

namespace Lazy.WeChat.MiniProgram
{
    /// <summary>
    /// 结果
    /// </summary>
    public class AccessTokenResult
    {
        /// <summary>
        /// 获取到的凭证
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 凭证有效时间，单位：秒。目前是7200秒之内的值。
        /// </summary>
        public int expires_in { get; set; }
        /// <summary>
        /// 错误码
        // 0:请求成功,其它参见在线文档
        /// </summary>
        public int errcode { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string errmsg { get; set; }
    }
}
