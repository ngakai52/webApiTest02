using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exceptions
{
    /// <summary>
    /// CustomException 的摘要描述
    /// </summary>
    public class CustomException : Exception
    {
        public CustomException(string msg) : base(msg)
        {
            //
            // TODO: 在這裡新增建構函式邏輯
            //
        }
    }
}