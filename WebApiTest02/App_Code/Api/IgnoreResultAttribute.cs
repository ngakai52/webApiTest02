using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filters
{
    /// <summary>
    /// 如果我們希望有些 Controller 或 Action 的回傳資料不要經過包裝處理，例如檔案下載，那麼可以掛上 IgnoreResult 就會忽略這些 Action。
    /// </summary>
    public class IgnoreResultAttribute : Attribute
    {
    }
}