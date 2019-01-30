using Api;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using ViewModel;

namespace Filters
{
    /// <summary>
    /// 功能很單純，僅用來判斷使用者是否有登入，而更細的身分判斷我通常會寫在 Action 內，Filter 只做第一層最簡單的防護
    /// </summary>
    public class CustomAuthorizeAttribute : AuthorizationFilterAttribute
    {
        //本文這邊使用UserManager，但是沒有寫過這個類別
        protected readonly AuthManager _userManager;
        public CustomAuthorizeAttribute()
        {
            _userManager = new AuthManager();
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //Filter 內用 try catch 包住所有程式，不應該在 AuthorizationFilter 內拋出異常，因為它不會被 ExceptionFilter 捕捉
            try
            {
                //掛上這個 Attribute 的 Controller 或 Action 將不會執行驗證權限的動作，代表這是個公開的 API，任何人都可以存取，
                if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Count > 0)
                {
                    return;
                }
                if (actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Count > 0)
                {
                    return;
                }

                var user = _userManager.GetUser();
                if (user == null)
                {
                    throw new CustomException("沒有權限。");
                }
            }
            catch (Exception ex)
            {
                if (!(ex is CustomException))
                {
                    ex = new CustomException("權限驗證異常。");
                }

                var result = new ResultViewModel
                {
                    success = false,
                    msg = ex.Message
                };
                actionContext.Response = actionContext.Request.CreateResponse(result);
            }
        }
    }
}