using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace LearnApi.Controllers.ExceptionHandling
{
    [CustomExceptionFilter]
    public class ExceptionFiltersController : ApiController
    {
        /*
            Exception Filters is the Level 2, which occurs at attribute level.
            
            The HttpResponseException class are great for handling action level exceptions, but what if we wanted to deal with many exceptions that could be thrown by
            many different actions?
            
            Exception filters can be used to handle unhandled exceptions which are generated in Web API. The exception filter can be able to catch the unhandled
            exceptions in Web API. This filter is executed when an action method throws the unhandled exception. Note that exception filter does not catch
            HttpResponseException exception because HttpResponseException is specifically designed to return the HTTP response.
            
            We can use exception filter whenever controller action method throws an unhandled exception that is not an HttpResponseException. This is an attribute so
            we can decorate both action method and controller with this. Exception filter is very similar to HandleErrorAttribute in MVC.
            
            After implementing the CustomExceptionFilter (code below), we have to REGISTER THE EXCEPTION FILTER. There are many ways to register exception filter but
            the developers generally follow three approaches to register filter:
            - Decorate Action with exception filter.
            - Decorate Controller with exception filter.
            - Register filter globally.
            
            To apply the exception filter to the specific action, the action needs to decorate with this filter attribute.
            To apply the exception filter to all the actions of a controller, the controller needs to be decorated with this filter attribute.
            To apply the exception filter to all Web API controllers, the filter needs to register to GlobalConfiguration.Configuration.Filters collection.
        */
    }

    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            string exceptionMessage = string.Empty;
            if (actionExecutedContext.Exception.InnerException == null)
            {
                exceptionMessage = actionExecutedContext.Exception.Message;
            }
            else
            {
                exceptionMessage = actionExecutedContext.Exception.InnerException.Message;
            }

            // We can log this exception message to the file or database.
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An unhandled exception was thrown by service."),
                ReasonPhrase = "Internal Server Error. Please Contact your Administrator."
            };
            actionExecutedContext.Response = response;
        }
    }
}