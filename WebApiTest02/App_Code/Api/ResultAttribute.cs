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
    /// 繼承 ActionFilter 覆寫 OnActionExecuted 方法，該 Filter 的作用是包裝 Action 回傳的資料，將資料放入 ResultViewModel 的 data 屬性內，再回傳出去
    /// </summary>
    public class ResultAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
            {
                return;
            }

            //說明：這個 Filter 可以搭配 IgnoreResult Attribute 使用，如果我們希望有些 Controller 或 Action 的回傳資料不要經過包裝處理，例如檔案下載，那麼可以掛上 IgnoreResult 就會忽略這些 Action。
            var ignoreResult1 = actionExecutedContext.ActionContext.ActionDescriptor.GetCustomAttributes<IgnoreResultAttribute>().FirstOrDefault();
            var ignoreResult2 = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<IgnoreResultAttribute>().FirstOrDefault();
            if (ignoreResult1 != null || ignoreResult2 != null)
            {
                return;
            }

            var objectContent = actionExecutedContext.Response.Content as ObjectContent;

            var data = objectContent?.Value;

            var result = new ResultViewModel
            {
                success = true,
                data = data
            };

            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(result);
        }
    }
}