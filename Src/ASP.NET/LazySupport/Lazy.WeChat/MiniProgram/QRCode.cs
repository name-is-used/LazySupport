/*
* ==============================================================================
*
* Filename:QRCode.cs
* Description: 小程序码生成
* 在线文档:https://developers.weixin.qq.com/miniprogram/dev/framework/open-ability/qr-code.html
*
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.WeChat.MiniProgram
{
    /// <summary>
    /// 二维码生成
    /// </summary>
    public class QRCode
    {
        /// <summary>
        /// auto_color 为 false 时生效，使用 rgb 设置颜色 
        /// 例如 {"r":"xxx","g":"xxx","b":"xxx"} 十进制表示
        /// 非必填
        /// </summary>
        private LineColor lineColor;
        /// <summary>
        /// 自动配置线条颜色，如果颜色依然是黑色，则说明不建议配置主色调，默认 false
        /// 非必填
        /// </summary>
        private bool autoColor;
        /// <summary>
        /// 必须是已经发布的小程序存在的页面（否则报错），
        /// 例如 pages/index/index, 根路径前不要填加 /,不能携带参数（参数请放在scene字段里），如果不填写这个字段，默认跳主页面
        /// 非必填
        /// </summary>
        private string page;
        /// <summary>
        /// 二维码的宽度，单位 px，最小 280px，最大 1280px
        /// 非必填
        /// </summary>
        private int width;
        /// <summary>
        /// 是否需要透明底色，为 true 时，生成透明底色的小程序
        /// 非必填
        /// </summary>
        private bool hyaline;

        public QRCode()
        {
            this.autoColor = false;
            this.lineColor = new LineColor() { 
                 r = 0,
                 g = 0,
                 b = 0
            };
            this.width = 430;
            this.page = "pages/index/index";
            this.hyaline = false;
        }

        /// <summary>
        /// 线条颜色
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public QRCode SetLineColor(LineColor color)
        {
            this.lineColor = color;
            this.autoColor = true;
            return this;
        }

        /// <summary>
        /// 扫码时的跳转页
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public QRCode SetPage(string page)
        {
            this.page = page;
            return this;
        }

        /// <summary>
        /// 设置宽
        /// </summary>
        /// <param name="width"></param>
        /// <returns></returns>
        public QRCode SetWidth(int width)
        {
            this.width = width;
            return this;
        }

        /// <summary>
        /// 是否透明
        /// </summary>
        /// <returns></returns>
        public QRCode SetHyaline()
        {
            this.hyaline = true;
            return this;
        }

        /// <summary>
        /// 生成小程序码
        /// </summary>
        /// <param name="accessToken">访问令牌</param>
        /// <param name="scene">扫码时携带数据</param>
        /// <returns>成功返回的图片 Buffer,失败返回JSON</returns>
        public string Create(string accessToken, string scene)
        {
            // 适用于需要的码数量极多的业务场景
            string url = string.Format("https://api.weixin.qq.com/wxa/getwxacodeunlimit?access_token={0}", accessToken);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            string json = JsonHelper.Serialize(new{
                page = page,
                scene = scene,
                width = this.width,
                auto_color = this.autoColor,
                line_color = this.lineColor,
                is_hyaline = this.hyaline
            });
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response.Content;
        }
       
    }
}
