using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using StackExchange.Profiling;

namespace API_MiniProfiler
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            MiniProfiler.Configure(new MiniProfilerOptions
            {
                RouteBasePath = "~/mini-profiler-resources",
                PopupRenderPosition = RenderPosition.Right,  // defaults to left
                PopupMaxTracesToShow = 2,                   // defaults to 15
                ColorScheme = ColorScheme.Auto,              // defaults to light
                IgnoredPaths = { "/lib/", "/css/", "images" }

            });
        }
        protected void Application_BeginRequest()
        {
            MiniProfiler.StartNew();
        }

        protected void Application_EndRequest()
        {
            MiniProfiler.Current?.Stop();
        }
    }
}
