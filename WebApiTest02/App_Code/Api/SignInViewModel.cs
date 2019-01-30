using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api
{
    /// <summary>
    /// 類別接收傳回的帳號和密碼，ViewModel 的功能是接收前端傳回的資料，或回傳資料給前端，作為內部和外部溝通的橋樑。
    /// </summary>
    public class SignInViewModel
    {
        //帳號
        public string UserId { get; set; }
        //密碼
        public string Password { get; set; }
    }
}