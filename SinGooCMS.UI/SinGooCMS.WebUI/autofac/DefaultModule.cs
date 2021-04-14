using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Autofac;
using SinGooCMS.MVCBase;

namespace SinGooCMS.WebUI
{
    public class DefaultModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {            
            var baseType = typeof(IDependency);
            containerBuilder.RegisterAssemblyTypes(
                    new Assembly[]
                    {
                        Assembly.GetExecutingAssembly(),
                        Assembly.Load("SinGooCMS.Domain"),
                        Assembly.Load("SinGooCMS.Infrastructure"),
                        Assembly.Load("SinGooCMS.Application"),
                        Assembly.Load("SinGooCMS.MVCBase"),
                        Assembly.Load("SinGooCMS.Platform"),
                        Assembly.Load("SinGooCMS.Control")
                    }
                )
                .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
                .AsImplementedInterfaces().PropertiesAutowired();

            //获取所有控制器类型并使用属性注入
            var controllerBaseType = typeof(ControllerBase);
            containerBuilder.RegisterAssemblyTypes(
                    new Assembly[]
                    {
                        Assembly.GetExecutingAssembly(),
                        Assembly.Load("SinGooCMS.MVCBase"),
                        Assembly.Load("SinGooCMS.Application"),
                        Assembly.Load("SinGooCMS.Platform")
                    }
                )
                .Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType)
                .PropertiesAutowired();

            //containerBuilder.RegisterType<CMSContent>().AsSelf();
            //containerBuilder.RegisterType<SinGooCMS.Platform.WebUploader>().AsSelf();
            containerBuilder.RegisterType<ViewResultExecutor>().AsSelf();
        }
    }
}
