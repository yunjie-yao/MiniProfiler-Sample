using System.Web.Http.Filters;
using Newtonsoft.Json;
using StackExchange.Profiling;

namespace Learn.Filters
{
    public class WebApiProfilingActionFilter:ActionFilterAttribute
    {
        public const string MiniProfilerResultsHeaderName = "X-MiniProfiler-Ids";

        public override void OnActionExecuted(HttpActionExecutedContext filterContext)
        {
            var MiniProfilerJson = JsonConvert.SerializeObject(new[] { MiniProfiler.Current.Id });
            //filterContext.Response.Content.Headers.Add(MiniProfilerResultsHeaderName, MiniProfilerJson);
        }
    }
}