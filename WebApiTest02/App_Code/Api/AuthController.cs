﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Api
{
    /// <summary>
    /// 測試登入和登出相關功能
    /// </summary>
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private AuthManager _authManager;
        public AuthController()
        {
            _authManager = new AuthManager();
        }

        //登入
        [HttpPost]
        [Route("signIn")]
        public void SignIn(SignInViewModel model)
        {
            //模擬從資料庫取得資料
            if (!(model.UserId == "abc" && model.Password == "123"))
            {
                throw new Exception("登入失敗，帳號或密碼錯誤");
            }

            var user = new User
            {
                Id = 1,
                UserId = "abc",
                UserName = "小明",
                Identity = Identity.User
            };
            _authManager.SignIn(user);
        }

        //登出
        [HttpPost]
        [Route("signOut")]
        public void SignOut()
        {
            _authManager.SignOut();
        }

        //測試是否通過驗證
        [HttpPost]
        [Route("isAuthenticated")]
        public bool IsAuthenticated()
        {
            var user = _authManager.GetUser();
            if (user == null)
            {
                return false;
            }
            return true;
        }
    }
}