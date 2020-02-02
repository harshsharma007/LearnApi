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
    /*
        Web Api routing is similar to Asp.Net MVC routing. It routes an incoming HTTP request to a particular action method on a Web Api controller.
        Web Api supports two types of routing:
        1. Convention-based routing.
        2. Attribute routing.
    */
    public class WebApiRoutingController : ApiController
    {
        /*
            Convention-based routing
            In the convention-based routing, Web Api uses route templates to determine which controller and action method to execute. At least one route template
            must be added into route table in order to handle various HTTP requests.
            When we create a project, it creates WebApiConfig class in the App_Start folder with default route as in the WebApiConfig.cs class.

            public static class WebApiConfig
            {
                public static void Register(HttpConfiguration config)
                {
                    // Enable attribute routing
                    config.MapHttpAttributeRoutes();

                    // Add default route using convention-based routing
                    config.Routes.MapHttpRoute(
                        name: "DefaultApi",
                        routeTemplate: "api/{controller}/{id}",
                        defaults: new { id = RouteParameter.Optional }
                    );
                }
            }

            In the above WebApiConfig.Register() method, config.MapHttpAttributeRoutes() enables attribute routing. The config.Routes is a route table or route
            collection of type HttpRouteCollection. The "DefaultApi" route is added in the route table using MapHttpRoute() extension method. The MapHttpRoute()
            extension method internally creates a new instance of IHttpRoute and adds it to an HttpRouteCollection. However, you can create a new route and add
            it into a collection manually as shown below.
        */

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

        /*
            The following table lists parameters of MapHttpRoute method.
            Parameter             Description
            name                  Name of the route
            routeTemplate         URL pattern of the route
            defaults              An object parameter that includes default route values
            constraints           Regex expression to specify characteristic of route values
            handler               The handler to which the request will be dispatched

            How Web Api handles an incoming http request and sends the response?
            Considering the DefaultApi route configured in the above WebApiConfig class, the above request will execute Get() action method of the ValuesController
            because HTTP method is a Get and URL is http://localhost:1234/api/values which matches with DefaultApi's route template /api/{controller}/{id}
            where value of {controller} will be ValuesController. Default route has specified id as an optional parameter so if an id is not present in the url
            then {id} will be ignored. The request's HTTP method is GET so it will execute Get() action method of ValueController.

            If Web Api framework does not find matched routes for an incoming request then it will send 404 error response.
        */

        //Configure multiple routes
        public static class WebApiConfigWithMultipleRoutes
        {
            public static void Register(HttpConfiguration config)
            {
                config.MapHttpAttributeRoutes();

                //School route
                config.Routes.MapHttpRoute(
                    name: "School",
                    routeTemplate: "api/myschool/{id}",
                    defaults: new { controller = "school", id = RouteParameter.Optional }
                    );

                //Default route
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                    );

                /*
                    In the above example, School route is configured before DefaultApi route. So any incoming request will be matched with the School route first and
                    if incoming request url does not match with it then only it will be matched with DefaultApi route. For example, request url is
                    http://localhost:1234/api/mySchool
                */
            }
        }

        //Attribute routing
        /*
            Attribute routing is supported in Web Api 2. As the name implies, attribute routing uses [Route()] attribute to define routes. The Route attribute can be
            applied on any controller or action method.
            In order to use attribute routing with Web API, it must be enabled in WebApiConfig by calling config.MapHttpAttributeRoutes() method.
        */

        [Route("api/student/names")]
        public IEnumerable<string> Get()
        {
            return new string[] { "Student1", "Student2" };
        }

        /*
            In the above example, the Route attribute defines new route "api/student/names" which will be handled by the Get() action method of StudentController.
            Thus, an HTTP GET request http://localhost:1234/api/student/names will return list of student names.
        */
    }
}
