using System;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Application;

namespace SinGooCMS.Platform
{
    /*

                           _ooOoo_
                          o8888888o
                          88" . "88
                          (| -_- |)
                          O\  =  /O
                       ____/`---'\____
                     .'  \\|     |//  `.
                    /  \\|||  :  |||//  \
                   /  _||||| -:- |||||-  \
                   |   | \\\  -  /// |   |
                   | \_|  ''\---/''  |   |
                   \  .-\__  `-`  ___/-. /
                 ___`. .'  /--.--\  `. . __
              ."" '<  `.___\_<|>_/___.'  >'"".
             | | :  `- \`.;`\ _ /`;.`/ - ` : | |
             \  \ `-.   \_ __\ /__ _/   .-` /  /
        ======`-.____`-.___\_____/___.-`____.-'======
                           `=---='
        ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
                    佛祖保佑      永无BUG
    */

    public class SinGooDefController : UIPageBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (Context.DefaultSiteTmpl == null)
                throw new Exception("the default sitetemplate not found.");

            return View(Context.DefaultSiteTmpl?.HomePage ?? "index.cshtml");
        }
    }
}
