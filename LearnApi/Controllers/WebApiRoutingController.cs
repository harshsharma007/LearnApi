using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

//Routing uses the namespace -> System.Web.Http.Routing
namespace LearnApi.Controllers
{
    //Web Api routing is similar to Asp.Net MVC routing. It routes an incoming HTTP request to a particular action method on a Web Api controller.
    //Web Api supports two types of routing:
    //1. Convention-based routing.
    //2. Attribute routing.

    public class WebApiRoutingController : ApiController
    {
        //Convention-based routing
        //In the convention-based routing, Web Api uses route templates to determine which controller and action method to execute. At least one route template
        //must be added into route table in order to handle various HTTP requests.
        //When we create a project, it creates WebApiConfig class in the App_Start folder with default route as in the WebApiConfig.cs class.

        //public static class WebApiConfig
        //{
        //    public static void Register(HttpConfiguration config)
        //    {
        //        // Enable attribute routing
        //        config.MapHttpAttributeRoutes();

        //        // Add default route using convention-based routing
        //        config.Routes.MapHttpRoute(
        //            name: "DefaultApi",
        //            routeTemplate: "api/{controller}/{id}",
        //            defaults: new { id = RouteParameter.Optional }
        //        );
        //    }
        //}

        //In the above WebApiConfig.Register() method, config.MapHttpAttributeRoutes() enables attribute routing. The config.Routes is a route table or route
        //collection of type HttpRouteCollection. The "DefaultApi" route is added in the route table using MapHttpRoute() extension method. The MapHttpRoute()
        //extension method internally creates a new instance of IHttpRoute and adds it to an HttpRouteCollection. However, you can create a new route and add
        //it into a collection manually as shown below.

        public static class WebApiConfig
        {
            public static void Register(HttpConfiguration config)
            {
                config.MapHttpAttributeRoutes();

                //Define route
                IHttpRoute defaultRoute = config.Routes.CreateRoute("api/{controller}/{id}", new { id = RouteParameter.Optional }, null);

                //Add route
                config.Routes.Add("DefaultApi", defaultRoute);
            }
        }

        //The following table lists parameters of MapHttpRoute method.
        //Parameter             Description
        //name                  Name of the route
        //routeTemplate         URL pattern of the route
        //defaults              An object parameter that includes default route values
        //constraints           Regex expression to specify characteristic of route values
        //handler               The handler to which the request will be dispatched
    }
}
