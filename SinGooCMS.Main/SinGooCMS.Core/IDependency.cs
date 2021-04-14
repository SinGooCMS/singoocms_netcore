using System;
using System.Collections.Generic;
using System.Text;

namespace SinGooCMS
{
    /// <summary>
    /// 只有引用了此接口 才会自动注入服务
    /// </summary>
    public interface IDependency
    {
        //
    }

    /// <summary>
    /// 单一的（类似静态的）引用
    /// </summary>
    public interface ISingleDependency
    {
        //
    }
}
