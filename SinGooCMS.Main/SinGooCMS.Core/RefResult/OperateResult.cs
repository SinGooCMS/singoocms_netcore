using SinGooCMS.Utility.Extension;

namespace SinGooCMS
{
    /// <summary>
    /// 操作结果
    /// </summary>
    public class OperateResult : Result
    {
        #region 构造方法

        /// <summary>
        /// 调用名部结果
        /// </summary>
        /// <param name="result"></param>
        public OperateResult(Result result)
        {
            base.status = result.status;
            base.ret = result.ret;
            base.code = result.code;
            base.msg = result.msg;
        }

        /// <summary>
        /// 返回失败的结果
        /// </summary>
        /// <param name="code">代号</param>
        /// <param name="msg">消息提示</param>
        public OperateResult(string code, string msg) : this(false, code, msg) { }

        /// <summary>
        /// 返回结果
        /// </summary>
        /// <param name="isSuccess">是否成功</param>
        /// <param name="code">代码</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转地址</param>
        /// <param name="delay">延期时长（秒）</param>
        /// <param name="data">返回的数据</param>
        /// <param name="timeout">超时时长（秒）</param>
        /// <param name="status">状态码</param>
        public OperateResult(bool isSuccess, string code = "", string msg = "", string url = "", int delay = 0, string data = "", int timeout = 0, int status = 200)
        {
            base.status = status;
            base.ret = isSuccess ? ResultType.Success : ResultType.Fail;
            base.code = code;
            base.msg = msg;
            this.url = url;
            this.delay = delay;
            this.data = data;
            this.timeout = timeout;
        }

        #endregion

        #region 结果消息提示方法

        /// <summary>
        /// 成功的结果
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="code"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static OperateResult Success(string code, string msg, string url = "") => new OperateResult(true, code, msg, url);
        /// <summary>
        /// 成功的结果
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="code"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string SuccessJson(string code, string msg, string url = "") => new OperateResult(true, code, msg, url).ToString();

        /// <summary>
        /// 失败的结果
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static OperateResult Fail(string code, string msg) => new OperateResult(false, code, msg);
        /// <summary>
        /// 失败的结果
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static OperateResult Fail(string msg) => new OperateResult(false, "", msg);

        /// <summary>
        /// 失败的结果
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string FailJson(string code, string msg) => new OperateResult(false, code, msg).ToString();
        /// <summary>
        /// 失败的结果
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string FailJson(string msg) => new OperateResult(false, "", msg).ToString();

        /// <summary>
        /// 加载外部结果
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static string FromJson(Result result)
        {
            var opResult = new OperateResult(result.ret == ResultType.Success, result.code, result.msg)
            {
                status = result.status
            };
            return opResult.ToString();
        }

        #endregion

        #region 快速的返回结果

        /// <summary>
        /// 成功并要求加载的结果
        /// </summary>
        public static OperateResult successLoad = new OperateResult(true, "OperationSuccess", "", "loadData");

        /// <summary>
        /// 成功并要求加载的结果
        /// </summary>
        public static string successLoadJson = successLoad.ToString();

        /// <summary>
        /// 成功的结果
        /// </summary>
        public static new OperateResult success = new OperateResult(true, "OperationSuccess");

        /// <summary>
        /// 成功的结果
        /// </summary>
        public static string successJson = success.ToString();

        /// <summary>
        /// 失败的结果
        /// </summary>
        public static new OperateResult fail = new OperateResult(false, "OperationFail");

        /// <summary>
        /// 失败的结果
        /// </summary>
        public static string failJson = fail.ToString();

        #endregion

        #region 属性        

        /// <summary>
        /// 需要跳转的网址
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 延期时长（毫秒）
        /// </summary>
        public int delay { get; set; }

        /// <summary>
        /// 附加的数据
        /// </summary>
        public string data { get; set; }

        /// <summary>
        /// 超时时间
        /// </summary>
        public int timeout { get; set; }

        /// <summary>
        /// 签名随机数，只为区分消息不重复
        /// </summary>
        public string sign => System.Guid.NewGuid().ToString().Replace("-", "").ToLower();

        #endregion        

        /// <summary>
        /// 重写输出json数据
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string displayMessage = msg;
            if (!code.IsNullOrEmpty())
            {
                //优先查找多语种code的匹配项
                displayMessage = SinGooBase.GetCaption(code); //没有匹配时，原样返回code
                if (displayMessage.Equals(code))
                    displayMessage = msg;
            }

            return $"{{\"ret\":\"{ret}\",\"status\":{status},\"code\":\"{code}\",\"msg\":\"{displayMessage}\",\"url\":\"{url}\",\"delay\":{delay},\"data\":\"{System.Web.HttpUtility.HtmlEncode(data)}\",\"timeout\":{timeout},\"sign\":\"{sign}\"}}";
        }
    }
}
