using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using LearnApi.Controllers.ExceptionHandling;

namespace LearnApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Filters.Add(new CustomExceptionFilter());

            config.Services.Replace(typeof(IExceptionLogger), new UnhandledExceptionLogger());

            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
