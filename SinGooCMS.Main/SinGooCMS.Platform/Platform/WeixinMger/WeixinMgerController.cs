using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Application;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;
using SinGooCMS.Utility;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.WeixinMger
{
    public class WeixinMgerController : ManagerPageBase
    {
        private readonly IAutoRlyRepository autoRlyRepository;

        public WeixinMgerController(IAutoRlyRepository _autoRlyRepository)
        {
            this.autoRlyRepository = _autoRlyRepository;
        }

        #region 公众号配置

        #region Post相关操作

        [HttpPost]
        [Permission("WXConfig", OperationType.Modify)]
        public async Task<string> WXConfig(IFormCollection form)
        {
            var wxConfig = new SinGooCMS.Weixin.WXConfig()
            {
                AppID = WebUtils.GetFormVal<string>("TextBox1"),
                AppSecret = WebUtils.GetFormVal<string>("TextBox2"),
                URL = WebUtils.GetFormVal<string>("TextBox3"),
                Token = WebUtils.GetFormVal<string>("TextBox4"),
                EncodingAESKey = WebUtils.GetFormVal<string>("TextBox5"),
                ExpireMinutes = WebUtils.GetFormVal<int>("TextBox6"),
            };

            try
            {
                await SinGooCMS.Weixin.WXConfig.Save(wxConfig);
                await LogService.AddEvent("更新微信公众号配置成功");

                return OperateResult.successJson;
            }
            catch
            {
                return OperateResult.FailJson("更新失败，请检查文件[/config/weixin.config]是否可写！");
            }
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission("WXConfig")]
        public async Task<IActionResult> WXConfig()
        {
            return View("WeixinMger/WXConfig.cshtml", await SinGooCMS.Weixin.WXConfig.Load());
        }

        #endregion

        #endregion

        #region 关注回复

        #region Post相关操作

        [HttpPost]
        [Permission("GuanZhuRlyMger", OperationType.Modify)]
        public async Task<string> Guanzhu(IFormCollection form)
        {
            string strAction = "update";
            AutoRlyInfo entity = await autoRlyRepository.GetFocusRly();
            if (entity == null)
            {
                strAction = "add";
                entity = new AutoRlyInfo();
                entity.RlyType = "关注回复";
                entity.MsgKey = "FoucusRly";
            }
            //赋值
            entity.MsgText = WebUtils.GetFormString("TextBox1");
            entity.MediaPath = WebUtils.GetFormString("TextBox2");
            entity.Description = WebUtils.GetFormString("TextBox3");
            entity.LinkUrl = WebUtils.GetFormString("TextBox4");
            entity.AutoTimeStamp = System.DateTime.Now;

            if (string.IsNullOrEmpty(entity.MsgText))
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");

            try
            {
                if (strAction == "add")
                    await autoRlyRepository.AddAsync(entity);
                else
                    await autoRlyRepository.UpdateAsync(entity);

                await LogService.AddEvent("更新关注回复成功");
                return OperateResult.successJson;
            }
            catch
            {
                //
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission("GuanZhuRlyMger")]
        public async Task<IActionResult> Guanzhu()
        {
            ViewBag.InitData = await autoRlyRepository.GetFocusRly() ?? new AutoRlyInfo();
            return View("WeixinMger/MessageRly.cshtml");
        }

        #endregion

        #endregion

        #region 默认回复

        #region Post相关操作

        [HttpPost]
        [Permission("DefaultRlyMger", OperationType.Modify)]
        public async Task<string> DefRly(IFormCollection form)
        {
            string strAction = "update";
            AutoRlyInfo entity = await autoRlyRepository.GetDefaultRly();
            if (entity == null)
            {
                strAction = "add";
                entity = new AutoRlyInfo();
                entity.RlyType = "默认回复";
                entity.MsgKey = "DefaultRly";
            }
            //赋值
            entity.MsgText = WebUtils.GetFormString("TextBox1");
            entity.MediaPath = WebUtils.GetFormString("TextBox2");
            entity.Description = WebUtils.GetFormString("TextBox3");
            entity.LinkUrl = WebUtils.GetFormString("TextBox4");
            entity.AutoTimeStamp = System.DateTime.Now;

            if (string.IsNullOrEmpty(entity.MsgText))
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");

            try
            {
                if (strAction == "add")
                    await autoRlyRepository.AddAsync(entity);
                else
                    await autoRlyRepository.UpdateAsync(entity);

                await LogService.AddEvent("更新默认回复成功");
                return OperateResult.successJson;
            }
            catch
            {
                //
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission("DefaultRlyMger")]
        public async Task<IActionResult> DefRly()
        {
            ViewBag.InitData = await autoRlyRepository.GetDefaultRly() ?? new AutoRlyInfo();
            return View("WeixinMger/MessageDefRly.cshtml");
        }

        #endregion

        #endregion
    }
}
