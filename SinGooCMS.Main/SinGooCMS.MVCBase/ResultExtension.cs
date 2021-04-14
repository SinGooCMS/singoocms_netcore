using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace SinGooCMS.MVCBase
{
    /// <summary>
    /// 提示信息并跳转的结果
    /// </summary>
    public class JumpUrlResult : RedirectResult
    {
        /// <summary>
        /// 提示信息并跳转的结果
        /// </summary>
        /// <param name="msg">提示信息</param>
        /// <param name="redirectToUrl">跳转的网址</param>
        public JumpUrlResult(string msg, string redirectToUrl)
            : base($"/include/jump.html?msg={HttpUtility.UrlEncode(msg)}&redirecturl={redirectToUrl}")
        {
            //
        }
    }

    /// <summary>
    /// 显示消息的结果
    /// </summary>
    public class ShowMsgResult : RedirectResult
    {
        /// <summary>
        /// 显示消息的结果
        /// </summary>
        /// <param name="msg">提示信息</param>
        public ShowMsgResult(string msg)
            : base($"/error/msg?info={HttpUtility.UrlEncode(msg)}")
        {
            //
        }
    }

    /// <summary>
    /// 404的结果
    /// </summary>
    public class Show404Result : RedirectResult
    {
        public Show404Result()
            : base($"/error/404")
        {
            //
        }
    }

    /// <summary>
    /// 500的结果
    /// </summary>
    public class Show500Result : RedirectResult
    {
        public Show500Result()
            : base($"/error/500")
        {
            //
        }
    }
}
