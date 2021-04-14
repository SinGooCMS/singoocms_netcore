using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS
{
    public enum ResultType
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success,
        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        Fail
    }

    #region Result扩展    

    public static class ResultExtension
    {
        /// <summary>
        /// 转为为详细的结果
        /// </summary>
        /// <param name="result"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static OperateResult ToOperateResult(this Result result, string code = "", string msg = "")
        {
            var opResult = new OperateResult(result.ret == ResultType.Success, result.code, result.msg)
            {
                status = result.status
            };

            if (!string.IsNullOrEmpty(code))
                opResult.code = code;
            if (!string.IsNullOrEmpty(msg))
                opResult.msg = msg;            

            return opResult;
        }

        /// <summary>
        /// 转为为详细的结果
        /// </summary>
        /// <param name="result"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string ToOperateResultJson(this Result result, string code = "", string msg = "")
        {
            var opResult = new OperateResult(result.ret == ResultType.Success, result.code, result.msg)
            {
                status = result.status
            };

            if (!string.IsNullOrEmpty(code))
                opResult.code = code;
            if (!string.IsNullOrEmpty(msg))
                opResult.msg = msg;            

            return opResult.ToString();
        }
    }

    #endregion

    public class Result
    {
        #region 构造方法

        public Result() : this("") { }
        public Result(string _msg) : this(ResultType.Fail, _msg) { }
        public Result(ResultType _ret, string _code = "", string _msg = "")
        {
            this.ret = _ret;
            this.code = _code;
            this.msg = _msg;
        }

        #endregion        

        #region 基础属性

        /// <summary>
        /// 状态码
        /// </summary>
        public virtual int status { get; set; } = 200;

        /// <summary>
        /// 返回结果 success/fail
        /// </summary>
        public virtual ResultType ret { get; set; } = ResultType.Fail;

        /// <summary>
        /// 返回结果代号，用于读取多语种信息
        /// </summary>
        public virtual string code { get; set; } = "OperationFail";

        /// <summary>
        /// 返回结果消息，当没有多语种设置时，使用此消息
        /// </summary>
        public virtual string msg { get; set; } = "";

        #endregion

        #region 返回快速结果

        public static Result success
        {
            get { return new Result(ResultType.Success, "OperationSuccess", "operation success"); }
        }
        public static Result fail
        {
            get { return new Result(ResultType.Fail, "OperationFail", "operation fail"); }
        }

        #endregion

        public IActionResult ToActionResult()
        {
            return new ContentResult { Content = this.ToString(), ContentType = "application/json" };
        }

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

            return $"{{\"ret\":\"{ret}\",\"code\":{code},\"msg\":\"{displayMessage}\"}}";
        }
    }
}