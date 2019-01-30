using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewModel
{
    /// <summary>
    /// 作為所有 API 的統一介面
    /// </summary>
    public class ResultViewModel
    {
        /// <summary>
        /// 代表請求是否執行成功。
        /// </summary>
        public bool success { get; set; }

        /// <summary>
        /// 存放異常的錯誤訊息。
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 存放請求成功後回傳的資料。
        /// </summary>
        public object data { get; set; }
    }
}