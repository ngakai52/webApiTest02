using Exceptions;
using Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Api
{
    /// <summary>
    /// 測試各個 Filter 的功能
    /// </summary>
    [Result]
    [Exception]
    [RoutePrefix("api/testFilter")]
    public class TestFilterController
    {
        //正常
        [HttpGet]
        [Route("getStudents_1")]
        public List<Student> GetStudents_1()
        {
            return CreateStudents();
        }

        //忽略權限驗證
        [AllowAnonymous]
        [HttpGet]
        [Route("getStudents_2")]
        public List<Student> GetStudents_2()
        {
            return CreateStudents();
        }

        //忽略 ResultFilter
        [IgnoreResult]
        [HttpGet]
        [Route("getStudents_3")]
        public List<Student> GetStudents_3()
        {
            return CreateStudents();
        }

        //拋出異常
        [HttpGet]
        [Route("getStudents_4")]
        public List<Student> GetStudents_4()
        {
            throw new CustomException("取得資料失敗");
        }

        private List<Student> CreateStudents()
        {
            return new List<Student>
            {
                new Student(100, "Spy"),
                new Student(101, "Andy")
            };
        }
    }
}