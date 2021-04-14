using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SinGooCMS.Cache;
using SinGooCMS.Domain.Models;

namespace SinGooCMS.Domain.Interface
{
    /// <summary>
    /// CMS上下文
    /// </summary>
    public interface ICMSContext : IDependency
    {
        /// <summary>
        /// 客户端IP
        /// </summary>
        string IP { get; }
        /// <summary>
        /// 客户端IP地理位置
        /// </summary>
        Lazy<string> IPArea { get; }

        /// <summary>
        /// 语种
        /// </summary>
        string CurrLang { get; }
        /// <summary>
        /// 获得多语种提示信息
        /// </summary>
        /// <param name="captionKey">关键字</param>
        /// <param name="msg">自定义提示</param>
        /// <returns>当没有配置多语种时，返回msg的值</returns>
        string GetCaption(string captionKey, string msg = "");

        /// <summary>
        /// 客户端是否移动端
        /// </summary>
        bool IsMobileClient { get; }
        /// <summary>
        /// 客户端是否微信端
        /// </summary>
        bool IsWeixinClient { get; }
        /// <summary>
        /// 来访客户端
        /// </summary>
        ClientType ClientType { get; }

        /// <summary>
        /// 验证码
        /// </summary>
        string ValidateCode { get; }
        /// <summary>
        /// 访问码
        /// </summary>
        string LockPassword { get; }
        /// <summary>
        /// 是否HttpPost
        /// </summary>
        bool IsPost { get; }
        /// <summary>
        /// 是否HttpGet
        /// </summary>
        bool IsGet { get; }

        /// <summary>
        /// 连接字符串配置的数据库类型
        /// </summary>
        string DbProviderName { get; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        DbType DbType { get; }

        /// <summary>
        /// 文本日志,用于记录异常信息
        /// </summary>
        ILogger<SinGooBase> Log { get; set; }
        /// <summary>
        /// 缓存
        /// </summary>
        ICache Cache { get; }

        /// <summary>
        /// 基本配置
        /// </summary>
        BaseConfigInfo SiteConfig { get; }

        /// <summary>
        /// 默认模板
        /// </summary>
        SiteTemplateInfo DefaultSiteTmpl { get; }

        /// <summary>
        /// 模板路径
        /// </summary>
        string TemplDir { get; }

        /// <summary>
        /// 视图路径(视图路径会受客户端、语种的影响，并不一定会与模板路径相同)
        /// </summary>
        string ViewDir { get; }

        /// <summary>
        /// 表单组件模板目录
        /// </summary>
        string FieldControlTmplDir { get; }

        /// <summary>
        /// 当前URL
        /// </summary>
        string AbsoluteUrl { get; }
        /// <summary>
        /// 控制器
        /// </summary>
        string ControllerName { get; }
        /// <summary>
        /// 方法
        /// </summary>
        string ActionName { get; }

        /// <summary>
        /// 当前栏目代号
        /// </summary>
        string CurrNodeCode { get; }
        /// <summary>
        /// 当前栏目信息（缓存）
        /// </summary>
        NodeInfo CurrNode { get; }
        /// <summary>
        /// 当前文章内容ID
        /// </summary>
        int CurrContId { get; }

        /// <summary>
        /// Json数据地址
        /// </summary>
        string DataUrl { get; }
        /// <summary>
        /// 以地址栏或者Form传递过来的opid参数值
        /// </summary>
        int OpID { get; }
        /// <summary>
        /// 以地址栏或者Form传递过来的Action参数值
        /// </summary>
        string ParamAction { get; }
        /// <summary>
        /// 是否新增
        /// </summary>
        bool IsAdd { get; }
        /// <summary>
        /// 是否修改
        /// </summary>
        bool IsEdit { get; }
    }
}
