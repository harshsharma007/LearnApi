using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
<<<<<<< HEAD
=======
using LearnApi.Controllers.ExceptionHandling;
>>>>>>> 5f425d3 (Learn Api)

namespace LearnApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
<<<<<<< HEAD
=======
            config.Filters.Add(new CustomExceptionFilter());
>>>>>>> 5f425d3 (Learn Api)

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
<<<<<<< HEAD
                routeTemplate: "api/{controller}/{action}/{id}",
=======
                routeTemplate: "api/{controller}/{id}",
>>>>>>> 5f425d3 (Learn Api)
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
