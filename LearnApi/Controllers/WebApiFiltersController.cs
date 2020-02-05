using LearnApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearnApi.Controllers
{
    /*
        Web API includes filters to add extra logic before or after action method executes. Filters can be used to provide cross-cutting features such as logging,
        exception handling, performance measurement, authentication and authorization.

        Filters are actually attributes that can be applied on the Web API controller or one or more action methods. Every filter attribute class must implement
        IFilter interface included in System.Web.Http.Filters namespace. However, System.Web.Http.Filters includes other interfaces and classes that can be used to
        create filter for specifc purpose.

        The following table lists important interfaces and classes that can be used to create Web API filters.

        Filter Type             Interface               Class                           Description
        Simple Filter           IFilter                 -                               Defines the methods that are used in a filter.
        Action Filter           IActionFilter           ActionFilterAttribute           Used to add extra logic before or after action method execute.
        Authentication Filter   IAuthenticationFilter   -                               Used to force users or clients to be authenticated before methods execute.
        Authorization Filter    IAuthorizationFilter    AuthorizationFilterAttribute    Used to restrict access to action methods to specific users or groups.
        Exception Filter        IExceptionFilter        ExceptionFilterAttribute        Used to handle all unhandled exception in Web API.
        Override Filter         IOverrideFilter         -                               Used to customize the behavior of other filter for individual action method.

        As you can see, the above table includes class as well as interface for some of the filter types. Interfaces include methods that must be implemented in your
        custom attribute class whereas filter class has already implemented necessary interfaces and provides virtual methods, so that they can be overriden to add
        extra logic. For example, ActionFilterAttribute class includes methods that can be overridden. We just need to override methods which we are interested in,
        whereas if you use IActionFilter attribute than you must implement all the methods.

        Classes and Interfaces are available in System.Web.Http.Filters.
    */

    [Log]
    public class WebApiFiltersController : ApiController
    {
        public WebApiFiltersController()
        {

        }

        public void Get()
        {

        }
    }
    /*
        After implementing filter, all the requests will be logged by WebApiFilterController. Thus, you can create filters for cross-cutting concerns.
    */
}
