using System;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Application;

namespace SinGooCMS.Platform
{
    public class ErrorControler : Controller
    {
        public ErrorControler()
        {
            //
        }

        #region 404

        [Route("/error/404")]
        public IActionResult Error404()
        {
            return View("/views/error/404.cshtml");
        }

        #endregion

        #region 500

        [Route("/error/500")]
        public IActionResult Error500()
        {
            return View("/views/error/500.cshtml");
        }

        #endregion

        #region 其它错误

        [Route("/error/msg")]
        public IActionResult Msessage()
        {
            return View("/views/error/msg.cshtml");
        }

        #endregion
    }
}