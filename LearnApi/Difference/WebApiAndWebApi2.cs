using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnApi.Difference
{
    public class WebApiAndWebApi2
    {
        /*
            What are the differences between Web API and Web API 2?
            
            1. Attribute Routing
            With Attribute Routing, we can now have both HTTP VERB and action based routing on the same controller. We can achieve RESTful hierarchy (nested routing)
            on a single controller without any problems. Furthermore, we can also have different versions of the API routing to the same controller.
            
            public static class WebApiConfig
            {
                public static void Register(HttpConfiguration config)
                {
                    config.MapHttpAttributeRoutes();
                }
            }
            
            2. OWIN Self Host
            Web API 2 introduces a new self host package, called Microsoft.AspNet.WebApi.OwniSelfHost. It allows you to host Web API using Katana. There are plenty of
            examples of self hosting Web API on top of OWIN, but since Katana assemblies have been evolving very rapidly, most of them tend to be out of date as the
            APIs changed.
            
            The quickest and smallest code to get you up and running is:
            
            public class Startup
            {
                public void Configuration(IAppBuilder appBuilder)
                {
                    var config = new HttpConfiguration();
                    config.Routes.MapHttpRoute(
                        name: "DefaultApi",
                        routeTemplate: "api/{controller}/{id}",
                        defaults: new { id = RouteParameter.Optional }
                    );
                    appBuilder.UseWebApi(config);
                }
                
                public class Program
                {
                    static void Main()
                    {
                        using (WebApp.Start<Startup>("http://localhost:999/"))
                        {
                            Console.Readline();
                        }
                    }
                }
            }
            
            3. IHttpActionResult
            A new way of returning HttpResponseMessage from your controllers - which improves code reusability and testability.
            
            4. CORS (Cross Origin Resource Sharing Specification)
            
            5. HttpRequestContext
            A more elegant way of dealing with per-request contextual information. The role of HttpRequestContext is to improve testability and reduce the amount of
            set up code needed to get tests up and running.
            
            6. Testability
            This brings up to the next point and that is the testability of Web API. Compared to the old version, where testing code required lots of bootstraping
            in the controller or resorting to helper libraries like WebApiContrib, the set up code needed to test controllers in Web API 2 is much smaller and less
            noisy.
            
            7. ODATA Improvements
            Web API 2 adds support for $expand, $select and $value.
            
            - $expand behaves like Include in Entity Framework, as it forces a load of a related entity (or entities)
            - $select allows the client to ask for specific properties of the entity only
            - $value allows the client to get raw value of a given property
            
            8. Filter Overrides
            Small but very useful feature allowing you to override widely scoped filters (i.e. global level or controller level), from a narrower scope 
            (i.e. action level).
            
            9. ByteRangeStreamContent
            Introduction of this new type of HttpContent allows the client to easily request partial entities (HTTP status code 206) using the Content Range HTTP header.
        */
    }
}