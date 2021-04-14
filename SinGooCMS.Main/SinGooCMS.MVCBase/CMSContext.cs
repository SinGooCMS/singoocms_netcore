using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using SinGooCMS.Cache;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.MVCBase
{
    /// <summary>
    /// CMS 上下文
    /// </summary>
    public class CMSContext : ICMSContext, IUser, IManager
    {
        private readonly IUserRepository userRepository;
        private readonly ICacheStore cacheStore;

        public CMSContext(IUserRepository _userRepository, ICacheStore _cacheStore)
        {
            this.userRepository = _userRepository;
            this.cacheStore = _cacheStore;
        }

        public ILogger<SinGooBase> Log { get; set; }

        public ICache Cache => CacheProvider.Instance;

        #region 基础属性

        /// <summary>
        /// 1、NuGet加载包SinGooCMS.Utility
        /// 2、在Startup配置服务：services.AddStaticHttpContext();
        /// 3、在Startup配置使用：app.UseStaticHttpContext();
        /// 这样就能正常使用HttpContext了
        /// </summary>
        private HttpContext HttpContext => UtilsBase.HttpContext;
        private HttpRequest Request => UtilsBase.Request;
        private HttpResponse Response => UtilsBase.Response;

        #endregion

        #region 公共属性

        public string IP => IPUtils.GetIP();
        /// <summary>
        /// 1、读取纯真数据库获取IP的地理位置信息
        /// 2、纯真数据库存放地址：/IPData/qqwry.dat
        /// </summary>
        public Lazy<string> IPArea => new Lazy<string>(() => IPUtils.GetIPAreaStr().Replace("[本机地址 CZ88.NET]", "本机地址").Replace("本机地址 CZ88.NET", "本机地址"));

        private readonly string userAgent = UtilsBase.Request.Headers["User-Agent"].ToString();
        public bool IsMobileClient
        {
            get
            {
                string mobileUserAgent = "iphone|android|nokia|zte|huawei|lenovo|samsung|motorola|sonyericsson|lg|philips|gionee|htc|coolpad|symbian|sony|ericsson|mot|cmcc|iemobile|sgh|panasonic|alcatel|cldc|midp|wap|mobile|blackberry|windows ce|mqqbrowser|ucweb";
                Regex MOBILE_REGEX = new Regex(mobileUserAgent, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                if (!string.IsNullOrEmpty(userAgent) && MOBILE_REGEX.IsMatch(userAgent.ToLower()))
                    return true;

                return false;
            }
        }
        public bool IsWeixinClient => userAgent.ToLower().IndexOf("micromessenger") != -1;

        public ClientType ClientType
        {
            get
            {
                if (IsWeixinClient)
                    return ClientType.Weixin;
                else if (IsMobileClient)
                    return ClientType.Mobile;
                else
                    return ClientType.Pc;
            }
        }

        public string ValidateCode
        {
            get
            {
                var vcode = CookieUtils.GetCookie("vcode");
                if (!vcode.IsNullOrEmpty())
                    return SinGooBase.DesDecode(vcode);

                return string.Empty;
            }
        }

        public string LockPassword => CookieUtils.GetCookie("lockpwd");

        public bool IsPost =>
            Request.Method.Equals("POST");

        public bool IsGet =>
            Request.Method.Equals("GET");

        #endregion

        #region 多语言

        public string CurrLang => SinGooBase.CurrLang;

        public string GetCaption(string captionKey, string msg = "")
        {
            var txt = SinGooBase.GetCaption(captionKey, CurrLang);
            if (txt.Equals(captionKey) && !msg.IsNullOrEmpty())
                return msg;

            return txt;
        }

        #endregion

        #region member       

        public int UserID => CookieUtils.GetCookie("singoocms_uid").ToInt(-1);

        public string UserName
        {
            get
            {
                var cookieName = CookieUtils.GetCookie("singoocms_username");
                if (!string.IsNullOrEmpty(cookieName))
                    return System.Web.HttpUtility.UrlDecode(cookieName);

                return "游客";
            }
        }

        public string NickName
        {
            get
            {
                var cookieName = CookieUtils.GetCookie("singoocms_nickname");
                if (!string.IsNullOrEmpty(cookieName))
                    return System.Web.HttpUtility.UrlDecode(cookieName);

                return UserName; //没有昵称，默认就是会员名称
            }
        }

        /// <summary>
        /// 存储于cookie的加密密码
        /// </summary>
        public string EncodedPwd => System.Web.HttpUtility.UrlDecode(CookieUtils.GetCookie("singoocms_pwd"));

        public Lazy<UserInfo> LoginUser =>
            new Lazy<UserInfo>(() =>
            {
                //密码也是加密的，因此不用担心泄露
                if (UserID > 0 && !EncodedPwd.IsNullOrEmpty())
                {
                    var user = userRepository.FindAsync(UserID).GetAwaiter().GetResult();
                    //在cookie中存储的密码必须和会员密码的再次加密数据相同，而且会员状态需要为已审核
                    if (user != null && user.Status == (int)UserStatus.Normal && SinGooBase.DesEncode(user.Password) == EncodedPwd)
                        return user;
                }

                return null;
            });

        #endregion

        #region manager

        public AccountInfo LoginAccount => SessionUtils.GetSession<AccountInfo>("Account");
        public int AccountID => LoginAccount == null ? -1 : LoginAccount.AutoID;
        public string AccountName => LoginAccount == null ? string.Empty : LoginAccount.AccountName;

        #endregion

        #region 配置信息

        public string DbProviderName => ConfigUtils.ProviderName;
        public DbType DbType => EnumUtils.StringToEnum<DbType>(DbProviderName);

        public BaseConfigInfo SiteConfig => cacheStore.CacheBaseConfig;

        #endregion

        #region 模板信息

        public SiteTemplateInfo DefaultSiteTmpl => cacheStore.CacheDefaultSiteTmpl;

        public string TemplDir =>
            DefaultSiteTmpl == null ?
            "/views/templates/html/" :
            (DefaultSiteTmpl.TemplatePath.EndsWith("/")
            ? DefaultSiteTmpl.TemplatePath
            : DefaultSiteTmpl.TemplatePath + "/");

        /*
         * 视图的目录 格式为：/views/templates/{Theme}/{ClientType}/{Lang}/
         * PC-中文默认的目录为 /views/templates/html
         * PC-英文的目录为 /views/templates/html/en/
         * 
         * 微信端英文目录为 /views/templates/html/weixin/en/
         * 
         * 模板顺序：PC端、zh-cn默认是模板根目录
         * 1）判断客户端 非PC端在模板根目录下创建当前客户端目录 如 /views/templates/html/mobile/
         * 2）判断语种 非zh-cn中文简体在上述模板目录下再创建目录 如 /views/templates/html/mobile/en/
         */
        public string ViewDir
        {
            get
            {
                string _templatePrefix = TemplDir;

                /*
                 * 当访问端不是电脑端的时候，模板路径要加上客户端的标识 如手机端 mobile/ 微信端 weixin/
                 * 当配置不启动移动端的时候，仍然使用显示PC端的模板
                 */
                if (SiteConfig.EnabledMobile && ClientType != ClientType.Pc)
                    _templatePrefix += ClientType.ToString() + "/";

                //有多语种，跟在客户端的后面
                if (CurrLang != "zh-cn")
                    _templatePrefix += CurrLang + "/";

                return _templatePrefix;
            }
        }

        public string FieldControlTmplDir => $"/views/platform/{SiteConfig.Theme}/FieldControls/";

        #endregion

        #region controller信息

        public string AbsoluteUrl => WebUtils.GetAbsoluteUri();

        public string ControllerName =>
            HttpContext.GetRouteValue("Controller").ToString();

        public string ActionName =>
            HttpContext.GetRouteValue("Action").ToString();

        public string CurrNodeCode =>
            (string.Compare(ControllerName, "article", true) == 0 && HttpContext.GetRouteValue("UrlRewriteName") != null)
            ? HttpContext.GetRouteValue("UrlRewriteName").ToString()
            : "";

        public NodeInfo CurrNode =>
            !CurrNodeCode.IsNullOrEmpty()
            ? cacheStore.CacheNodes.Where(p => p.NodeIdentifier == CurrNodeCode).FirstOrDefault()
            : null;

        public int CurrContId
        {
            get
            {
                var id = HttpContext.GetRouteValue("Id");
                return (ControllerName.ToLower() == "article" && id != null) ? id.ToInt() : 0;
            }
        }

        #endregion

        #region 后端专有属性

        public string DataUrl =>
            WebUtils.GetUrlPathPart().Replace(ActionName, "DataJson");

        public int OpID
        {
            get
            {
                if (IsPost && Request.HasFormContentType && Request.Form.ContainsKey("opid"))
                    return WebUtils.GetFormVal<int>("opid");
                else if (IsGet && Request.Query.ContainsKey("opid"))
                    return WebUtils.GetQueryVal<int>("opid");
                else
                    return 0;
            }
        }

        public string ParamAction
        {
            get
            {
                if (IsPost && Request.HasFormContentType && Request.Form.ContainsKey("Action"))
                    return WebUtils.GetFormString("Action");
                else if (IsGet && Request.Query.ContainsKey("Action"))
                    return WebUtils.GetQueryString("Action");
                else
                    return string.Empty;
            }
        }

        public bool IsAdd =>
            ParamAction == OperationType.Add.ToString();

        public bool IsEdit =>
            ParamAction == OperationType.Modify.ToString();

        #endregion        
    }
}
