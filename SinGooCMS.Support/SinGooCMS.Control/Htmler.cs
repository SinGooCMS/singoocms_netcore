using System;
using System.Reflection;

namespace SinGooCMS.Control
{
    public class Htmler
    {
        public static IFieldControl Create(string controlType, object[] objs) =>
           Utility.ReflectionUtils.CreateInstance(SinGooBase.GetMapPath("SinGooCMS.Control.dll")
               , $"SinGooCMS.Control.Component.{controlType}"
               , objs)
            as IFieldControl;
    }
}
