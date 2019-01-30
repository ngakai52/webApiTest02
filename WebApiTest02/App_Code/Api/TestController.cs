using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Api
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        //測試API
        [HttpGet]
        [Route("live")]
        public IEnumerable<Student> Live()
        {
            var result = new List<Student>();
            result.Add(new Student(100, "Brian"));
            result.Add(new Student(101, "Monkey"));
            //result.Add(new Student() { Id = 100, Name = "Brian" });
            //result.Add(new Student() { Id = 101, Name = "Monkey" });

            return result;
        }
    }
}