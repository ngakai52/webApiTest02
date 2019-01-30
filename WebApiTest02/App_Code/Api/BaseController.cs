using Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Api
{
    /// <summary>
    /// BaseController 的摘要描述
    /// </summary>
    [CustomAuthorize]
    public class BaseController : ApiController
    {
        public BaseController()
        {
        }
    }
}