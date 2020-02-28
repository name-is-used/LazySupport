/*
* ==============================================================================
*
* Filename: AccessToken
* Description: 
* 在线文档:https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/access-token/auth.getAccessToken.html
* 
* access_token 的存储至少要保留 512 个字符空间
* access_token 的有效期目前为 2 个小时，需定时刷新，重复获取将导致上次获取的 access_token 失效
* 建议开发者使用中控服务器统一获取和刷新 access_token，其他业务逻辑服务器所使用的 access_token 均来自于该中控服务器，不应该各自去刷新，否则容易造成冲突，导致 access_token 覆盖而影响业务
* access_token 的有效期通过返回的 expire_in 来传达，目前是7200秒之内的值，中控服务器需要根据这个有效时间提前去刷新。在刷新过程中，中控服务器可对外继续输出的老 access_token，此时公众平台后台会保证在5分钟内，新老 access_token 都可用，这保证了第三方业务的平滑过渡
* access_token 的有效时间可能会在未来有调整，所以中控服务器不仅需要内部定时主动刷新，还需要提供被动刷新 access_token 的接口，这样便于业务服务器在API调用获知 access_token 已超时的情况下，可以触发 access_token 的刷新流程
* 
* Version: 1.0
* Created: 2020/2/28 14:29:44
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.WeChat.MiniProgram
{
    /// <summary>
    /// 小程序访问令牌
    /// </summary>
    public class AccessToken
    {
        public string AppId { get; }
        public string AppSecret { get; }
        public AccessToken(string appId, string appSecret)
        {
            this.AppId = appId;
            this.AppSecret = appSecret;
        }

        /// <summary>
        /// 获取小程序码的access token
        /// </summary>
        /// <returns></returns>
        public string Get()
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", AppId, AppSecret);
            var client = new RestSharp.RestClient(url);
            var response = client.Execute(new RestRequest(Method.POST));
            return response.Content;
        }

        /// <summary>
        /// 获取小程序码的access token
        /// </summary>
        /// <returns></returns>
        public AccessTokenResult GetResult()
        {
            string response = this.Get();
            return JsonHelper.Deserialize<AccessTokenResult>(response);
        }

    }
}
