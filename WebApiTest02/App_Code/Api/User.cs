using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api
{
    /// <summary>
    /// 定義要存入 Cookie 的資訊
    /// </summary>
    public class User
    {
        //流水號
        public int Id { get; set; }
        //帳號
        public string UserId { get; set; }
        //名稱
        public string UserName { get; set; }
        //身分
        public Identity Identity { get; set; }
    }
}