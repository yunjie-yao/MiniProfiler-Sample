using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using StackExchange.Profiling;

namespace Learn.Controllers
{
    public class DefaultController:ApiController
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        [Route("")]
        public IHttpActionResult Get()
        {
            string url1 = string.Empty;
            string url2 = string.Empty;
            using (MiniProfiler.Current.Step("Get方法"))
            {
                using (MiniProfiler.Current.Step("准备数据"))
                {
                    using (MiniProfiler.Current.CustomTiming("SQL", "SELECT * FROM Config"))
                    {
                        // 模拟一个SQL查询
                        Thread.Sleep(500);

                        url1 = "https://www.baidu.com";
                        url2 = "https://www.sina.com.cn/";
                    }
                }


                using (MiniProfiler.Current.Step("使用从数据库中查询的数据，进行Http请求"))
                {
                    using (MiniProfiler.Current.CustomTiming("HTTP", "GET " + url1))
                    {
                        var client = new WebClient();
                        var reply = client.DownloadString(url1);
                    }

                    using (MiniProfiler.Current.CustomTiming("HTTP", "GET " + url2))
                    {
                        var client = new WebClient();
                        var reply = client.DownloadString(url2);
                    }
                }
            }
            return Ok(new string[] { "value1", "value2" });
        }
        [Route("step")]
        public IHttpActionResult GetWithStep()
        {
            var profiler = MiniProfiler.Current;

            using (profiler.Step("Starting a profiling Step"))
            {
                return Json(new
                {
                    Name = "Marco",
                    Description = "I haz profiling!`"
                });
            }
        }

        [Route("notfound")]
        public IHttpActionResult NothingToSeeHere()
        {
            return NotFound();
        }

        [HttpPost]
        [Route("posting")]
        public IHttpActionResult PostSomething(string stuff)
        {
            return Ok(stuff);
        }

        [Route("broken")]
        public IHttpActionResult ThrowAnError()
        {
            throw new Exception("Error error");
        }
    }
}