using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using ViewModel;

namespace Filters
{
    /// <summary>
    /// 該 Filter 會攔截異常，將錯誤訊息填入 ResultViewModel 的 msg 屬性內，然後將包裝後的異常回傳
    /// </summary>
    public class ExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var result = new ResultViewModel
            {
                success = false,
                msg = actionExecutedContext.Exception.Message
            };

            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(result);
        }
    }
}