using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearnApi.Controllers
{
    //Web Api supports code based configuration. It can not be configured in web.config file. We can configure Web Api to customize the behavior of Web Api
    //hosting infrastructure and components such as routes, formatters, filters, DependencyResolver, MessageHandlers, ParameterBindingRules, Properties,
    //services etc

    public class ConfigureWebApiController : ApiController
    {
        //Web Api configuration process starts when the application starts. It calls GlobalConfiguration.Configure(WebApiConfig.Register) in the
        //Application_Start method. The Configure() method requires the callback method where Web Api has been configured in code. By default this is the
        //static WebApiConfig.Register() method.

        //As you can see in WebApiConfig.cs, WebApiConfig.Register() method includes a parameter of HttpConfiguration type which is then used to configure the
        //Web Api. The HttpConfiguration is the main class which includes following properties using which you can override the default behavior of Web Api.

        //Property                      Description
        //DependencyResolver            Gets or sets the dependency resolver for dependency injection.
        //Filters                       Gets or sets the filters.
        //Formatters                    Gets or sets the media-type formatters.
        //IncludeErrorDetailPolicy      Gets or sets a value indicating whether error details should be included in error messages.
        //MessageHandlers               Gets or sets the message handlers.
        //ParameterBindingRules         Gets the collection of rules for how parameters should be bound.
        //Properties                    Gets the properties associated with this Web Api instance.
        //Routes                        Gets the collection of routes configured for the Web Api.
        //Services                      Gets the Web Api services.

        //What is a callback method?
        //A callback is a function that will be called when a process is done executing a specific task. The usage of a callback is usually in asynchronous logic.
        //To create a callback in C#, you need to store a function address inside a variable. This is achieved using a delegate or the new lambda semantic Func or
        //Action.
    }
}
