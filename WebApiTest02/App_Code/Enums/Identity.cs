using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;


namespace Api
{
    /// <summary>
    /// 管理使用者身分
    /// </summary>
    public enum Identity
    {
        [Description("管理者")]
        Admin = 1,

        [Description("一般使用者")]
        User = 2,
    }
}